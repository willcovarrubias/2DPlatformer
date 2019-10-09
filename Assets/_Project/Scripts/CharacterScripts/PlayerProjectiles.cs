using UnityEngine;

public class PlayerProjectiles : MonoBehaviour {

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



    void OnCollisionEnter2D (Collision2D other)
    {

		if (other.gameObject.tag == "Enemy" )
		{
            Destroy (gameObject);
            
		}

        if (other.gameObject.tag == "GrabWall")
        {
            //Destroy (gameObject);
            moveSpeed = 0;
            Destroy(gameObject, .5f);
        }
    }
}
