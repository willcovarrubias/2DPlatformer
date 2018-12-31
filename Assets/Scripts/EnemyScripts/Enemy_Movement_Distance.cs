using UnityEngine;
using System.Collections;

public class Enemy_Movement_Distance : MonoBehaviour {

	GameObject playerTarget;
	public Transform myTransform;
	public float movementSpeed;
	Vector3 dif;
	public bool facingRight;
	public float aggroDistance;

	void Start () {
	
		playerTarget = GameObject.FindGameObjectWithTag("Player");
		myTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		FollowPlayer ();

		//TODO: Test to see if you can remove the line below from FixedUpdate since enemies will spawn AFTER the character.
		playerTarget = GameObject.FindGameObjectWithTag("Player");

		float distance = Vector2.Distance(myTransform.transform.position, playerTarget.transform.position);

		float step = movementSpeed * Time.deltaTime;
		Vector3 dir =  new Vector3(playerTarget.transform.position.x - transform.position.x, 0, 0);
		dir *= movementSpeed * Time.deltaTime;

		if(distance < aggroDistance)
			transform.Translate(dir);
			
	
	}

	void FollowPlayer()
	{
		//rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
		playerTarget = GameObject.FindGameObjectWithTag("Player");
		dif =  playerTarget.transform.position - transform.position;
		dif.Normalize();
		if (dif.x > 0) {
			FaceRight ();
			facingRight = true;
			//Debug.Log ("Facing right!");
		} else if (dif.x < 0) 
		{
			FaceLeft ();
			//	//Debug.Log ("Facing left!");
			facingRight = false;
		}


	}


	void FaceRight()
	{
		//rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
		Vector3 theScale = transform.localScale;
		theScale.x = 2;
		transform.localScale = theScale;

	}
	void FaceLeft()
	{
		//rotZ = Mathf.Atan2(dif.y, -dif.x) * Mathf.Rad2Deg;
		Vector3 theScale = transform.localScale;
		theScale.x = -2;
		transform.localScale = theScale;

	}

}
