using UnityEngine;
using System.Collections;

public class NextRoomSpawnerDown : MonoBehaviour {

	//public Transform DoorLeft;

	public Transform NextRoomOrigin;

	// Use this for initialization
	void Start () {
		//Instantiate (Door, DoorRight.transform.position, DoorRight.transform.rotation);
		if (GameMaster.gameMaster.roomCount < 19)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 19)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 19 && GameMaster.gameMaster.roomCount < 39)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 39)
			SpawnRandomBoss ();

		Debug.Log (GameMaster.gameMaster.roomCount);
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("Is this working?");
	}

	void SpawnRandomRoom()
	{

		string[] randomRoomNames = new string[] {"Rooms/Room004", "Rooms/Room004", "Rooms/Room004", "Buildings/Building04", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};

		string randomRoom = null;

		randomRoom = randomRoomNames[Random.Range (0, 2)];

		//SpawnRandomBossItem(randomItem);

		Instantiate(Resources.Load(randomRoom, typeof(GameObject)),  NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation );
		//Instantiate (Door, DoorLeft.transform.position, DoorLeft.transform.rotation);


		GameMaster.gameMaster.roomCount += 1;


		//Destroy(gameObject);	
	}

	void SpawnRandomBoss()
	{

		string[] randomRoomNames = new string[] {"Rooms/Boss001", "Rooms/Boss001", "Rooms/Boss001", "Buildings/Building04", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};

		string randomRoom = null;

		randomRoom = randomRoomNames[Random.Range (0, 2)];

		//SpawnRandomBossItem(randomItem);

		Instantiate(Resources.Load(randomRoom, typeof(GameObject)),  NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation );
		//Instantiate (Door, DoorLeft.transform.position, DoorLeft.transform.rotation);


		GameMaster.gameMaster.roomCount += 1;


		//Destroy(gameObject);	
	}

	/*void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player" && (GameMaster.gameMaster.roomClears == 4)) {
			
			if (GameMaster.gameMaster.waveGoing == false) {
				//UnicornHornRight.gameObject.SetActive(true);
				//UnicornHornLeft.gameObject.SetActive(true);
				//GraphicsMaster.graphicsMaster.CheckForGraphics();
				//Destroy(thisObject);
				GameMaster.gameMaster.roomClears += 1;
				Application.LoadLevel ("EndMenu");
				//SpawnRandomRoom ();

				Debug.Log ("This would be a boss!");
			}



		}
		if (other.gameObject.tag == "Player" && (GameMaster.gameMaster.roomClears <= 3)) {

			//UnicornHornRight.gameObject.SetActive(true);
			//UnicornHornLeft.gameObject.SetActive(true);
			//GraphicsMaster.graphicsMaster.CheckForGraphics();
			//Destroy(thisObject);
			GameMaster.gameMaster.roomClears += 1;
			SpawnRandomRoom ();


			Debug.Log (GameMaster.gameMaster.roomClears);
		}
	}*/
}