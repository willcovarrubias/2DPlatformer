using UnityEngine;
using System.Collections;

public class EnemyProjectiles : MonoBehaviour {

	public int moveSpeed = 20;
	public float bulletDespawn;
    private Animator _animator;
    private BoxCollider2D collider;
    private Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
        //_animator.Play("Rotate");
		Destroy (gameObject, bulletDespawn);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "GrabWall" || collision.gameObject.tag == "Wall")
        {
            //Debug.Log("You shot a wall!");
            //Destroy (gameObject);
            moveSpeed = 0;
            Destroy(gameObject, .5f);
        }
    }


    void OnTriggerEnter2D (Collision2D other)
    {

		
    }
}
