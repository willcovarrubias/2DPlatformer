using UnityEngine;
using System.Collections;

public class NextRoomSpawner : MonoBehaviour {

    //public Transform DoorLeft;

    public int roomIdentity;

	public Transform NextRoomOrigin;

	// Use this for initialization
	void Start () {
		//Instantiate (Door, DoorRight.transform.position, DoorRight.transform.rotation);
		if (GameMaster.gameMaster.roomCount < 3)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 3)
			SpawnRandomBoss ();
        /*
		else if (GameMaster.gameMaster.roomCount > 9 && GameMaster.gameMaster.roomCount < 19)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 19)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 19 && GameMaster.gameMaster.roomCount < 29)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 29)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 29 && GameMaster.gameMaster.roomCount < 39)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 39)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 39 && GameMaster.gameMaster.roomCount < 49)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 49)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 49 && GameMaster.gameMaster.roomCount < 59)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 59)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 59 && GameMaster.gameMaster.roomCount < 69)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 69)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 69 && GameMaster.gameMaster.roomCount < 79)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 79)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 79 && GameMaster.gameMaster.roomCount < 89)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 89)
			SpawnRandomBoss ();
		else if (GameMaster.gameMaster.roomCount > 89 && GameMaster.gameMaster.roomCount < 99)
			SpawnRandomRoom ();
		else if (GameMaster.gameMaster.roomCount == 99)
			SpawnRandomBoss ();*/
		
		
	//	Debug.Log (GameMaster.gameMaster.roomCount);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Is this working?");
	}

	void SpawnRandomRoom()
	{
		if(roomIdentity == 1)
        {
            string[] randomRoomNames = new string[] { "Rooms/SSSE_1x1_Room_Template", "Rooms/SSSE_2x1_Room_Template", "Rooms/SSSE_2x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }

        if (roomIdentity == 2)
        {
            string[] randomRoomNames = new string[] { "Rooms/TSSE_1x1_Room_Template", "Rooms/TSBE_1x1_Room_Template", "Rooms/TSTE_1x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }
        if (roomIdentity == 3)
        {
            string[] randomRoomNames = new string[] { "Rooms/BSSE_1x1_Room_Template", "Rooms/BSBE_1x1_Room_Template", "Rooms/BSTE_1x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }
        if (roomIdentity == 4)
        {
            string[] randomRoomNames = new string[] { "Rooms/SSSE_1x1_Room_Template", "Rooms/SSSE_2x1_Room_Template", "Rooms/SSSE_1x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }
        if (roomIdentity == 5)
        {
            string[] randomRoomNames = new string[] { "Rooms/TSSE_1x1_Room_Template", "Rooms/TSBE_1x1_Room_Template", "Rooms/TSTE_1x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }
        if (roomIdentity == 6)
        {
            string[] randomRoomNames = new string[] { "Rooms/BSSE_1x1_Room_Template", "Rooms/BSBE_1x1_Room_Template", "Rooms/BSTE_1x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }
        if (roomIdentity == 7)
        {
            string[] randomRoomNames = new string[] { "Rooms/SSSE_1x1_Room_Template", "Rooms/SSBE_1x1_Room_Template", "Rooms/SSTE_1x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }
        if (roomIdentity == 8)
        {
            string[] randomRoomNames = new string[] { "Rooms/TSSE_1x1_Room_Template", "Rooms/TSBE_1x1_Room_Template", "Rooms/TSTE_1x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }
        if (roomIdentity == 9)
        {
            string[] randomRoomNames = new string[] { "Rooms/BSSE_1x1_Room_Template", "Rooms/BSBE_1x1_Room_Template", "Rooms/BSTE_1x1_Room_Template", "Rooms/test", "Buildings/Building05", "Buildings/Building06"/*,"Prefabs/SMG4"*/};
            string randomRoom = null;

            randomRoom = randomRoomNames[Random.Range(0, 3)];
            Instantiate(Resources.Load(randomRoom, typeof(GameObject)), NextRoomOrigin.transform.position, NextRoomOrigin.transform.rotation);
        }

        GameMaster.gameMaster.roomCount += 1;
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