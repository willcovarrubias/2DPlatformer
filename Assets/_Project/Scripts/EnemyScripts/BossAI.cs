using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {
	
	//public static EnemyRandomMovement enemyRandomMovement;
	
	GameObject target;
	public int moveSpeed;
	public Transform myTransform;
	
	//Vector3 targetPos;
	//Transform targetPosition;
	
	private Rigidbody2D enemyRB;
	public ForceMode2D fMode;
		
	Animator anim;
	private Vector2 movement;
	
	//public GameObject bodyObject;
	Animator bodyAnimator;

	//public GameObject dodgeBall;
	//public Transform bossHandPoint;
	Vector3 dif;
	public float rotZ;
	Vector2 dir;

	//public Transform BossItemSpawnPoint;
	GameObject levelExiter;
	GameObject[] tempBoundariesToDestroy;

	GameObject bossHPBar, bossHPParentCanvas;
	public float cur_BossHealth;



	void Start () {
		//GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		//target = go.transform;
		//myTransform = transform;
		//bodyAnimator = bodyObject.GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag ("Player");

		
		enemyRB = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();

		//levelExiter = GameObject.FindGameObjectWithTag ("LevelExit1");
		//levelExiter.gameObject.SetActive(false);

		//StartCoroutine(BossRNG());

		bossHPBar = GameObject.FindGameObjectWithTag("BossHealth").gameObject;
		bossHPParentCanvas = GameObject.FindGameObjectWithTag ("BossHealthCanvas").gameObject;
		cur_BossHealth = stats.max_BossHealth;

	}
	
	void Update(){


		float calc_BossHealth = cur_BossHealth / stats.max_BossHealth;
		SetBossHealthBar (calc_BossHealth);
		//SetBossHealthBar();

		//rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
		//dif =  target.transform.position - bossHandPoint.position;
		//bossHandPoint.rotation = Quaternion.Euler(0, 0, rotZ);
		//float distance = Vector3.Distance(target.transform.position, transform.position);
		
		//Keep this as an example of Distance coding.
		
		//Vector2 dir =  new Vector2(target.transform.position.x - myTransform.position.x, target.transform.position.y - myTransform.position.y);
		//dir *= moveSpeed * Time.deltaTime;
		
		enemyRB.AddForce(dir, fMode);
		//	bodyAnimator.SetBool ("Moving", true);

		if(cur_BossHealth <= 0)
		{
			//StartCoroutine(SpawnRandomBossItem());
			BossDeath();
			Destroy (bossHPParentCanvas);
			Destroy (gameObject);
		}
	}

	public void SetBossHealthBar(float bossHealth)
	{
		bossHPBar.transform.localScale = new Vector3(bossHealth, bossHPBar.transform.localScale.y, bossHPBar.transform.localScale.z);
		bossHPBar.transform.localScale = new Vector3(Mathf.Clamp(bossHealth,0f ,1f), bossHPBar.transform.localScale.y, bossHPBar.transform.localScale.z);

	}

	IEnumerator BossRNG()
	{

		int bossAttack = Random.Range(0,4);
		yield return new WaitForSeconds(2);
		if(bossAttack == 1)
		{
			moveSpeed = 0;
			yield return new WaitForSeconds(0.5f);
			BossTripleShot();
			moveSpeed = 200;

		}
		if (bossAttack == 2)
		{
			moveSpeed = 0;
			yield return new WaitForSeconds(0.5f);
			BossSingleShot();
			moveSpeed = 200;
		}
		if(bossAttack == 3)
		{
			moveSpeed = 700;
		}
		StartCoroutine(BossRNG());
	}

	void BossSingleShot()   //Any number of shots with slightly varying direction.
	{
		
		//bossHandPoint.rotation = Quaternion.Euler(0, 0, rotZ);
		//Dodgeball throw!
		//TODO: Add throwing animation
		//Instantiate (dodgeBall, bossHandPoint.position, bossHandPoint.rotation);
	}

	void BossTripleShot()   //Any number of shots with slightly varying direction.
	{

		//bossHandPoint.rotation = Quaternion.Euler(0, 0, rotZ);
		//Dodgeball throw!
		//TODO: Add throwing animation
	//	Instantiate (dodgeBall, bossHandPoint.position, bossHandPoint.rotation);
	//	Instantiate (dodgeBall, bossHandPoint.position, Quaternion.Euler(0, 0, rotZ + 10));
	//	Instantiate (dodgeBall, bossHandPoint.position, Quaternion.Euler(0, 0, rotZ + -10));
	}


	void OnCollisionEnter2D (Collision2D other)
	{

		if (other.gameObject.tag == "MeleeWeapon")
		{
			//GameMaster.gameMaster.waveGoing = false;

			//Camera2DFollow.xPosRestriction = 3;
			//Camera2DFollow.xPosRestrictionRight = 0;

			//Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "PlayerProjectile" )
		{
			DamageBoss (20);
			//TODO: Change this value to reflect current attack damage, both ranged and melee.
		}
	}

	void DamageBoss (float damage)
	{

		//Transform enemyToKill = Enemy.enemy.transform;
		cur_BossHealth -= damage;
		//	if(stats.Health <= 0)
		//	{
		//		Destroy(gameObject);
		//Enemy.EnemyKill();
		//GameMaster.KillEnemy(this.gameObject);
		//Destroy(Enemy.enemyToDie.gameObject);
		//		Debug.Log ("Pew pew, This guy is dead!");
		//	}
	}

	public IEnumerator SpawnRandomBossItem()
	{
		//string Items;
		yield return new WaitForSeconds (0.5f);	

		//Camera2DFollow.xPosRestrictionRight += 60;	
		//levelExiter.gameObject.SetActive(true);
		//Debug.Log ("THIS BEING CALLED?!");
			
		string[] randomItemNames = new string[] { "Prefabs/SMG"/*, "Prefabs/SMG2", "Prefabs/SMG3","Prefabs/SMG4"*/ };
			
		string randomItem = null;
			
		randomItem = randomItemNames [Random.Range (0, 1)];
			
		Instantiate (Resources.Load (randomItem, typeof(GameObject)), transform.position, transform.rotation);
			
		Destroy (gameObject);	
			
			
	}

	void BossDeath()
	{
		tempBoundariesToDestroy = GameObject.FindGameObjectsWithTag("TempBoundary");
		//GameMaster.gameMaster.inABossFight = false;
		//GameMaster.gameMaster.EnemySpawner();
		//Destroy(tempBoundariesToDestroy);
		foreach(GameObject tempBoundary in tempBoundariesToDestroy)
		{
			Destroy(tempBoundary);
		}
	}

	[System.Serializable]
	public class BossStats {

		public float max_BossHealth = 100;
	}

	public BossStats stats = new BossStats();




	
}