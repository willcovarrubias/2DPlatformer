using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;



public class GameMaster : MonoBehaviour {

	public static GameMaster gameMaster;
	//public GameObject PlayerToSpawn;
    public CharacterStatsMain characterStatsMain;
	
	public Transform PlayerSpawnPoint;

    //public int maxHP { get; set; }
    //public int curHP { get; set; }
    //public int maxMP { get; set; }
    //public int curMP { get; set; }
    //public int curAttack { get; set; }
    //public int curSpAttack { get; set; }
    //public int curDefense { get; set; }
    //public int curSpeed { get; set; }

    //public int character01Life { get; set; }
    //public int character01Mana { get; set; }
    //public int character01Attack { get; set; }
    //TODO: Put all unlocks here.
    //Character Unlocks:
    public bool[] chars_Unlocked = new bool[21];

    //ArmorUnlocks.
    public bool[] armorUnlocks = new bool[70];
    public bool[] hasUIUnlockAnimationPlayed = new bool[70];
        
    //Armor and Weapon Unlocks:
    //public bool[] char01statUnlocks = new bool[32];
    //public bool[] char02statUnlocks = new bool[32];
    //public bool[] char03statUnlocks = new bool[32];
    //public bool[] char04statUnlocks = new bool[32];
    //public bool[] char05statUnlocks = new bool[32];
    //public bool[] char06statUnlocks = new bool[32];
    //public bool[] char07statUnlocks = new bool[32];
    //public bool[] char08statUnlocks = new bool[32];
    //public bool[] char09statUnlocks = new bool[32];
    //public bool[] char10statUnlocks = new bool[32];
    //00=  HP02Unlock, 01= MP02Unlock, 02= Att02Unlock, 03= SpAtt02Unlock, 04= Def02Unlock, 05= Spd02Unlock,
    //06=  HP03Unlock, 07= MP03Unlock, 08= Att03Unlock, 09= SpAtt03Unlock, 10= Def03Unlock, 11= Spd03Unlock,
    //12=  HP04Unlock, 13= MP04Unlock, 14= Att04Unlock, 15= SpAtt04Unlock, 16= Def04Unlock, 17= Spd04Unlock,
    //18=  HP05Unlock, 19= MP05Unlock, 20= Att05Unlock, 21= SpAtt05Unlock, 22= Def05Unlock, 23 =Spd05Unlock;
    //24= Perk01, 25= Perk02, 26= Perk03, 27= Perk04, 28= Perk05, 29= Perk06, 30= Perk07, 31= Perk08;


    //Exp towards armor:
    /*public float char01Wep01xp = 0, char01Wep02xp = 0, char01Wep03xp = 0, char01Wep04xp = 0, char01Wep05xp = 0,
                 char01Ranged01xp = 0, char01Ranged02xp = 0, char01Ranged03xp = 0, char01Ranged04xp = 0, char01Ranged05xp = 0,
                 char01Helmet01xp = 0, char01Helmet02xp = 0, char01Helmet03xp = 0, char01Helmet04xp = 0, char01Helmet05xp = 0,
                 char01Body01xp = 0, char01Body02xp = 0, char01Body03xp = 0, char01Body04xp = 0, char01Body05xp = 0,
                 char01Hands01xp = 0, char01Hands02xp = 0, char01Hands03xp = 0, char01Hands04xp = 0, char01Hands05xp = 0,
                 char01Legs01xp = 0, char01Legs02xp = 0, char01Legs03xp = 0, char01Legs04xp = 0, char01Legs05xp = 0,
                 char01Accessory01xp = 0, char01Accessory02xp = 0, char01Accessory03xp = 0, char01Accessory04xp = 0, char01Accessory05xp = 0;*/

  
    public int[] allArmorExp = new int[70]; //This needs to be (35 * numberofCharacters)
    //Char01-- 0-34:
    //00= Weapon01      01= Weapon02        02= Weapon03        03= Weapon04        04= Weapon05
    //05= Ranged01      06= Ranged02        07= Ranged03        08= Ranged04        09= Ranged05
    //10= Helmet01      11= Helmet02        12= Helmet03        13= Helmet04        14= Helmet05
    //15= Body01        16= Body02          17= Body03          18= Body04          19= Body05
    //20= Hands01       21= Hands02         22= Hands03         23= Hands04         24= Hands05
    //25= Legs01        26= Legs02          27= Legs03          28= Legs04          29= Legs05
    //30= Accessory01   31= Accessory02     32= Accessory03     33= Accessory04     34= Accessory05



