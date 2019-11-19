using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysics : Enemy
{
    private Controller2D controller2D;
    private Vector3 velocity;
    private float velocityXSmoothing;
    private Vector2 directionToMove;
    private float gravity;

    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    private float enemyIFrames = 0;
    private bool enemyWasAlreadyHit = false;
    Enemy enemy1;

    [SerializeField] enum EnemyType { Chaser, MeleeAttacker };
    [SerializeField] EnemyType enemyType;

    //Melee Attacker
    public float meleeTimer = 0f;
    public float meleeCD = 5f;

    private void Start()
    {
        controller2D = GetComponent<Controller2D>();
        animator = GetComponent<Animator>();

        enemy1 = new Enemy();

        FindPlayer();
    }

    private void Update()
    {
        if (FindPlayer() != null && !enemyIsStunned)
        {
            IsPlayerLeftOfTarget();

            if (velocity.x > 0)
                FaceRight();
            else if (velocity.x < 0)
                FaceLeft();

            directionToMove = new Vector2(FindPlayer().transform.position.x - transform.position.x, 0);

            float targetVelocityX = directionToMove.x * MovementSpeed;
            float targetVelocityY = (directionToMove.y * MovementSpeed) / 100;

            velocity.y += gravity * Time.deltaTime;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller2D.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);


            if (Mathf.Abs(FindPlayer().transform.position.x - transform.position.x) < 100)
            {
                controller2D.Move(velocity * Time.deltaTime, directionToMove);
                animator.SetFloat("Velocity", Mathf.Abs(velocity.x));
            }
            else
            {
                animator.SetFloat("Velocity", 0);
            }
        }

        if (enemyStunDuration >= 0)
        {
            enemyIsStunned = true;
            animator.SetBool("IsStunned", true);
            enemyStunDuration -= Time.deltaTime;
        }
        else
        {
            enemyIsStunned = false;
            animator.SetBool("IsStunned", false);
        }

        if (enemyWasAlreadyHit && enemyIFrames >= 0)
        {
            enemyIFrames -= Time.deltaTime;
        }
        if (enemyIFrames <= 0)
        {
            enemyWasAlreadyHit = false;
        }

        if (enemyType == EnemyType.MeleeAttacker)
        {
            //Melee Type
            if (meleeTimer >= 0)
            {
                meleeTimer -= Time.deltaTime;

            }

            if (enemyStunDuration >= 0)
            {
                enemyIsStunned = true;
                animator.SetBool("IsStunned", true);
                enemyStunDuration -= Time.deltaTime;
            }
            else
            {
                enemyIsStunned = false;
                animator.SetBool("IsStunned", false);
            }

            if (enemyWasAlreadyHit && enemyIFrames >= 0)
            {
                enemyIFrames -= Time.deltaTime;
            }
            if (enemyIFrames <= 0)
            {
                enemyWasAlreadyHit = false;
            }

            if (Mathf.Abs(FindPlayer().transform.position.x - transform.position.x) < 2 && Mathf.Abs(FindPlayer().transform.position.y - transform.position.y) < 3 && meleeTimer <= 0)
            {
                AttackPlayer();
            }
        }
        

    }

    private void FaceRight()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
    }

    private void FaceLeft()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;
    }

    private void AttackPlayer()
    {
        animator.Play("Melee");
        meleeTimer = meleeCD;
        //meleeTriggerHitBoxHorizontal.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.tag == "ShoulderBash" && !enemyWasAlreadyHit)
        {
            DamageEnemy(1, 2, true);
            enemyWasAlreadyHit = true;
            enemyIFrames = 1;
        }
    }
}
