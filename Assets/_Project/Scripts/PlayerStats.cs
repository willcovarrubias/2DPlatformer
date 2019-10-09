using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerStatsToDisplay : MonoBehaviour {

	public static PlayerStatsToDisplay playerStats;

	float max_Health, max_Stamina, max_Mana;
	public static float cur_Health, cur_Stamina, cur_Mana;


	//public static bool fatigued = false;
	bool isdashing = false;
	public static float attack, defense;
	GameObject healthBar, manaBar, staminaBar;
	public Text LifeText;

	float fatigueResetTimer = 0f;
	float fatigueCD = 1f;

	//ArmorIndex armorIndex;

	void Awake(){
		//max_Health = GameMaster.gameMaster.base_char1Life;
		//max_Stamina = GameMaster.gameMaster.base_char1End;
		//max_Mana = GameMaster.gameMaster.base_char1Mana;

		cur_Health = max_Health;
		cur_Stamina = max_Stamina;
		cur_Mana = max_Mana;
	
	}
	// Use this for initialization
	void Start () {
		//armorIndex = GetComponent<ArmorIndex>();

		healthBar = GameObject.FindGameObjectWithTag("PlayerHealth").gameObject;
		manaBar = GameObject.FindGameObjectWithTag("PlayerMana").gameObject;
		//staminaBar = GameObject.FindGameObjectWithTag("PlayerStamina").gameObject;



		if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character1) {
			//Instantiate (character1, transform.position, transform.rotation);
			CalculateChar01Stats();

		}
		if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character2) {
			//Instantiate (character2, transform.position, transform.rotation);
			//defense = GameMaster.gameMaster.base_char2Def;
			//attack = GameMaster.gameMaster.base_char2Att;
		}
		if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character3) {
			//Instantiate (character3, transform.position, transform.rotation);
		//	defense = GameMaster.gameMaster.base_char3Def;
		}

        //Debug.Log(GameMaster.gameMaster.curHP);
        //Debug.Log(GameMaster.gameMaster.curMP);
        //Debug.Log(GameMaster.gameMaster.curAttack);
        //Debug.Log(GameMaster.gameMaster.curSpAttack);
        //Debug.Log(GameMaster.gameMaster.curDefense);
        //Debug.Log(GameMaster.gameMaster.curSpeed);



    }

    void CalculateChar01Stats()
	{
		//defense = GameMaster.gameMaster.base_char1Def;
		//attack = GameMaster.gameMaster.base_char1Att;


		if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep1) 
		//{
			attack += 1;
		
		//}
		if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep2) 
		//{
			attack += 10;

        //}

       
    }

	void Update()
	{
		float calc_Health = cur_Health / max_Health;
		float calc_Stamina = cur_Stamina / max_Stamina;
		SetHealthBar (calc_Health);
		//SetStaminaBar (calc_Stamina);




		/*if (cur_Stamina <= 0) {
			fatigued = true;
			fatigueResetTimer = fatigueCD;

		}

		if (fatigued) 
		{
			if (fatigueResetTimer > 0) {
				fatigueResetTimer -= Time.deltaTime;
			} 
			else 
			{
				fatigued = false;
				cur_Stamina++;
			}
		}*/
	}


	
	public void SetHealthBar(float myHealth)
	{
		healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	public void SetStaminaBar(float myStamina)
	{
		staminaBar.transform.localScale = new Vector3(myStamina, staminaBar.transform.localScale.y, staminaBar.transform.localScale.z);
		staminaBar.transform.localScale = new Vector3(Mathf.Clamp(myStamina,0f ,1f), staminaBar.transform.localScale.y, staminaBar.transform.localScale.z);
	}

	void DamagePlayer (float damage)
	{

		cur_Health -= damage - defense;

	}
	void OnCollisionEnter2D (Collision2D other)
	{

		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log ("Enemy ran into me!");
			DamagePlayer(20f);
			//Instantiate(BloodSplat, other.transform.position, other.transform.rotation);
			//float calc_Health = cur_Health / GameMaster.gameMaster.playerHealth;
			//GameMaster.SetHealthBar(calc_Health);
		}		
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "LifeBooster")
		{
			Debug.Log ("Picked up an HP item!");
			max_Health += 20;
			cur_Health = max_Health;
			Debug.Log("LIFE:" + max_Health);
			//Instantiate(BloodSplat, other.transform.position, other.transform.rotation);
			//float calc_Health = cur_Health / GameMaster.gameMaster.playerHealth;
			//GameMaster.SetHealthBar(calc_Health);
		}		
	}



	public IEnumerator StaminaPenalty()
	{
		yield return new WaitForSeconds(2);
		cur_Stamina = 2;
		//fatigued = false;
	}

}
