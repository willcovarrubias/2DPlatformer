using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CharacterAppearanceController : MonoBehaviour
{
    //public List<GameObject> equipmentSlots = new List<GameObject>();
        
    public GameObject core, torso, thighL, thighR, shinL, shinR, footL, footR, upperArmL, upperArmR, foreArmL, foreArmR, handL, handR, head;
    public GameObject primaryWeapon, rangedWeapon, sheath;


    private string characterSpriteSheet;
    Sprite[] sprites;

    SpriteAtlas spriteAtlas;

    void Start()
    {
        characterSpriteSheet = "Armor/" + PlayerPrefs.GetInt("CurrentCharacter") + "/WeaponTest";
        spriteAtlas = Resources.Load<SpriteAtlas>("Armor/" + PlayerPrefs.GetInt("CurrentCharacter"));
        sprites = Resources.LoadAll<Sprite>(characterSpriteSheet);
        DetermineAppearance();
    }

    private void DetermineAppearance()
    {
        //Determine size of the character with this. TODO: Add a size modifier for each character.
        //gameObject.transform.localScale = new Vector3(1.5f, 1.5f,1);

        //Sprite primaryWeaponSprite = primaryWeapon.GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("ActiveWeapon")];
        //Sprite primaryRangedSprite = rangedWeapon.GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("ActiveRanged")];
        //++Sprite torsoSprite = torso.GetComponent<SpriteRenderer>().sprite = sprites[]
        Sprite primaryWeaponSprite = primaryWeapon.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite("0");
        Sprite primaryRangedSprite = rangedWeapon.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite("Bow");
        Sprite torsoSprite = torso.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite("Torso");
        Sprite headSprite = head.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite("Head");
    }

}
