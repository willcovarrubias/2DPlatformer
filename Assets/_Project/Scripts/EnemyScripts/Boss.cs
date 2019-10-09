using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	
	/*Vector3 dif;
	private float rotZ;
	public Transform RightArm;
	public Transform LeftArm;
	///public Transform BloodSplat;
	
	public GameObject enemyToDie;
	public GameObject playerTarget;
	
	public static bool facingRight = true;
	public Transform TransformToFlip;

	public Transform BossItemSpawnPoint;
	
	bool takingCover;

	string Items;
	
	
	[System.Serializable]
	public class BossStats {
		
		public int Health = 100;
	}
	
	public BossStats stats = new BossStats();
	
	void DamageBoss (int damage)
	{
		
		//Transform enemyToKill = Enemy.enemy.transform;
		stats.Health -= damage;
		//	if(stats.Health <= 0)
		//	{
		//		Destroy(gameObject);
		//Enemy.EnemyKill();
		//GameMaster.KillEnemy(this.gameObject);
		//Destroy(Enemy.enemyToDie.gameObject);
		//		Debug.Log ("Pew pew, This guy is dead!");
		//	}
	}
	public void Update()
	{

		if(stats.Health <= 0)
		{


			StartCoroutine(SpawnRandomBossItem());
			//Debug.Log ("Boss is dead!");
		}
		
		//if(enemyToDie.gameObject.tag == "Shooter 2.0")
			//TODO: Change this tag once Shooter 2.0 is given official name.
		//	TakeCoverGround();
		
		
	}
	
	void FixedUpdate()
	{
		//if(takingCover == false)
		FollowPlayer();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.gameObject.tag == "Projectile")
		{
			DamageBoss(GameMaster.gameMaster.playerDamage);
			//Instantiate(BloodSplat, other.transform.position, other.transform.rotation);
		}
		
		if (other.gameObject.tag == "Player")
		{
			if(enemyToDie.gameObject.tag == "Kamikaze")
				Destroy(gameObject);
			else
				Debug.Log ("Begin attacking!");
		}
		
	}
	
	void FollowPlayer()
	{
		rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
		GameObject playerTarget = GameObject.FindGameObjectWithTag ("Player");
		dif =  playerTarget.transform.position - RightArm.position;
		dif.Normalize();
		if (dif.x > 0) {
			//FaceRight ();
			//facingRight = true;
			//Debug.Log ("Facing right!");
		} else if (dif.x < 0) 
		{
			//FaceLeft ();
			//	//Debug.Log ("Facing left!");
			//facingRight = false;
		}
		
		RightArm.rotation = Quaternion.Euler(0, 0, rotZ);
		LeftArm.rotation = Quaternion.Euler(0,0, rotZ);
	}
	public void FaceRight()
	{
		rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
		Vector3 theScale = TransformToFlip.localScale;
		theScale.x = 1;
		TransformToFlip.localScale = theScale;
		
	}
	public void FaceLeft()
	{
		rotZ = Mathf.Atan2(dif.y, -dif.x) * Mathf.Rad2Deg;
		Vector3 theScale = TransformToFlip.localScale;
		theScale.x = -1;
		TransformToFlip.localScale = theScale;
		
	}


	//public void SpawnRandomBossItem(string Items, int Amount)
		public IEnumerator SpawnRandomBossItem()
	{
		//string Items;
		yield return new WaitForSeconds (0.5f);	
		//Debug.Log ("THIS BEING CALLED?!");
		
		string[] randomItemNames = new string[] {"Prefabs/SMG"/*, "Prefabs/SMG2", "Prefabs/SMG3","Prefabs/SMG4"};
		
		string randomItem = null;
		
		randomItem = randomItemNames[Random.Range (0, 1)];
		
		//SpawnRandomBossItem(randomItem);

		Instantiate(Resources.Load(randomItem, typeof(GameObject)), BossItemSpawnPoint.position, Quaternion.identity);

		Destroy(gameObject);	

		
}*/



	
	
}
