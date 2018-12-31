using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CharacterStatsMain : MonoBehaviour
{


    /// <summary>
    /// This class will hold all the base starting stats for all characters. Whenever a player is spawned, its stats will be calculated
    /// in the following way: 
    /// stats = base stats (from this class) + updated stats (from UpdatedPlayerStats in GameManager).
    /// </summary>
    /// 
    CharacterStatsMain characterStatsMain;
    ArmorManager armorManager;
    UpdatedPlayerData updatedPlayerData;
    //public int id;
    //public Text statsText;
    //public int characterNumber;
    public int thisCharactersID;


    //public int baseLife, baseMana, baseAttack, baseMagicalAtt, baseDefense, baseSpeed;
    private int lifeFromWeapon { get; set; }
    private int lifeFromRanged { get; set; }
    private int lifeFromHelm { set; get; }
    private int lifeFromBody { set; get; }
    private int lifeFromHands { get; set; }
    private int lifeFromLegs { set; get; }
    private int lifeFromAccessory { set; get; }

    private int manaFromWeapon { get; set; }
    private int manaFromRanged { get; set; }
    private int manaFromHelm { set; get; }
    private int manaFromBody { set; get; }
    private int manaFromHands { get; set; }
    private int manaFromLegs { set; get; }
    private int manaFromAccessory { set; get; }

    private int attackFromWeapon { get; set; }
    private int attackFromRanged { get; set; }
    private int attackFromHelm { set; get; }
    private int attackFromBody { set; get; }
    private int attackFromHands { get; set; }
    private int attackFromLegs { set; get; }
    private int attackFromAccessory { set; get; }

    private int specialAttackFromWeapon { get; set; }
    private int specialAttackFromRanged { get; set; }
    private int specialAttackFromHelm { set; get; }
    private int specialAttackFromBody { set; get; }
    private int specialAttackFromHands { get; set; }
    private int specialAttackFromLegs { set; get; }
    private int specialAttackFromAccessory { set; get; }

    private int defenseFromWeapon { get; set; }
    private int defenseFromRanged { get; set; }
    private int defenseFromHelm { set; get; }
    private int defenseFromBody { set; get; }
    private int defenseFromHands { get; set; }
    private int defenseFromLegs { set; get; }
    private int defenseFromAccessory { set; get; }

    private int speedFromWeapon { get; set; }
    private int speedFromRanged { get; set; }
    private int speedFromHelm { set; get; }
    private int speedFromBody { set; get; }
    private int speedFromHands { get; set; }
    private int speedFromLegs { set; get; }
    private int speedFromAccessory { set; get; }



    private int lifeFromCombinedArmor;
    private int manaFromCombinedArmor;
    private int attackFromCombinedArmor;
    private int specialAttackFromCombinedArmor;
    private int defenseFromCombinedArmor;
    private int speedFromCombinedArmor;



    public void Awake()
    {
        
    }

    public void Start()
    {
        //GameMaster.gameMaster.Load();
        armorManager = GetComponent<ArmorManager>();

        ArmorExpUnlockChecker();
        

        //statsText = GameObject.FindGameObjectWithTag("DevUI").GetComponent<Text>();




        //ArmorStatModifier();

        //ShowUpdateStats();
        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();
        CurrentlySelectedArmor();
    }



    void Update()
    {

        //ShowUpdateStats();
        //CurrentlySelectedArmor();



    }

    //This function will set the Current stats to be passed on when a character is spawned.
    //Values will be taken from armor + character's base stats, which come from GameMaster script.
    public void AssignCurrentCharacterStats()
    {

        updatedPlayerData = new UpdatedPlayerData();
        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character1)
        {
            GameMaster.gameMaster.maxHP = lifeFromCombinedArmor + GameMaster.gameMaster.character01Life;
            GameMaster.gameMaster.curHP = lifeFromCombinedArmor + GameMaster.gameMaster.character01Life;
            GameMaster.gameMaster.maxMP = manaFromCombinedArmor + GameMaster.gameMaster.character01Mana;
            GameMaster.gameMaster.curMP = manaFromCombinedArmor + GameMaster.gameMaster.character01Mana;
            GameMaster.gameMaster.curAttack = attackFromCombinedArmor + GameMaster.gameMaster.character01Attack;
            /*GameMaster.gameMaster.curSpAttack = specialAttackFromCombinedArmor + updatedPlayerData.base01SpAtt;
            GameMaster.gameMaster.curDefense = defenseFromCombinedArmor + updatedPlayerData.base01Def;
            GameMaster.gameMaster.curSpeed = speedFromCombinedArmor + updatedPlayerData.base01Speed;
            Debug.Log("Function AssignCurrenetCharacterStats: Life from Armor: " + lifeFromCombinedArmor +
                " Life from PlayerData: " + updatedPlayerData.base01Life);*/

        }

        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character2)
        {
            GameMaster.gameMaster.maxHP = lifeFromCombinedArmor + updatedPlayerData.base02Life;
            GameMaster.gameMaster.curHP = lifeFromCombinedArmor + updatedPlayerData.base02Life;
            /*GameMaster.gameMaster.maxMP = manaFromCombinedArmor + updatedPlayerData.base02Mana;
            GameMaster.gameMaster.curMP = manaFromCombinedArmor + updatedPlayerData.base02Mana;
            GameMaster.gameMaster.curAttack = attackFromCombinedArmor + updatedPlayerData.base02Att;
            GameMaster.gameMaster.curSpAttack = specialAttackFromCombinedArmor + updatedPlayerData.base02SpAtt;
            GameMaster.gameMaster.curDefense = defenseFromCombinedArmor + updatedPlayerData.base02Def;
            GameMaster.gameMaster.curSpeed = speedFromCombinedArmor + updatedPlayerData.base02Speed;*/

        }

    }

    void ArmorExpUnlockChecker()
    {
        int characterOffset = thisCharactersID * 35;
        Debug.Log("This this run first time?");
        for (int i = characterOffset; i < (characterOffset + 35); i++)
        {
            if (GameMaster.gameMaster.allArmorExp[i] >= armorManager.SetActiveArmor(i).ExpToCap)
            {
                GameMaster.gameMaster.armorUnlocks[i+1] = true;
                
            }
            
        }
    }

    






    /*public void WeaponStatModifier(int id)
    {
        lifeFromWeapon = armorManager.SetActiveArmor(id).Life;
        manaFromWeapon = armorManager.SetActiveArmor(id).Mana;
        attackFromWeapon = armorManager.SetActiveArmor(id).Attack;
        specialAttackFromWeapon = armorManager.SetActiveArmor(id).MagicAttack;
        defenseFromWeapon = armorManager.SetActiveArmor(id).Defense;
        speedFromWeapon = armorManager.SetActiveArmor(id).Speed;
        
        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();

    }*/

    private void WeaponStatModifier(int id, int characterID)
    {
        lifeFromWeapon = armorManager.SetActiveArmor(id + characterID).Life;
        //Debug.Log("Weapon ID whose stats are being sent: " + (id + characterID) + ". And the value is: " + armorManager.SetActiveArmor(id + characterID).Life);
        manaFromWeapon = armorManager.SetActiveArmor(id + characterID).Mana;
        attackFromWeapon = armorManager.SetActiveArmor(id + characterID).Attack;
        specialAttackFromWeapon = armorManager.SetActiveArmor(id + characterID).MagicAttack;
        defenseFromWeapon = armorManager.SetActiveArmor(id + characterID).Defense;
        speedFromWeapon = armorManager.SetActiveArmor(id + characterID).Speed;

        //    CalculateStatsFromArmor();
        //AssignCurrentCharacterStats();

    }

    /*public void RangedStatModifier(int id)
    {
        lifeFromRanged = armorManager.SetActiveArmor(id).Life;
        manaFromRanged = armorManager.SetActiveArmor(id).Mana;
        attackFromRanged = armorManager.SetActiveArmor(id).Attack;
        specialAttackFromRanged = armorManager.SetActiveArmor(id).MagicAttack;
        defenseFromRanged = armorManager.SetActiveArmor(id).Defense;
        speedFromRanged = armorManager.SetActiveArmor(id).Speed;

        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();
    }*/

    private void RangedStatModifier(int id, int characterID)
    {
        lifeFromRanged = armorManager.SetActiveArmor(id + characterID + 5).Life;
        //Debug.Log("Ranged ID whose stats are being sent: " + (id + characterID + 5) + ". And the value is: " + armorManager.SetActiveArmor(id + characterID + 5).Life);
        manaFromRanged = armorManager.SetActiveArmor(id + characterID + 5).Mana;
        attackFromRanged = armorManager.SetActiveArmor(id + characterID + 5).Attack;
        specialAttackFromRanged = armorManager.SetActiveArmor(id + characterID + 5).MagicAttack;
        defenseFromRanged = armorManager.SetActiveArmor(id + characterID + 5).Defense;
        speedFromRanged = armorManager.SetActiveArmor(id + characterID + 5).Speed;

        //  CalculateStatsFromArmor();
        //AssignCurrentCharacterStats();
    }

    /*public void HeadArmorStatModifier(int id)
    {
        lifeFromHelm = armorManager.SetActiveArmor(id).Life;
        manaFromHelm = armorManager.SetActiveArmor(id).Mana;
        attackFromHelm = armorManager.SetActiveArmor(id).Attack;
        specialAttackFromHelm = armorManager.SetActiveArmor(id).MagicAttack;
        defenseFromHelm = armorManager.SetActiveArmor(id).Defense;
        speedFromHelm = armorManager.SetActiveArmor(id).Speed;

        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();
    }*/

    private void HeadArmorStatModifier(int id, int characterID)
    {
        lifeFromHelm = armorManager.SetActiveArmor(id + characterID + 10).Life;
        //Debug.Log("Head ID whose stats are being sent: " + (id + characterID + 10) + ". And the value is: " + armorManager.SetActiveArmor(id + characterID + 10).Life);
        manaFromHelm = armorManager.SetActiveArmor(id + characterID + 10).Mana;
        attackFromHelm = armorManager.SetActiveArmor(id + characterID + 10).Attack;
        specialAttackFromHelm = armorManager.SetActiveArmor(id + characterID + 10).MagicAttack;
        defenseFromHelm = armorManager.SetActiveArmor(id + characterID + 10).Defense;
        speedFromHelm = armorManager.SetActiveArmor(id + characterID + 10).Speed;

        //   CalculateStatsFromArmor();
        //AssignCurrentCharacterStats();
    }

    /*
    public void BodyArmorStatModifier(int id)
    {
        lifeFromBody = armorManager.SetActiveArmor(id).Life;
        manaFromBody = armorManager.SetActiveArmor(id).Mana;
        attackFromBody = armorManager.SetActiveArmor(id).Attack;
        specialAttackFromBody = armorManager.SetActiveArmor(id).MagicAttack;
        defenseFromBody = armorManager.SetActiveArmor(id).Defense;
        speedFromBody = armorManager.SetActiveArmor(id).Speed;

        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();
    }*/

    private void BodyArmorStatModifier(int id, int characterID)
    {
        lifeFromBody = armorManager.SetActiveArmor(id + characterID + 15).Life;
        manaFromBody = armorManager.SetActiveArmor(id + characterID + 15).Mana;
        attackFromBody = armorManager.SetActiveArmor(id + characterID + 15).Attack;
        specialAttackFromBody = armorManager.SetActiveArmor(id + characterID + 15).MagicAttack;
        defenseFromBody = armorManager.SetActiveArmor(id + characterID + 15).Defense;
        speedFromBody = armorManager.SetActiveArmor(id + characterID + 15).Speed;

        //  CalculateStatsFromArmor();
        //AssignCurrentCharacterStats();
    }

    /*
    public void HandArmorStatModifier(int id)
    {
        lifeFromHands = armorManager.SetActiveArmor(id).Life;
        manaFromHands = armorManager.SetActiveArmor(id).Mana;
        attackFromHands = armorManager.SetActiveArmor(id).Attack;
        specialAttackFromHands = armorManager.SetActiveArmor(id).MagicAttack;
        defenseFromHands = armorManager.SetActiveArmor(id).Defense;
        speedFromHands = armorManager.SetActiveArmor(id).Speed;

        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();
    }*/

    private void HandArmorStatModifier(int id, int characterID)
    {
        lifeFromHands = armorManager.SetActiveArmor(id + characterID + 20).Life;
        manaFromHands = armorManager.SetActiveArmor(id + characterID + 20).Mana;
        attackFromHands = armorManager.SetActiveArmor(id + characterID + 20).Attack;
        specialAttackFromHands = armorManager.SetActiveArmor(id + characterID + 20).MagicAttack;
        defenseFromHands = armorManager.SetActiveArmor(id + characterID + 20).Defense;
        speedFromHands = armorManager.SetActiveArmor(id + characterID + 20).Speed;

        //  CalculateStatsFromArmor();
        //AssignCurrentCharacterStats();
    }

    /*
    public void LegArmorStatModifier(int id)
    {
        lifeFromLegs = armorManager.SetActiveArmor(id).Life;
        manaFromLegs = armorManager.SetActiveArmor(id).Mana;
        attackFromLegs = armorManager.SetActiveArmor(id).Attack;
        specialAttackFromLegs = armorManager.SetActiveArmor(id).MagicAttack;
        defenseFromLegs = armorManager.SetActiveArmor(id).Defense;
        speedFromLegs = armorManager.SetActiveArmor(id).Speed;

        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();
    }*/

    private void LegArmorStatModifier(int id, int characterID)
    {
        lifeFromLegs = armorManager.SetActiveArmor((id + characterID + 25)).Life;
        manaFromLegs = armorManager.SetActiveArmor(id + characterID + 25).Mana;
        attackFromLegs = armorManager.SetActiveArmor(id + characterID + 25).Attack;
        specialAttackFromLegs = armorManager.SetActiveArmor(id + characterID + 25).MagicAttack;
        defenseFromLegs = armorManager.SetActiveArmor(id + characterID + 25).Defense;
        speedFromLegs = armorManager.SetActiveArmor(id + characterID + 25).Speed;

        // CalculateStatsFromArmor();
        //AssignCurrentCharacterStats();
    }

    /*
    public void AccessoryArmorStatModifier(int id)
    {
        lifeFromAccessory = armorManager.SetActiveArmor(id).Life;
        manaFromAccessory = armorManager.SetActiveArmor(id).Mana;
        attackFromAccessory = armorManager.SetActiveArmor(id).Attack;
        specialAttackFromAccessory = armorManager.SetActiveArmor(id).MagicAttack;
        defenseFromAccessory = armorManager.SetActiveArmor(id).Defense;
        speedFromAccessory = armorManager.SetActiveArmor(id).Speed;

        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();
    }*/

    private void AccessoryArmorStatModifier(int id, int characterID)
    {
        lifeFromAccessory = armorManager.SetActiveArmor(id + characterID + 30).Life;
        manaFromAccessory = armorManager.SetActiveArmor(id + characterID + 30).Mana;
        attackFromAccessory = armorManager.SetActiveArmor(id + characterID + 30).Attack;
        specialAttackFromAccessory = armorManager.SetActiveArmor(id + characterID + 30).MagicAttack;
        defenseFromAccessory = armorManager.SetActiveArmor(id + characterID + 30).Defense;
        speedFromAccessory = armorManager.SetActiveArmor(id + characterID + 30).Speed;

        //CalculateStatsFromArmor();
        //AssignCurrentCharacterStats();
    }

    void CalculateStatsFromArmor()
    {
        lifeFromCombinedArmor = lifeFromWeapon + lifeFromRanged + lifeFromHelm + lifeFromBody + lifeFromHands + lifeFromLegs + lifeFromAccessory;
        manaFromCombinedArmor = manaFromWeapon + manaFromRanged + manaFromHelm + manaFromBody + manaFromHands + manaFromLegs + manaFromAccessory;
        attackFromCombinedArmor = attackFromWeapon + attackFromRanged + attackFromHelm + attackFromBody + attackFromHands + attackFromLegs + attackFromAccessory;
        specialAttackFromCombinedArmor = specialAttackFromWeapon + specialAttackFromRanged + specialAttackFromHelm + specialAttackFromBody + specialAttackFromHands + specialAttackFromLegs + specialAttackFromAccessory;
        defenseFromCombinedArmor = defenseFromWeapon + defenseFromRanged + defenseFromHelm + defenseFromBody + defenseFromHands + defenseFromLegs + defenseFromAccessory;
        speedFromCombinedArmor = speedFromWeapon + speedFromRanged + speedFromHelm + speedFromBody + speedFromHands + speedFromLegs + speedFromAccessory;
    }


    //This function is for the system to remember what armor was previously selected so that cursor is in correct place. Also auto selects default armors when none have been selected yet.
    //TODO: Figure out a way to make this code more concise and efficient!
    public void CurrentlySelectedArmor()
    {
        int referenceID;

        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character1)
        {
            referenceID = 0;
            WeaponStatModifier((int)GameMaster.gameMaster.char01Weapons, referenceID);
            RangedStatModifier((int)GameMaster.gameMaster.char01Ranged, referenceID);
            HeadArmorStatModifier((int)GameMaster.gameMaster.char01Helmets, referenceID);
            BodyArmorStatModifier((int)GameMaster.gameMaster.char01Body, referenceID);
            HandArmorStatModifier((int)GameMaster.gameMaster.char01Hands, referenceID);
            LegArmorStatModifier((int)GameMaster.gameMaster.char01Legs, referenceID);
            AccessoryArmorStatModifier((int)GameMaster.gameMaster.char01Accessory, referenceID);
            //Debug.Log("How many times was this called?");

        }

        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character2)
        {
            referenceID = 35;
            WeaponStatModifier((int)GameMaster.gameMaster.char02Weapons, referenceID);
            RangedStatModifier((int)GameMaster.gameMaster.char02Ranged, referenceID);
            HeadArmorStatModifier((int)GameMaster.gameMaster.char02Helmets, referenceID);
            BodyArmorStatModifier((int)GameMaster.gameMaster.char02Body, referenceID);
            HandArmorStatModifier((int)GameMaster.gameMaster.char02Hands, referenceID);
            LegArmorStatModifier((int)GameMaster.gameMaster.char02Legs, referenceID);
            AccessoryArmorStatModifier((int)GameMaster.gameMaster.char02Accessory, referenceID);
            // CalculateStatsFromArmor();
        }

        CalculateStatsFromArmor();
        AssignCurrentCharacterStats();



    }
}
