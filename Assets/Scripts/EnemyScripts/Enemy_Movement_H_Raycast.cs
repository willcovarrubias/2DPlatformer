using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Enemy_Movement_H_Raycast : MonoBehaviour {

	Vector3 dif;
	//public bool facingRight;
	GameObject playerTarget;
	//private Rigidbody2D enemyRB;
	//public ForceMode2D fMode;
	public float movementSpeed = 45;
    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;

    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    public LayerMask whatToHit;
    Controller2D controller;
    Animator anim;
    Vector2 input;
	// Use this for initialization
	void Start()
	{
		
        //enemyRB = GetComponent<Rigidbody2D> ();
        controller = GetComponent<Controller2D>();
        anim = GetComponent<Animator>();


        //gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        //minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        //print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
            Invoke("FindPlayer", 1);
    }

	void LateUpdate()
	{
        //Vector2 input = new Vector2(1, 1);
        if (velocity.x > 0)
            FaceRight();
        else if (velocity.x < 0)
            FaceLeft();


        //TODO fix this since it creates an exception error since it can't find Player right away.
        if (playerTarget != null)
        {
            input = new Vector2(playerTarget.transform.position.x - transform.position.x, 0);

            float targetVelocityX = input.x * movementSpeed;
            //test
            float targetVelocityY = (input.y * movementSpeed) / 100;

            velocity.y += gravity * Time.deltaTime;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);




            if (Mathf.Abs(playerTarget.transform.position.x - transform.position.x) < 100)
            {
                controller.Move(velocity * Time.deltaTime, input);
                anim.SetFloat("Velocity", Mathf.Abs(velocity.x));
            }
            else
            {
                anim.SetFloat("Velocity", 0);
            }

        }

        //int wallDirX = (controller.collisions.left) ? -1 : 1;



















        //FollowPlayer();
    }
    
   /* void FixedUpdate()
	{
		FollowPlayer();


		Vector3 dir =  new Vector3(playerTarget.transform.position.x - transform.position.x, 0, 0);
		dir *= movementSpeed * Time.deltaTime;

		var left = transform.TransformDirection (Vector2.left) * 20;
		var right = transform.TransformDirection (Vector2.right) * 20;

		RaycastHit2D hitLeft = Physics2D.Raycast (transform.position, left,  20, whatToHit);
		Debug.DrawRay (transform.position, left, Color.red);
		if (hitLeft.collider != null) 
		{
			Debug.DrawLine (transform.position, hitLeft.point, Color.cyan);
			//Debug.Log ("Hitting Character with Raycast!");
			transform.Translate(dir);
			if(Time.time > nextFire)
			{    
				nextFire = Time.time + fireRate;
				Debug.Log ("Shoot!");

				FireEnemyBulletLeft();
			}
		}

		RaycastHit2D hitRight = Physics2D.Raycast (transform.position, right,  20, whatToHit);
		Debug.DrawRay (transform.position, right, Color.red);
		if (hitRight.collider != null) 
		{
			Debug.DrawLine (transform.position, hitRight.point, Color.cyan);
			//Debug.Log ("Hitting Character with Raycast!");
			transform.Translate(dir);
			/*if(Time.time > nextFire)
			{    
				nextFire = Time.time + fireRate;
				Debug.Log ("Shoot!");

				FireEnemyBulletLeft();
			}
		}

		//enemyRB.AddForce(dir, fMode);
		//




	}*/

    void FindPlayer()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

	void FollowPlayer()
	{
		//rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
		playerTarget = GameObject.FindGameObjectWithTag("Player");
		dif =  playerTarget.transform.position - transform.position;
		dif.Normalize();
		if (dif.x > 0) {
			FaceRight ();
			//facingRight = true;
			//Debug.Log ("Facing right!");
		} else if (dif.x < 0) 
		{
			FaceLeft ();
			//	//Debug.Log ("Facing left!");
			//facingRight = false;
		}


	}


	void FaceRight()
	{
		//rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
		Vector3 theScale = transform.localScale;
		theScale.x = 1;
		transform.localScale = theScale;

	}
	void FaceLeft()
	{
		//rotZ = Mathf.Atan2(dif.y, -dif.x) * Mathf.Rad2Deg;
		Vector3 theScale = transform.localScale;
		theScale.x = -1;
		transform.localScale = theScale;

	}

}
