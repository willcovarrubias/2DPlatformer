using UnityEngine;
using System.Collections;

public class SpawnPointActivatorAir : MonoBehaviour {

	//public static SpawnPointActivatorAir spawnPointActivatorAir;
	public Transform thisSpawnpoint;

		// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ToSpawnOrNot()
	{
		int spawnChance = Random.Range(0, 3);
		if(spawnChance < 1)
		{
			StartCoroutine(BeginSpawning());
		}
	}

	IEnumerator BeginSpawning()
	{
		int timeTilSpawn = Random.Range(0,10);
		yield return new WaitForSeconds(timeTilSpawn);

		string[] randomEnemyNames = new string[] {"Enemies/Shooter", "Enemies/Shooter 2.0"};
		
		string randomEnemy = null;
		
		randomEnemy = randomEnemyNames[Random.Range (0, 2)];

		Instantiate(Resources.Load(randomEnemy, typeof(GameObject)), transform.position, Quaternion.identity);

	}



}
