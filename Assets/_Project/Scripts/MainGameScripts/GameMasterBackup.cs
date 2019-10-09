using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameMasterBackup : MonoBehaviour {

	public static GameMasterBackup gameMasterBackup;
	public GameObject PlayerToSpawn;

	public Transform PlayerSpawnPoint;

	public float char1Life, char1Att, char1Def, char1End, char1Agi;
	public float char2Life, char2Att, char2Def, char2End, char2Agi;
	public float char3Life, char3Att, char3Def, char3End, char3Agi;
	public float attPower;
	public bool SMG, handGun;
	public bool fireHat;
	public int playerDamage = 25;
	public float playerFireRate = 8;
	public int roomClears;
	public int roomCount;
	//put any attributes to boost here as floats

	//public Texture2D cursorTexture;
	//public CursorMode cursorMode = CursorMode.Auto;
	//public Vector2 hotSpot = Vector2.zero;

	public enum CharacterChosen{Character1, Character2, Character3, Character4}

	public CharacterChosen characterChosen;

	//GameObject healthBar; //the one that moves.
	GameObject staminaBar;
	GameObject vehicleHPBar;


	//Enemy Spawning variables here:
	public GameObject tempBoundary;
	public bool waveGoing;
	GameObject[] tempBoundariesToDestroy;
	GameObject enemy;


	void Update()
	{


		//if(waveGoing)
		//{

		//enemy = GameObject.FindGameObjectWithTag("Enemy");

		//EndWave();
		//}

		//CheckForHealthBars();
	}


	public void Awake()
	{
		Load ();

		if (gameMasterBackup == null) 
		{
			DontDestroyOnLoad (gameObject);
			gameMasterBackup = this;
		} 
		else if (gameMasterBackup != this) 
		{
			Destroy(gameObject);
		}

		//OnMouseEnter();

		//if (PlayerToSpawn == null)
		//{Instantiate (PlayerToSpawn, gameMaster.PlayerSpawnPoint.position, gameMaster.PlayerSpawnPoint.rotation);
		//	Debug.Log ("Did player spawn?");
	}




	void Start()
	{
		//GameMaster.gameMaster.handGun = true;

		//Instantiate (PlayerToSpawn, PlayerSpawnPoint.position, PlayerSpawnPoint.rotation);
		//CheckForHealthBars();
		Debug.Log("Life: " + char3Life + " Attack: " + char3Att);
		//Debug.Log ("Attack:", char3Att);
		//"Defense:", char3Def, "Endurance:", char3End, "Agility:", char3Agi);

	}

	/*public static void CheckForHealthBars()
	{
		gameMaster.healthBar = GameObject.FindGameObjectWithTag("PlayerHealth").gameObject;
		gameMaster.staminaBar = GameObject.FindGameObjectWithTag("PlayerStamina").gameObject;
		gameMaster.vehicleHPBar = GameObject.FindGameObjectWithTag("VehicleHealth").gameObject;

	}

	//void OnMouseEnter() {
	//	Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
//	}
//	void OnMouseExit() {
//		Cursor.SetCursor(null, Vector2.zero, cursorMode);
//	}

	/*IEnumerator SearchForEnemy()
	{
		yield return new WaitForSeconds(5);
		if(enemy)
		{
			Debug.Log("Enemies alive, searching again");
			StartCoroutine(SearchForEnemy());

		}
		else
		{
			Debug.Log("Found no enemies, will search again soon.");
			yield return new WaitForSeconds (2);
			if(enemy)
				StartCoroutine(SearchForEnemy());
			else
				EndWave();
		}
	}

	public void AtBossDeath()
	{
		//SpawnRandomBossItem();
	}

	void EndWave()
	{
		Debug.Log ("WAVE ENDING!");
		waveGoing = false;

		Camera2DFollow.xPosRestrictionRight = 450;
		Camera2DFollow.xPosRestriction = 0;
		tempBoundariesToDestroy = GameObject.FindGameObjectsWithTag("TempBoundary");
		//GameMaster.gameMaster.EnemySpawner();
		//Destroy(tempBoundariesToDestroy);
		foreach(GameObject tempBoundary in tempBoundariesToDestroy)
		{
			Destroy(tempBoundary);
		}
	}

	/*public void TempBoundaries()
	{
		GameObject tempBoundary01 = (GameObject)Instantiate(tempBoundary, new Vector3(0,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary02 = (GameObject)Instantiate(tempBoundary, new Vector3(80,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary03 = (GameObject)Instantiate(tempBoundary, new Vector3(160,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary04 = (GameObject)Instantiate(tempBoundary, new Vector3(240,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary05 = (GameObject)Instantiate(tempBoundary, new Vector3(320,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary06 = (GameObject)Instantiate(tempBoundary, new Vector3(400,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary07 = (GameObject)Instantiate(tempBoundary, new Vector3(480,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary08 = (GameObject)Instantiate(tempBoundary, new Vector3(560,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary09 = (GameObject)Instantiate(tempBoundary, new Vector3(640,0,0), Quaternion.Euler(0,0,90));
		GameObject tempBoundary10 = (GameObject)Instantiate(tempBoundary, new Vector3(720,0,0), Quaternion.Euler(0,0,90));
	}*/

	/*

	public static void SetHealthBar(float myHealth)
	{
		gameMaster.healthBar.transform.localScale = new Vector3(myHealth, gameMaster.healthBar.transform.localScale.y, gameMaster.healthBar.transform.localScale.z);
		gameMaster.healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), gameMaster.healthBar.transform.localScale.y, gameMaster.healthBar.transform.localScale.z);
	}

	public static void SetStaminaBar(float myStamina)
	{
		gameMaster.staminaBar.transform.localScale = new Vector3(myStamina, gameMaster.staminaBar.transform.localScale.y, gameMaster.staminaBar.transform.localScale.z);
		gameMaster.staminaBar.transform.localScale = new Vector3(Mathf.Clamp(myStamina,0f ,1f), gameMaster.staminaBar.transform.localScale.y, gameMaster.staminaBar.transform.localScale.z);
		//staminaBar.gameObject.transform.localScale = new Vector3(myStamina, staminaBar.gameObject.transform.localScale.y, staminaBar.gameObject.transform.localScale.z);
		//staminaBar.gameObject.transform.localScale = new Vector3(Mathf.Clamp(myStamina,0f ,1f), staminaBar.gameObject.transform.localScale.y, staminaBar.gameObject.transform.localScale.z);

	}

	public static void SetSVehicleHealthBar(float vehicleHealth)
	{
		gameMaster.vehicleHPBar.transform.localScale = new Vector3(vehicleHealth, gameMaster.vehicleHPBar.transform.localScale.y, gameMaster.vehicleHPBar.transform.localScale.z);
		gameMaster.vehicleHPBar.transform.localScale = new Vector3(Mathf.Clamp(vehicleHealth,0f ,1f), gameMaster.vehicleHPBar.transform.localScale.y, gameMaster.vehicleHPBar.transform.localScale.z);
	}*/

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.char1Life = char1Life;
		data.char3Life = char3Life;
		data.char3Att = char3Att;
		data.playerDamage = playerDamage;
		data.playerFireRate = playerFireRate;
		data.SMG = SMG;
		data.handGun = handGun;
		//SavePoint.reachedPoint = currentPoint;
		//Here will go the adjusted stats/abilities gained through progression.

		bf.Serialize (file, data);
		file.Close ();
		Debug.Log ("Saving!");
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			char1Life = data.char1Life;
			char3Life = data.char3Life;
			char3Att = data.char3Att;
			playerDamage = data.playerDamage;
			playerFireRate = data.playerFireRate;
			SMG = data.SMG;
			handGun = data.handGun;
			Debug.Log ("Stats loaded!");
			//currentPoint = SavePoint.reachedPoint;
			//Here will go the adjusted stats/abilities gained through progression.
		}
	}


	[System.Serializable]
	class PlayerData
	{
		public float char1Life;
		public float char3Life, char3Att;
		public bool SMG, handGun;
		public bool	fireHat;
		public int playerDamage = 25;
		public float playerFireRate;
		//public float attPower;
		//public Transform reachedPoint;
	}

}
