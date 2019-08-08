using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArmorSetterRuntime : MonoBehaviour {

    /*This script will set the armor during runtime, by loading the appropriate sprite into each armor slot.
    When creating a new character's armor spritesheet - title it by the character's name and put it into "Resources/Armor/"
    Use the following chart to rename the individual body parts/armor slots:

        For the ::ARRAY SPRITES INDEX:: use the following index:
        0-4 = Weapons
        5-9 = Heads
        10-14 = Torsos
        15-19 = Right Upper Arms
        20-24 = Left Upper Arms
        25-29 = Right Forearms
        30-34 = Left Forearms
        35-39 = Right Hands
        40-44 = Left Hands
        45-49 = Waist
        50-54 = Right Thigh
        55-59 = Left Thigh
        60-64 = Right Shin
        65-69 = Left Shin
        70-74 = Right Foot
        75-80 = Left Foot



        ARMOR SLOT IDENTIFIER KEY:
        0 = Weapon
        1 = Head
        2 = Torso
        3 = Waist
        4 = Right Upper Arm
        5 = Right Forearm
        6 = Right Hand
        7 = Left Upper Arm
        8 = Left Forearm
        9 = Left Hand
        10 = Right Thigh
        11 = Right Shin
        12 = Right Foot
        13 = Left Thigh
        14 = Left Shin
        15 = Left Foot
        16 = Bow
    */

    public int armorSlotIdentifier;

    private string character01SpriteSheet = "Armor/PixelManSwords";
    private string character02SpriteSheet = "Armor/WeaponTest";
    private string character03SpriteSheet = "Armor/WeaponTest";
    private string character04SpriteSheet = "Armor/WeaponTest";
    private string characterSpriteSheet; 

    SpriteRenderer spriteRenderer;
    Sprite[] sprites;
    // Use this for initialization
    void Start () {
        characterSpriteSheet = "Armor/" + PlayerPrefs.GetInt("CurrentCharacter") + "/WeaponTest";

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        SpriteSheetLoader();
        WeaponSelector();
      
        

    }


    //This function will load the sprite sheet for each character on inst.
    //To ADD NEW CHARACTERS: 
    //1. Add enum from GameMaster for new character.
    //2. Add new character's spritesheet as a string variable.
    //3. Set sprites to load new spritesheet variable.
    void SpriteSheetLoader()
    {
        //if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character1)
        //{
        //    sprites = Resources.LoadAll<Sprite>(character01SpriteSheet);
        //}
        //if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character2)
        //{
        //    sprites = Resources.LoadAll<Sprite>(character02SpriteSheet);
        //}
        //if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character3)
        //{
        //    sprites = Resources.LoadAll<Sprite>(character01SpriteSheet);
        //}
        //if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character4)
        //{
        //    sprites = Resources.LoadAll<Sprite>(character02SpriteSheet);
        //}
        //if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character5)
        //{
        //    sprites = Resources.LoadAll<Sprite>(character02SpriteSheet);
        //}

        sprites = Resources.LoadAll<Sprite>(characterSpriteSheet);

    }

    void WeaponSelector()
    {
        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character1)
        {
            if (armorSlotIdentifier == 0)
            {
                if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep1)
                {
                    spriteRenderer.sprite = sprites[0];
                }
                if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep2)
                {
                    spriteRenderer.sprite = sprites[1];
                }
                if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep3)
                {
                    spriteRenderer.sprite = sprites[2];
                }
                if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep4)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep5)
                {
                    spriteRenderer.sprite = sprites[4];
                }
            }
        }



        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character2)
        {
            if (armorSlotIdentifier == 0)
            {
                if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep1)
                {
                    spriteRenderer.sprite = sprites[0];
                }
                if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep2)
                {
                    spriteRenderer.sprite = sprites[1];
                }
                if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep3)
                {
                    spriteRenderer.sprite = sprites[2];
                }
                if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep4)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep5)
                {
                    spriteRenderer.sprite = sprites[4];
                }
            }
        }

        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character3)
        {
            if (armorSlotIdentifier == 0)
            {
                if (GameMaster.gameMaster.char03Weapons == GameMaster.Character03Weapons.Wep1)
                {
                    spriteRenderer.sprite = sprites[0];
                }
                if (GameMaster.gameMaster.char03Weapons == GameMaster.Character03Weapons.Wep2)
                {
                    spriteRenderer.sprite = sprites[1];
                }
                if (GameMaster.gameMaster.char03Weapons == GameMaster.Character03Weapons.Wep3)
                {
                    spriteRenderer.sprite = sprites[2];
                }
                if (GameMaster.gameMaster.char03Weapons == GameMaster.Character03Weapons.Wep4)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                if (GameMaster.gameMaster.char03Weapons == GameMaster.Character03Weapons.Wep5)
                {
                    spriteRenderer.sprite = sprites[4];
                }
            }
        }

        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character4)
        {
            if (armorSlotIdentifier == 0)
            {
                if (GameMaster.gameMaster.char04Weapons == GameMaster.Character04Weapons.Wep1)
                {
                    spriteRenderer.sprite = sprites[0];
                }
                if (GameMaster.gameMaster.char04Weapons == GameMaster.Character04Weapons.Wep2)
                {
                    spriteRenderer.sprite = sprites[1];
                }
                if (GameMaster.gameMaster.char04Weapons == GameMaster.Character04Weapons.Wep3)
                {
                    spriteRenderer.sprite = sprites[2];
                }
                if (GameMaster.gameMaster.char04Weapons == GameMaster.Character04Weapons.Wep4)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                if (GameMaster.gameMaster.char04Weapons == GameMaster.Character04Weapons.Wep5)
                {
                    spriteRenderer.sprite = sprites[4];
                }
            }
        }

        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character5)
        {
            if (armorSlotIdentifier == 0)
            {
                if (GameMaster.gameMaster.char05Weapons == GameMaster.Character05Weapons.Wep1)
                {
                    spriteRenderer.sprite = sprites[0];
                }
                if (GameMaster.gameMaster.char05Weapons == GameMaster.Character05Weapons.Wep2)
                {
                    spriteRenderer.sprite = sprites[1];
                }
                if (GameMaster.gameMaster.char05Weapons == GameMaster.Character05Weapons.Wep3)
                {
                    spriteRenderer.sprite = sprites[2];
                }
                if (GameMaster.gameMaster.char05Weapons == GameMaster.Character05Weapons.Wep4)
                {
                    spriteRenderer.sprite = sprites[3];
                }
                if (GameMaster.gameMaster.char05Weapons == GameMaster.Character05Weapons.Wep5)
                {
                    spriteRenderer.sprite = sprites[4];
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