    //Booleans to check if buttons already pressed:
    public bool[] char01_buttonsAlreadyPressed = new bool[30];
   //00=char01_HP01, 01=char01_MP01, 02=char01_Att01, 03=char01_SpAtt01, 04=char01_Def01, 05=char01_Spd01,
   //06=char01_HP02, 07=char01_MP02, 08=char01_Att02, 09=char01_SpAtt02, 10=char01_Def02, 11=char01_Spd02,
   //12=char01_HP03, 13=char01_MP03, 14=char01_Att03, 15=char01_SpAtt03, 16=char01_Def03, 17=char01_Spd03,
   //18=char01_HP04, 19=char01_MP04, 20=char01_Att04, 21=char01_SpAtt04, 22=char01_Def04, 23=char01_Spd04,
   //24=char01_HP05, 25=char01_MP05, 26=char01_Att05, 27=char01_SpAtt05, 28=char01_Def05, 29=char01_Spd05;

    //This is the list for Active Items:
    public enum CurrentActiveItem{ activeItem001, activeItem002, activeItem003, activeItem004}
    public CurrentActiveItem currentActiveItem;
    //public bool activeItem001isOn, activeItem002isOn, activeItem003isOn, activeItem004isOn;

    public int roomClears;
	public int roomCount;
            
    public enum CharacterChosen
    {
        Character1, Character2, Character3, Character4, Character5, Character6, Character7, Character8, Character9, Character10,
        Character11, Character12, Character13, Character14, Character15, Character16, Character17, Character18, Character19, Character20
    }
    public CharacterChosen characterChosen;


    //Character1
	public enum Character01Weapons{Wep1, Wep2, Wep3, Wep4, Wep5}
	public Character01Weapons char01Weapons;

    public enum Character01Ranged { Ranged1, Ranged2, Ranged3, Ranged4, Ranged5 }
    public Character01Ranged char01Ranged;

    public enum Character01Helmets{Helm1, Helm2, Helm3, Helm4, Helm5}
	public Character01Helmets char01Helmets;

	public enum Character01Body{Body1, Body2, Body3, Body4, Body5}
	public Character01Body char01Body;

	public enum Character01Hands{Hands1, Hands2, Hands3, Hands4, Hands5}
	public Character01Hands char01Hands;

	public enum Character01Legs{Legs1, Legs2, Legs3, Legs4, Legs5}
	public Character01Legs  char01Legs;

    public enum Character01Accessory {Accessory1, Accessory2, Accessory3, Accessory4, Accessory5}
    public Character01Accessory char01Accessory;


    //Character2
    public enum Character02Weapons { Wep1, Wep2, Wep3, Wep4, Wep5 }
    public Character02Weapons char02Weapons;

    public enum Character02Ranged { Ranged1, Ranged2, Ranged3, Ranged4, Ranged5 }
    public Character02Ranged char02Ranged;

    public enum Character02Helmets { Helm1, Helm2, Helm3, Helm4, Helm5 }
    public Character02Helmets char02Helmets;

    public enum Character02Body { Body1, Body2, Body3, Body4, Body5 }
    public Character02Body char02Body;

    public enum Character02Hands { Hands1, Hands2, Hands3, Hands4, Hands5 }
    public Character02Hands char02Hands;

    public enum Character02Legs { Legs1, Legs2, Legs3, Legs4, Legs5 }
    public Character02Legs char02Legs;

