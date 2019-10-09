//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class Character02ArmorMain : MonoBehaviour {

//	public static Character02ArmorMain character01ArmorMain;

//	public float TestNumber = 100;

//	public Text HPText, MPText, AttackText, SpAttackText, DefenseText, SpeedText;

//	public GameObject HPBar, MPBar, AttackBar, SpAttackBar, DefBar, SpeedBar;

	
//	//float temp_HP, temp_MP, temp_Attack, temp_SpAttack, temp_Defense, temp_Speed;

//	//float weaponHPBoost, helmetHPBoost, bodyHPBoost, handsHPBoost, legsHPBoost;
//	//float weaponMPBoost, helmetMPBoost, bodyMPBoost, handsMPBoost, legsMPboost;
//	//float weaponATTBoost, helmetATTBoost, bodyATTBoost, handsATTBoost, legsATTBoost;
//	//float weaponSPATTBoost, helmetSPATTBoost, bodySPATTBoost, handsSPATTBoost, legsSPATTBoost;
//	//float weaponDEFBoost, helmetDEFBoost, bodyDEFBoost, handsDEFBoost, legsDEFBoost;
//	//float weaponSPDBoost, helmetSPDBoost, bodySPDBoost, handsSPDBoost, legsSPDBoost;


//	void Start()
//	{
		

//		ShowUpdatedStats ();

//		//DontDestroyOnLoad (gameObject);
//		//char1LifeText.text = "LIFE:" + GameMaster.gameMaster.base_char3Life.ToString();

//	}

//	//WEAPONS
//	public void Weapon01()
//	{
//		GameMaster.gameMaster.char02Weapons = GameMaster.Character02Weapons.Wep1;
//	}
//	public void Weapon02()
//	{
//		GameMaster.gameMaster.char02Weapons = GameMaster.Character02Weapons.Wep2;
//	}
//	public void Weapon03()
//	{
//		GameMaster.gameMaster.char02Weapons = GameMaster.Character02Weapons.Wep3;
//	}
//	public void Weapon04()
//	{
//		GameMaster.gameMaster.char02Weapons = GameMaster.Character02Weapons.Wep4;
//	}
//	public void Weapon05()
//	{
//		GameMaster.gameMaster.char02Weapons = GameMaster.Character02Weapons.Wep5;
//	}

//	//HELMETS
//	public void Helmet01()
//	{
//		GameMaster.gameMaster.char02Helmets = GameMaster.Character02Helmets.Helm1;
//	}
//	public void Helmet02()
//	{
//		GameMaster.gameMaster.char02Helmets = GameMaster.Character02Helmets.Helm2;
//	}
//	public void Helmet03()
//	{
//		GameMaster.gameMaster.char02Helmets = GameMaster.Character02Helmets.Helm3;
//	}
//	public void Helmet04()
//	{
//		GameMaster.gameMaster.char02Helmets = GameMaster.Character02Helmets.Helm4;
//	}
//	public void Helmet05()
//	{
//		GameMaster.gameMaster.char02Helmets = GameMaster.Character02Helmets.Helm5;
//	}

//	//BODY
//	public void Body01()
//	{
//		GameMaster.gameMaster.char02Body = GameMaster.Character02Body.Body1;
//	}
//	public void Body02()
//	{
//		GameMaster.gameMaster.char02Body = GameMaster.Character02Body.Body2;
//	}
//	public void Body03()
//	{
//		GameMaster.gameMaster.char02Body = GameMaster.Character02Body.Body3;
//	}
//	public void Body04()
//	{
//		GameMaster.gameMaster.char02Body = GameMaster.Character02Body.Body4;
//	}
//	public void Body05()
//	{
//		GameMaster.gameMaster.char02Body = GameMaster.Character02Body.Body5;
//	}

//	//HANDS
//	public void Hands01()
//	{
//		GameMaster.gameMaster.char02Hands = GameMaster.Character02Hands.Hands1;
//	}
//	public void Hands02()
//	{
//		GameMaster.gameMaster.char02Hands = GameMaster.Character02Hands.Hands2;
//	}
//	public void Hands03()
//	{
//		GameMaster.gameMaster.char02Hands = GameMaster.Character02Hands.Hands3;
//	}
//	public void Hands04()
//	{
//		GameMaster.gameMaster.char02Hands = GameMaster.Character02Hands.Hands4;
//	}
//	public void Hands05()
//	{
//		GameMaster.gameMaster.char02Hands = GameMaster.Character02Hands.Hands5;
//	}

//	//LEGS
//	public void Legs01()
//	{
//		GameMaster.gameMaster.char02Legs = GameMaster.Character02Legs.Legs1;
//	}
//	public void Legs02()
//	{
//		GameMaster.gameMaster.char02Legs = GameMaster.Character02Legs.Legs2;
//	}
//	public void Legs03()
//	{
//		GameMaster.gameMaster.char02Legs = GameMaster.Character02Legs.Legs3;
//	}
//	public void Legs04()
//	{
//		GameMaster.gameMaster.char02Legs = GameMaster.Character02Legs.Legs4;
//	}
//	public void Legs05()
//	{
//		GameMaster.gameMaster.char02Legs = GameMaster.Character02Legs.Legs5;
//	}

