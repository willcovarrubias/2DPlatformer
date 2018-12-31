using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameMaster.gameMaster.waveGoing == true) {
			SpawnEnemy ();
		}
	}

	void SpawnEnemy()
	{

		string[] randomEnemyName = new string[] {"Enemies/Enemy001", "Enemies/Enemy001", "Rooms/Room001", "Buildings/Building04", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};

		string randomEnemy = null;

		randomEnemy = randomEnemyName [Random.Range (0, 2)];

		//SpawnRandomBossItem(randomItem);

		Instantiate(Resources.Load(randomEnemy, typeof(GameObject)),  transform.position, transform.rotation );
		//Instantiate (Door, DoorLeft.transform.position, DoorLeft.transform.rotation);
		//Instantiate (Door, DoorRight.transform.position, DoorRight.transform.rotation);


		Destroy(gameObject);	
	}
}
