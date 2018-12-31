using UnityEngine;
using System.Collections;

public class SidewaysShooter : MonoBehaviour {
	
	public Transform target;
	public Transform eyePoint;
	public GameObject EnemyBullet;
	public int moveSpeed;
	public int rotationSpeed;
	private Transform myTransform;
	public LayerMask whatToHit;
	
	Vector3 targetPos;
	Transform targetPosition;
	
	public float changeDirTime;
	
	int rx;
	int ry;
	
	private Rigidbody2D rb;
	public ForceMode2D fMode;
	public float speedForRandom = 300f;
	
	public bool timeReroll;

	public float fireRate;
	private float nextFire;
	
	void Awake() {
		myTransform = transform;
	}
	
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go.transform;
		
		Invoke("ChangeDirection",changeDirTime);
		
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		
		var lft = transform.TransformDirection (Vector2.left)* 20;
		var rgt = transform.TransformDirection (Vector2.right) *20;


		float distance = Vector3.Distance(target.transform.position, transform.position);
		Vector2 eyePointPosition = new Vector2 (eyePoint.position.x, eyePoint.position.y);

		RaycastHit2D hitLeft = Physics2D.Raycast (eyePointPosition, lft,  20, whatToHit);
		Debug.DrawRay (eyePointPosition, lft, Color.red);
		if (hitLeft.collider != null) 
		{
			Debug.DrawLine (eyePointPosition, hitLeft.point, Color.cyan);
			Debug.Log ("Take aim!");
			if(Time.time > nextFire)
			{    
				nextFire = Time.time + fireRate;
				Debug.Log ("Shoot!");
				
				FireEnemyBulletLeft();
			}
		}

			RaycastHit2D hitRight = Physics2D.Raycast (eyePointPosition, rgt,  20, whatToHit);
			Debug.DrawRay (eyePointPosition, rgt, Color.red);
			if(hitRight.collider !=null)
			{
				Debug.DrawLine (eyePointPosition, hitRight.point, Color.cyan);
				Debug.Log ("Take aim!");
				if(Time.time > nextFire)
				{    
					nextFire = Time.time + fireRate;
					Debug.Log ("Shoot!");
					
					FireEnemyBulletRight();
			}



			//			Enemy enemy = hit.collider.GetComponent<Enemy>();
			//			if(enemy != null)
			//		{
			//				enemy.DamageEnemy (Damage);
			//				Debug.Log ("Hitting enemy!");
		}
	
				
		if(timeReroll == true) 
		{
			
			int rx = Random.Range (-2, 3);
			
			Vector2 dir =  new Vector2(0, rx);
			dir *= speedForRandom * Time.deltaTime;
			
			rb.AddForce(dir, fMode);
		}
		else if(timeReroll == false)
		{
			int ry = Random.Range(-2, 3);
			
			Vector2 dir =  new Vector2(0, ry);
			dir *= speedForRandom * Time.deltaTime;
			
			rb.AddForce(dir, fMode);
		}			
	}
	
	void ChangeDirection()
	{
		if(Random.value >= 0.5f)
		{
			timeReroll = true;
		}else
			timeReroll = false;
		
		Invoke("ChangeDirection",changeDirTime);
	}

	void FireEnemyBulletLeft()
	{
		var lft = transform.TransformDirection (Vector2.left)* 20;
		GameObject playerTarget = GameObject.Find ("Player");
		
		if(playerTarget != null)
		{
			GameObject bullet = (GameObject)Instantiate(EnemyBullet, transform.position, Quaternion.Euler(0,0,90));
			
			//bullet.transform.position = transform.position;
			
			//Vector2 direction = playerTarget.transform.position - bullet.transform.position;
			
			//bullet.GetComponent<EnemyBulletScript>().SetDirection(lft);
		}
	}

	void FireEnemyBulletRight()
	{
		var rgt = transform.TransformDirection (Vector2.right)* 20;
		GameObject playerTarget = GameObject.Find ("Player");
		
		if(playerTarget != null)
		{
			GameObject bullet = (GameObject)Instantiate(EnemyBullet, transform.position, Quaternion.Euler(0,0,-90));
			
			//bullet.transform.position = transform.position;
			
			//Vector2 direction = playerTarget.transform.position - bullet.transform.position;
			
		//	bullet.GetComponent<EnemyBulletScript>().SetDirection(rgt);
		}
	}

}