//	//RANGED
//	public void Ranged01()
//	{
//		GameMaster.gameMaster.char02Ranged = GameMaster.Character02Ranged.Ranged1;
//	}
//	public void Ranged02()
//	{
//		GameMaster.gameMaster.char02Ranged = GameMaster.Character02Ranged.Ranged2;
//	}
//	public void Ranged03()
//	{
//		GameMaster.gameMaster.char02Ranged = GameMaster.Character02Ranged.Ranged3;
//	}
//	public void Ranged04()
//	{
//		GameMaster.gameMaster.char02Ranged = GameMaster.Character02Ranged.Ranged4;
//	}
//	public void Ranged05()
//	{
//		GameMaster.gameMaster.char02Ranged = GameMaster.Character02Ranged.Ranged5;
//	}


//    public void LoadNextScene()
//    {
//        Application.LoadLevel("TestScene002");
//    }


//    public void ShowUpdatedStats()
//	{
//		HPText.text = "HP:" + GameMaster.gameMaster.curHP.ToString();
//		MPText.text = "MP:" + GameMaster.gameMaster.curMP.ToString ();
//		AttackText.text = "Attack:" + GameMaster.gameMaster.curAttack.ToString ();
//		SpAttackText.text = "Special:" + GameMaster.gameMaster.curSpAttack.ToString ();
//		DefenseText.text = "Defense:" + GameMaster.gameMaster.curDefense.ToString ();
//		SpeedText.text = "Speed:" + GameMaster.gameMaster.curSpeed.ToString ();
//	}

//	void Update()
//	{
//        if (Input.GetButton("Cancel"))
//        {
//            Application.LoadLevel("CharacterSelect");
//        }

//        float calc_HP = GameMaster.gameMaster.curHP / 200;
//		SetHPMeter (calc_HP);

//		float calc_MP = GameMaster.gameMaster.curMP / 200;
//		SetMPMeter (calc_MP);

//		float calc_Attack = GameMaster.gameMaster.curAttack / 100;
//		SetAttMeter (calc_Attack);

//		float calc_SpAttack = GameMaster.gameMaster.curSpAttack / 100;
//		SetSpAttackMeter (calc_SpAttack);

//		float calc_Defense = GameMaster.gameMaster.curDefense / 100;
//		SetDefenseMeter (calc_Defense);

//		float calc_Speed = GameMaster.gameMaster.curSpeed / 10;
//		SetSpeedMeter (calc_Speed);

//        ShowUpdatedStats ();
//	}


//	public void SetHPMeter(float myHP)
//	{
//		HPBar.transform.localScale = new Vector3(myHP, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
//		HPBar.transform.localScale = new Vector3(Mathf.Clamp(myHP,0f ,1f), HPBar.transform.localScale.y, HPBar.transform.localScale.z);
//	}
//	public void SetMPMeter(float myMP)
//	{
//		MPBar.transform.localScale = new Vector3(myMP, MPBar.transform.localScale.y, MPBar.transform.localScale.z);
//		MPBar.transform.localScale = new Vector3(Mathf.Clamp(myMP,0f ,1f), MPBar.transform.localScale.y, MPBar.transform.localScale.z);
//	}
//	public void SetAttMeter(float myAtt)
//	{
//		AttackBar.transform.localScale = new Vector3 (myAtt, AttackBar.transform.localScale.y, AttackBar.transform.localScale.z);
//		AttackBar.transform.localScale = new Vector3(Mathf.Clamp(myAtt,0f ,1f), AttackBar.transform.localScale.y, AttackBar.transform.localScale.z);
//	}
//	public void SetSpAttackMeter(float mySpAtt)
//	{
//		SpAttackBar.transform.localScale = new Vector3 (mySpAtt, SpAttackBar.transform.localScale.y, SpAttackBar.transform.localScale.z);
//		SpAttackBar.transform.localScale = new Vector3(Mathf.Clamp(mySpAtt,0f ,1f), SpAttackBar.transform.localScale.y, SpAttackBar.transform.localScale.z);
//	}
//	public void SetDefenseMeter(float myDef)
//	{
//		DefBar.transform.localScale = new Vector3 (myDef, DefBar.transform.localScale.y, DefBar.transform.localScale.z);
//		DefBar.transform.localScale = new Vector3(Mathf.Clamp(myDef,0f ,1f), DefBar.transform.localScale.y, DefBar.transform.localScale.z);
//	}
//	public void SetSpeedMeter(float mySpeed)
//	{
//		SpeedBar.transform.localScale = new Vector3 (mySpeed, SpeedBar.transform.localScale.y, SpeedBar.transform.localScale.z);
//		SpeedBar.transform.localScale = new Vector3(Mathf.Clamp(mySpeed,0f ,1f), SpeedBar.transform.localScale.y, SpeedBar.transform.localScale.z);
//	}
//}
