using UnityEngine;
using System.Collections;

public class Enemy_Main : MonoBehaviour {



	[System.Serializable]
	public class EnemyStats {
	
		public int Health = 100;
	}

	public EnemyStats stats = new EnemyStats();

	void DamageEnemy (int damage)
	{

		//Transform enemyToKill = Enemy.enemy.transform;
		stats.Health -= damage;
	//	if(stats.Health <= 0)
	//	{
	//		Destroy(gameObject);
			//Enemy.EnemyKill();
			//GameMaster.KillEnemy(this.gameObject);
			//Destroy(Enemy.enemyToDie.gameObject);
	//		Debug.Log ("Pew pew, This guy is dead!");
	//	}
	}


	void Update()
	{
		if(stats.Health <= 0)
		{
            GiveExp();
			Destroy(gameObject);
		}


	}

 

	void OnCollisionEnter2D (Collision2D other)
	{

		if (other.gameObject.tag == "MeleeWeapon")
		{
            //GameMaster.gameMaster.waveGoing = false;

            //Camera2DFollow.xPosRestriction = 3;
            //Camera2DFollow.xPosRestrictionRight = 0;
            Debug.Log("Collided with Player's weapon!");
            DamageEnemy(GameMaster.gameMaster.curAttack);
        }

        if (other.gameObject.tag == "PlayerProjectile")
        {
            DamageEnemy(GameMaster.gameMaster.curAttack);
            Debug.Log("Collided with Player's weapon!");
        }
    }

	

    //Char01-- 0-34:
    //00= Weapon01      01= Weapon02        02= Weapon03        03= Weapon04        04= Weapon05
    //05= Ranged01      06= Ranged02        07= Ranged03        08= Ranged04        09= Ranged05
    //10= Helmet01      11= Helmet02        12= Helmet03        13= Helmet04        14= Helmet05
    //15= Body01        16= Body02          17= Body03          18= Body04          19= Body05
    //20= Hands01       21= Hands02         22= Hands03         23= Hands04         24= Hands05
    //25= Legs01        26= Legs02          27= Legs03          28= Legs04          29= Legs05
    //30= Accessory01   31= Accessory02     32= Accessory03     33= Accessory04     34= Accessory05
    void GiveExp()
    {
        int characterIndexOffset;

        if(GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character1)
        {
            characterIndexOffset = 0;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Weapons + characterIndexOffset] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Ranged + characterIndexOffset + 5] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Helmets + characterIndexOffset + 10] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Body + characterIndexOffset + 15] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Hands + characterIndexOffset + 20] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Legs + characterIndexOffset + 25] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Accessory + characterIndexOffset + 30] += 5;

            Debug.Log("Gave EXP to: " + GameMaster.gameMaster.char01Weapons + ". And also to: " + GameMaster.gameMaster.char01Ranged + 
                "\n Here's the EXP for the weapon:" + GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Weapons + characterIndexOffset]);
            //GameMaster.gameMaster.allArmorExp[(int)(GameMaster.gameMaster.characterChosen + GameMaster.gameMaster.char01Weapons + characterIndexOffset)]++;

        }

        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character2)
        {
            characterIndexOffset = 35;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char02Weapons + characterIndexOffset] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char02Ranged + characterIndexOffset + 5] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char02Helmets + characterIndexOffset + 10] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char02Body + characterIndexOffset + 15] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char02Hands + characterIndexOffset + 20] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char02Legs + characterIndexOffset + 25] += 5;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char02Accessory + characterIndexOffset + 30] += 5;


        }
    }

}
