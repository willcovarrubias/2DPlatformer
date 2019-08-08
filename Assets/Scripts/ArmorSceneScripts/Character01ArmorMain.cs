//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class Character01ArmorMain : MonoBehaviour {

//	public static Character01ArmorMain character01ArmorMain;

//	public Text HPText, MPText, AttackText, SpAttackText, DefenseText, SpeedText;

//	public GameObject HPBar, MPBar, AttackBar, SpAttackBar, DefBar, SpeedBar;
    	


//    void Start()
//    {
//        ShowUpdatedStats();
//    }

//	//WEAPONS
//	public void Weapon01()
//	{
//		GameMaster.gameMaster.char01Weapons = GameMaster.Character01Weapons.Wep1;
//	}
//	public void Weapon02()
//	{
//		GameMaster.gameMaster.char01Weapons = GameMaster.Character01Weapons.Wep2;
//	}
//	public void Weapon03()
//	{
//		GameMaster.gameMaster.char01Weapons = GameMaster.Character01Weapons.Wep3;
//	}
//	public void Weapon04()
//	{
//		GameMaster.gameMaster.char01Weapons = GameMaster.Character01Weapons.Wep4;
//	}
//	public void Weapon05()
//	{
//		GameMaster.gameMaster.char01Weapons = GameMaster.Character01Weapons.Wep5;
//	}

//    //RANGED
//    public void Ranged01()
//    {
//        GameMaster.gameMaster.char01Ranged = GameMaster.Character01Ranged.Ranged1;
//    }
//    public void Ranged02()
//    {
//        GameMaster.gameMaster.char01Ranged = GameMaster.Character01Ranged.Ranged2;
//    }
//    public void Ranged03()
//    {
//        GameMaster.gameMaster.char01Ranged = GameMaster.Character01Ranged.Ranged3;
//    }
//    public void Ranged04()
//    {
//        GameMaster.gameMaster.char01Ranged = GameMaster.Character01Ranged.Ranged4;
//    }
//    public void Ranged05()
//    {
//        GameMaster.gameMaster.char01Ranged = GameMaster.Character01Ranged.Ranged5;
//    }

//    //HELMETS
//    public void Helmet01()
//	{
//		GameMaster.gameMaster.char01Helmets = GameMaster.Character01Helmets.Helm1;
//	}
//	public void Helmet02()
//	{
//		GameMaster.gameMaster.char01Helmets = GameMaster.Character01Helmets.Helm2;
//	}
//	public void Helmet03()
//	{
//		GameMaster.gameMaster.char01Helmets = GameMaster.Character01Helmets.Helm3;
//	}
//	public void Helmet04()
//	{
//		GameMaster.gameMaster.char01Helmets = GameMaster.Character01Helmets.Helm4;
//	}
//	public void Helmet05()
//	{
//		GameMaster.gameMaster.char01Helmets = GameMaster.Character01Helmets.Helm5;
//	}

//	//BODY
//	public void Body01()
//	{
//        //GameMaster.gameMaster.char01Body = GameMaster.Character01Body.Body1;
//        GameMaster.gameMaster.char01Body = GameMaster.Character01Body.Body1;
//    }
//	public void Body02()
//	{
//		GameMaster.gameMaster.char01Body = GameMaster.Character01Body.Body2;
//	}
//	public void Body03()
//	{
//		GameMaster.gameMaster.char01Body = GameMaster.Character01Body.Body3;
//	}
//	public void Body04()
//	{
//		GameMaster.gameMaster.char01Body = GameMaster.Character01Body.Body4;
//	}
//	public void Body05()
//	{
//		GameMaster.gameMaster.char01Body = GameMaster.Character01Body.Body5;
//	}

//	//HANDS
//	public void Hands01()
//	{
//		GameMaster.gameMaster.char01Hands = GameMaster.Character01Hands.Hands1;
//	}
//	public void Hands02()
//	{
//		GameMaster.gameMaster.char01Hands = GameMaster.Character01Hands.Hands2;
//	}
//	public void Hands03()
//	{
//		GameMaster.gameMaster.char01Hands = GameMaster.Character01Hands.Hands3;
//	}
//	public void Hands04()
//	{
//		GameMaster.gameMaster.char01Hands = GameMaster.Character01Hands.Hands4;
//	}
//	public void Hands05()
//	{
//		GameMaster.gameMaster.char01Hands = GameMaster.Character01Hands.Hands5;
//	}

//	//LEGS
//	public void Legs01()
//	{
//		GameMaster.gameMaster.char01Legs = GameMaster.Character01Legs.Legs1;
//	}
//	public void Legs02()
//	{
//		GameMaster.gameMaster.char01Legs = GameMaster.Character01Legs.Legs2;
//	}
//	public void Legs03()
//	{
//		GameMaster.gameMaster.char01Legs = GameMaster.Character01Legs.Legs3;
//	}
//	public void Legs04()
//	{
//		GameMaster.gameMaster.char01Legs = GameMaster.Character01Legs.Legs4;
//	}
//	public void Legs05()
//	{
//		GameMaster.gameMaster.char01Legs = GameMaster.Character01Legs.Legs5;
//	}

//    //RANGED
//    public void Accesssory01()
//    {
//        GameMaster.gameMaster.char01Accessory = GameMaster.Character01Accessory.Accessory1;
//    }
//    public void Accesssory02()
//    {
//        GameMaster.gameMaster.char01Accessory = GameMaster.Character01Accessory.Accessory2;
//    }
//    public void Accesssory03()
//    {
//        GameMaster.gameMaster.char01Accessory = GameMaster.Character01Accessory.Accessory3;
//    }
//    public void Accesssory04()
//    {
//        GameMaster.gameMaster.char01Accessory = GameMaster.Character01Accessory.Accessory4;
//    }
//    public void Accesssory05()
//    {
//        GameMaster.gameMaster.char01Accessory = GameMaster.Character01Accessory.Accessory5;
//    }




//    public void LoadNextScene()
//	{
//		Application.LoadLevel ("TestScene002");
//	}

//	public void ShowUpdatedStats()
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
            

//        float calc_HP = GameMaster.gameMaster.curHP / 1000f;
//		SetHPMeter (calc_HP);

//		float calc_MP = GameMaster.gameMaster.curMP / 1000f;
//		SetMPMeter (calc_MP);

//		float calc_Attack = GameMaster.gameMaster.curAttack / 1000f;
//		SetAttMeter (calc_Attack);

//		float calc_SpAttack = GameMaster.gameMaster.curSpAttack / 1000f;
//		SetSpAttackMeter (calc_SpAttack);

//		float calc_Defense = GameMaster.gameMaster.curDefense / 1000f;
//		SetDefenseMeter (calc_Defense);

//		float calc_Speed = GameMaster.gameMaster.curSpeed / 1000f;
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
