using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CharacterAppearanceController : MonoBehaviour
{
    //public List<GameObject> equipmentSlots = new List<GameObject>();
        
    public GameObject Core, Torso, ThighL, ThighR, ShinL, ShinR, FootL, FootR, UpperArmL, UpperArmR, ForeArmL, ForeArmR, HandL, HandR, Head;
    public GameObject PrimaryWeapon, RangedWeapon, Sheath;


    private string characterSpriteSheet;
    private Sprite[] sprites;

    private SpriteAtlas spriteAtlas;

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

        Sprite primaryWeaponSprite = PrimaryWeapon.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite("0");
        Sprite primaryRangedSprite = RangedWeapon.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite("Bow");
        Sprite torsoSprite = Torso.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite("Torso");
        Sprite headSprite = Head.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite("Head");
    }

}
