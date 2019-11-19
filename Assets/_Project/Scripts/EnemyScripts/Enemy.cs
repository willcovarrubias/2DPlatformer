using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    public float DamageDealt;
    public float MovementSpeed;
    public bool enemyIsStunned;
    public float HorizontalKnockBackAmount;
    public float VerticalKnockBackAmount;
    public float enemyStunDuration = 0;


    


    public Animator animator;
    //public GameObject playerTarget;
    //private CameraEffects virtualCamera;
    private new Rigidbody2D rigidbody2D;
    private AudioSource audioSource;

    public AudioClip GettingHit, GettingStunned, Dying;
    public GameObject bloodEffects;


    private void Awake()
    {
        //FindPlayer();
        //virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CameraEffects>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }



    public void DamageEnemy(int damage, float stunDuration, bool shoulderBash)
    {
        if (!IsPlayerLeftOfTarget())
            rigidbody2D.AddForce(new Vector2(HorizontalKnockBackAmount, VerticalKnockBackAmount));
        else
            rigidbody2D.AddForce(new Vector2(-HorizontalKnockBackAmount, VerticalKnockBackAmount));

        if (!shoulderBash)
        {
            animator.Play("TakingDamage");
            animator.SetBool("IsStunned", false);
            PlaySoundRandomized(GettingHit);
            SpawnBloodEffects();
        }
        else
        {
            animator.Play("EnemyStun");
            animator.SetBool("IsStunned", true);
            PlaySoundNormal(GettingStunned);
        }
        
        enemyStunDuration = stunDuration;
        Health -= damage;
        //virtualCamera.Shake(100, 1);
        if (Health <= 0)
            Destroy(gameObject);        
    }

    public void GiveEXP()
    {

    }

    public void DropSomething()
    { }

    public GameObject FindPlayer()
    {
        var playerTarget = GameObject.FindGameObjectWithTag("Player");
        return playerTarget;
    }

    public bool IsPlayerLeftOfTarget()
    {
        while (FindPlayer().transform.position.x >= transform.position.x)
        {
            return true;
        }
        return false;
    }

    public void PlaySoundRandomized(AudioClip clip)
    {
        audioSource.pitch = Random.Range(.8f, 1.2f);
        audioSource.PlayOneShot(clip);
    }

    public void PlaySoundNormal(AudioClip clip)
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clip);
    }

    private void SpawnBloodEffects()
    {
        Instantiate(bloodEffects, transform.position, Quaternion.Euler(0, 0, 0));
        FindPlayer().GetComponent<Player>().SpawnEnemyBloodSplatter();
    }


    

    private void Update()
    {
        
    }

    
}
