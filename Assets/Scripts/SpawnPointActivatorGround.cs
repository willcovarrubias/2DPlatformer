using UnityEngine;
using System.Collections;

public class SpawnPointActivatorGround : MonoBehaviour {
	
	//public static SpawnPointActivatorAir spawnPointActivatorAir;
	public Transform thisSpawnpoint;
	public bool spawningOn;
	// Use this for initialization
	void Start () {
		spawningOn = false;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	
	void ToSpawnOrNot()
	{
		int spawnChance = Random.Range(0, 3);
		if(spawnChance < 2)
		{
			StartCoroutine(BeginSpawning());
		}

		
	}

	IEnumerator BeginSpawning()
	{
		int timeTilSpawm = Random.Range(0,10);
		yield return new WaitForSeconds(timeTilSpawm);
		
		string[] randomEnemyNames = new string[] {"Enemies/Runner", "Enemies/RunnerShooter"};
		
		string randomEnemy = null;
		
		randomEnemy = randomEnemyNames[Random.Range (0, 2)];
		
		Instantiate(Resources.Load(randomEnemy, typeof(GameObject)), transform.position, Quaternion.identity);
		
	}

}
