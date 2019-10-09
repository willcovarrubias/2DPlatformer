using UnityEngine;
using System.Collections;

public class WaveStarter : MonoBehaviour {

	public Transform spawnPointActivator1, spawnPointActivator2, spawnPointActivator3, spawnPointActivator4;
	public LayerMask whatToHit;
	GameObject[] tempBoundariesToDestroy;



	// Use this for initialization


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	/*void OnTriggerEnter2D (Collider2D other)
	{
		//var rgt = transform.TransformDirection (Vector2.right) *56;

		if(other.gameObject.tag == "Player")
		//Camera2DFollow.xPosRestrictionRight += 60;
		//Debug.Log ("WAVE STARTING!");
		{
		GameMaster.gameMaster.EnemySpawner();

		//RaycastHit2D hitRight1 = Physics2D.Raycast (spawnPointActivator1.position, rgt,  56, whatToHit);
		//Debug.DrawRay (spawnPointActivator1.position, rgt, Color.red);
		//RaycastHit2D hitRight2 = Physics2D.Raycast (spawnPointActivator2.position, rgt,  56, whatToHit);
		//Debug.DrawRay (spawnPointActivator2.position, rgt, Color.red);
		RaycastHit2D[] hitRight3 = Physics2D.RaycastAll (spawnPointActivator3.position, rgt,  56, whatToHit);
		Debug.DrawRay (spawnPointActivator3.position, rgt, Color.red);
		//RaycastHit2D hitRight4 = Physics2D.Raycast (spawnPointActivator4.position, rgt,  56, whatToHit);
		//Debug.DrawRay (spawnPointActivator4.position, rgt, Color.red);
		//RaycastHit2D hitRight5 = Physics2D.Raycast (spawnPointActivator5.position, rgt,  56, whatToHit);
		//Debug.DrawRay (spawnPointActivator5.position, rgt, Color.red);

		//RaycastHit2D[] hitPoints = Physics2D.RaycastAll(spawnPointActivator1.position, rgt, 56, whatToHit);
		foreach(RaycastHit2D hit in hitRight3)
		{
			SpawnPointActivatorAir.spawningOn = true;
			//SpawnPointActivatorAir.KillTest1();
		}

		if(hitRight3.collider !=null)
		{
		Debug.DrawLine (spawnPointActivator3.position, hitRight3.point, Color.cyan);
			Debug.Log("The spawnpoint is colliding with the raycast");
			hitRight3.transform.SendMessage("HitByRay");
		}
		//RaycastHit hit;
		//if (Physics2D.Raycast(transform.position, rgt, out hitRight3))
		//	hit.transform.SendMessage ("HitByRay");

		//Destroy(gameObject);
	}
	}*/



	void OnTriggerEnter2D (Collider2D other)
	{
		var rgt = transform.TransformDirection (Vector2.right) *56;
		
		if(other.gameObject.tag == "Player")

		{
			//GameMaster.gameMaster.EnemySpawner();
			
			RaycastHit2D[] hitRight1 = Physics2D.RaycastAll (spawnPointActivator1.position, rgt,  50, whatToHit);
			Debug.DrawRay (spawnPointActivator1.position, rgt, Color.red);
			RaycastHit2D[] hitRight2 = Physics2D.RaycastAll (spawnPointActivator2.position, rgt,  50, whatToHit);
			Debug.DrawRay (spawnPointActivator2.position, rgt, Color.red);
			RaycastHit2D[] hitRight3 = Physics2D.RaycastAll (spawnPointActivator3.position, rgt,  50, whatToHit);
			Debug.DrawRay (spawnPointActivator3.position, rgt, Color.red);
			RaycastHit2D[] hitRight4 = Physics2D.RaycastAll (spawnPointActivator4.position, rgt,  50, whatToHit);
			Debug.DrawRay (spawnPointActivator4.position, rgt, Color.red);

			
			//RaycastHit2D[] hitPoints = Physics2D.RaycastAll(spawnPointActivator1.position, rgt, 56, whatToHit);
			foreach(RaycastHit2D hit in hitRight1)
			{
				hit.transform.SendMessage("ToSpawnOrNot");
			}
			foreach(RaycastHit2D hit in hitRight2)
			{
				hit.transform.SendMessage("ToSpawnOrNot");
			}
			foreach(RaycastHit2D hit in hitRight3)
			{
				hit.transform.SendMessage("ToSpawnOrNot");
			}
			foreach(RaycastHit2D hit in hitRight4)
			{
				hit.transform.SendMessage("ToSpawnOrNot");
			}

			
			/*if(hitRight3.collider !=null)
		{
		Debug.DrawLine (spawnPointActivator3.position, hitRight3.point, Color.cyan);
			Debug.Log("The spawnpoint is colliding with the raycast");
			hitRight3.transform.SendMessage("HitByRay");
		}*/
			//RaycastHit hit;
			//if (Physics2D.Raycast(transform.position, rgt, out hitRight3))
			//	hit.transform.SendMessage ("HitByRay");

			//Camera2DFollow.xPosRestrictionRight = transform.position.x;
			//Camera2DFollow.xPosRestriction = transform.position.x;

			Destroy(gameObject);
		}
	}

}