    public enum Character02Accessory { Accessory1, Accessory2, Accessory3, Accessory4, Accessory5 }
    public Character02Accessory char02Accessory;


    //Character3
    public enum Character03Weapons { Wep1, Wep2, Wep3, Wep4, Wep5 }
    public Character03Weapons char03Weapons;

    public enum Character03Ranged { Ranged1, Ranged2, Ranged3, Ranged4, Ranged5 }
    public Character03Ranged char03Ranged;

    public enum Character03Helmets { Helm1, Helm2, Helm3, Helm4, Helm5 }
    public Character03Helmets char03Helmets;

    public enum Character03Body { Body1, Body2, Body3, Body4, Body5 }
    public Character03Body char03Body;

    public enum Character03Hands { Hands1, Hands2, Hands3, Hands4, Hands5 }
    public Character03Hands char03Hands;

    public enum Character03Legs { Legs1, Legs2, Legs3, Legs4, Legs5 }
    public Character03Legs char03Legs;


    //Character4
    public enum Character04Weapons { Wep1, Wep2, Wep3, Wep4, Wep5 }
    public Character04Weapons char04Weapons;

    public enum Character04Ranged { Ranged1, Ranged2, Ranged3, Ranged4, Ranged5 }
    public Character04Ranged char04Ranged;

    public enum Character04Helmets { Helm1, Helm2, Helm3, Helm4, Helm5 }
    public Character04Helmets char04Helmets;

    public enum Character04Body { Body1, Body2, Body3, Body4, Body5 }
    public Character04Body char04Body;

    public enum Character04Hands { Hands1, Hands2, Hands3, Hands4, Hands5 }
    public Character04Hands char04Hands;

    public enum Character04Legs { Legs1, Legs2, Legs3, Legs4, Legs5 }
    public Character04Legs char04Legs;


    //Character5
    public enum Character05Weapons { Wep1, Wep2, Wep3, Wep4, Wep5 }
    public Character05Weapons char05Weapons;

    public enum Character05Ranged { Ranged1, Ranged2, Ranged3, Ranged4, Ranged5 }
    public Character05Ranged char05Ranged;

    public enum Character05Helmets { Helm1, Helm2, Helm3, Helm4, Helm5 }
    public Character05Helmets char05Helmets;

    public enum Character05Body { Body1, Body2, Body3, Body4, Body5 }
    public Character05Body char05Body;

    public enum Character05Hands { Hands1, Hands2, Hands3, Hands4, Hands5 }
    public Character05Hands char05Hands;

    public enum Character05Legs { Legs1, Legs2, Legs3, Legs4, Legs5 }
    public Character05Legs char05Legs;


    //GameObject healthBar; //the one that moves.
    //GameObject staminaBar;
    //GameObject vehicleHPBar;


    //Enemy Spawning variables here:
    public GameObject tempBoundary;
	public bool waveGoing;
	GameObject[] tempBoundariesToDestroy;
	GameObject enemy;

    //private bool isPaused = false;

    public bool isPaused = false;
    public bool inACutscene = false;
    public bool inABossFight = false;
    
    void Update()
	{

        //if ((Mathf.Abs (Input.GetAxis ("Horizontal")) > 0) || (Mathf.Abs (Input.GetAxis ("Vertical")) > 0)) 

        //CursorLockMode.Locked = true;

        //else if((Mathf.Abs (Input.GetAxis ("Mouse X")) > 0) || (Mathf.Abs (Input.GetAxis ("Mouse Y")) > 0)) 
        //	Cursor.visible = true;
        //if(waveGoing)
        //{

        //enemy = GameObject.FindGameObjectWithTag("Enemy");

        //EndWave();
        //Debug.Log(activeItem001isOn);
        //Debug.Log(activeItem002isOn);
        //Debug.Log(activeItem003isOn);
        //Debug.Log(activeItem004isOn);

        //CheckForHealthBars();
        
    }


	public void Awake()
	{
		//Load ();

		if (gameMaster == null) 
		{
			DontDestroyOnLoad (gameObject);
			gameMaster = this;
		} 
		else if (gameMaster != this) 
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
        PlayerPrefs.SetInt("CharacterSelected", 0);

        //GameMaster.gameMaster.handGun = true;

        //Instantiate (PlayerToSpawn, PlayerSpawnPoint.position, PlayerSpawnPoint.rotation);
        //CheckForHealthBars();
        //Debug.Log("Life: " + base_char1Life + " Attack: " + base_char3Att);
        //Debug.Log ("Attack:", char3Att);
        //"Defense:", char3Def, "Endurance:", char3End, "Agility:", char3Agi);
        //Cursor.visible = false;

        //char01statUnlocks[24] = true;

       // Debug.Log(char01ArmorExp[0]);
       // Debug.Log(char01ArmorExp[25]);

	}

	/*

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
	}*/

	void EndWave()
	{
		Debug.Log ("WAVE ENDING!");
		waveGoing = false;

		//Camera2DFollow.xPosRestrictionRight = 450;
		//Camera2DFollow.xPosRestriction = 0;
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
		gameMaster.health
        form.localScale = new Vector3(myHealth, gameMaster.healthBar.transform.localScale.y, gameMaster.healthBar.transform.localScale.z);
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


    private void OnGUI()
    {
        GUI.Label(new Rect(20, 10, 100, 40), "Weapon EXP: " + GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Weapons]);
        GUI.Label(new Rect(140, 10, 100, 40), "Ranged EXP: " + GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Ranged + 5]);
        //GUI.Label(new Rect(260, 10, 100, 40), "Character 03 unlocked: " + chars_Unlocked[2]);
    }

    public void Save()
	{
		//BinaryFormatter bf = new BinaryFormatter ();
		//FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
       
		//UpdatedPlayerData data = new UpdatedPlayerData ();
		////data.Base01Life = character01Life;
  //      data.chars_Unlocked = chars_Unlocked;
  //      data.allArmorExp = allArmorExp;
                
		//bf.Serialize (file, data);
		//file.Close ();
		//Debug.Log ("Saving to: " + Application.persistentDataPath + "/playerInfo.dat");
	}
	
	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			//BinaryFormatter bf = new BinaryFormatter();
			//FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			//UpdatedPlayerData data = (UpdatedPlayerData)bf.Deserialize(file);

   //         file.Close();

   //         character01Life = data.Base01Life;
   //         chars_Unlocked = data.chars_Unlocked;
   //         allArmorExp = data.allArmorExp;
            
   //         Debug.Log ("Stats loaded!");
			
		}
	}
}

[Serializable]
class UpdatedPlayerData
{
 
    //Use this to keep track of what weapons and armor have been unlocked for each character.


    public int base02Life = 500, base02Mana = 100, base02Att = 100,  base02SpAtt = 100, base02Def = 100, base02Speed = 100;
    
    public bool[] chars_Unlocked = new bool[21];
    public int[] allArmorExp = new int[70];

    public bool char01HPUnlock01 = false;

    private int base01Life;
    private int base01Mana;
    private int base01Att;
    private int base01SpAtt;
    private int base01Def;
    private int base01Speed;

    public int Base01Life
    {
        get
        {
            return base01Life;
        }

        set
        {
            base01Life = value;
        }
    }

    public int Base01Mana
    {
        get
        {
            return base01Mana;
        }

        set
        {
            base01Mana = value;
        }
    }

    public int Base01Att
    {
        get
        {
            return base01Att;
        }

        set
        {
            base01Att = value;
        }
    }

    public int Base01SpAtt
    {
        get
        {
            return base01SpAtt;
        }

        set
        {
            base01SpAtt = value;
        }
    }

    public int Base01Def
    {
        get
        {
            return base01Def;
        }

        set
        {
            base01Def = value;
        }
    }

    public int Base01Speed
    {
        get
        {
            return base01Speed;
        }

        set
        {
            base01Speed = value;
        }
    }
}


