using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArmorSceneController : MonoBehaviour
{
    private int currentCharacterID;
    private string currentCharacterName;

    public GameObject weaponPanel, rangedPanel, helmetPanel, torsoPanel, handsPanel, legsPanel, accessoryPanel;
    public GameObject weaponGraphicsPanel, rangedGraphicsPanel, helmetGraphicsPanel, torsoGraphicsPanel, handsGraphicsPanel, legsGraphicsPanel, accessoryGraphicsPanel;
    public GameObject subPanel;

    public GameObject equippedGraphic;
    private List<GameObject> models;
    private int selectionIndex = 0;

    void Start()
    {
        ShowWeaponPanel();
        CloseSubPanel();

        SetEquipmentOnToggle();
    }

    private void SetEquipmentOnToggle()
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");

        weaponGraphicsPanel.GetComponent<ArmorSelector>().Select(PlayerPrefs.GetInt(currentCharacterID + "Weapon"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pause"))
        {
            StartMainGame();
        }

    }

    public void StartMainGame()
    {
        FinalizeSelection();
        SceneManager.LoadScene("Level1");
    }

    //Stat Modifying Functions
    public void SetActiveWeapon(int id)
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");

        //Remembers the last cursor position for each weapon, for each character.
        PlayerPrefs.SetInt(currentCharacterID + "Weapon", id);

        //Used to spawn the weapon that's chosen for that run.
        //PlayerPrefs.SetString(currentCharacterID + "Weapon", id.ToString());  //Example: "0Weapon0"
        PlayerPrefs.SetInt("ActiveWeapon", id);
        Debug.Log("Weapon set: " + id + ". ActiveCharacter: " + currentCharacterID);

        //This'll set:
        //ActiveWeapon - ID
        //MemoWeapon - ID
        PlayerPrefs.Save();

    }

    public void SetEquippedGraphic(GameObject equippedObject)
    {


    }

    public void Selector(int index)
    {

        if (index == selectionIndex)
            return;
        if (index < 0 || index >= models.Count)
            return;

        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);
    }

    public void SetActiveRanged(int id)
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");

        //Remembers the last cursor position for each RANGED, for each character.
        PlayerPrefs.SetInt(currentCharacterID + "Ranged", id);

        //Used to spawn the RANGED that's chosen for that run.
        PlayerPrefs.SetInt("ActiveRanged", id);
 
        PlayerPrefs.Save();
    }

    public void SetActiveHelm(int id)
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");

        //Remembers the last cursor position for each HELM, for each character.
        PlayerPrefs.SetInt(currentCharacterID + "Helm", id);

        //Used to spawn the HELM that's chosen for that run.
        PlayerPrefs.SetInt("ActiveHelm", id);
 
        PlayerPrefs.Save();
    }

    public void SetActiveTorso(int id)
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");

        //Remembers the last cursor position for each TORSO, for each character.
        PlayerPrefs.SetInt(currentCharacterID + "Torso", id);

        //Used to spawn the TORSO that's chosen for that run.
        PlayerPrefs.SetInt("ActiveTorso", id);

        PlayerPrefs.Save();
    }

    public void SetActiveHands(int id)
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");

        //Remembers the last cursor position for each HANDS, for each character.
        PlayerPrefs.SetInt(currentCharacterID + "Hands", id);

        //Used to spawn the HANDS that's chosen for that run.
        PlayerPrefs.SetInt("ActiveHands", id);

        PlayerPrefs.Save();
    }

    public void SetActiveLegs(int id)
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");

        //Remembers the last cursor position for each LEGS, for each character.
        PlayerPrefs.SetInt(currentCharacterID + "Legs", id);

        //Used to spawn the LEGS that's chosen for that run.
        PlayerPrefs.SetInt("ActiveLegs", id);

        PlayerPrefs.Save();
    }

    public void SetActiveAcc(int id)
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");

        //Remembers the last cursor position for each ACCESSORY, for each character.
        PlayerPrefs.SetInt(currentCharacterID + "Accessory", id);

        //Used to spawn the ACCESSORY that's chosen for that run.
        PlayerPrefs.SetInt("ActiveAccessory", id);

        PlayerPrefs.Save();
    }

    public void FinalizeSelection()
    {
        int currentCharacterID = PlayerPrefs.GetInt("CurrentCharacter");
        PlayerPrefs.SetString("ActiveWeapon", PlayerPrefs.GetString(currentCharacterID + "Weapon"));
        PlayerPrefs.SetString("ActiveRanged", PlayerPrefs.GetString(currentCharacterID + "Ranged"));
        PlayerPrefs.SetString("ActiveHelm", PlayerPrefs.GetString(currentCharacterID + "Helm"));
        PlayerPrefs.SetString("ActiveTorso", PlayerPrefs.GetString(currentCharacterID + "Torso"));
        PlayerPrefs.SetString("ActiveHands", PlayerPrefs.GetString(currentCharacterID + "Hands"));
        PlayerPrefs.SetString("ActiveLegs", PlayerPrefs.GetString(currentCharacterID + "Legs"));
        PlayerPrefs.SetString("ActiveAccessory", PlayerPrefs.GetString(currentCharacterID + "Accessory"));
        PlayerPrefs.Save();
    }
   
    public void ShowWeaponPanel()
    {
        weaponPanel.SetActive(true);
        rangedPanel.SetActive(false);
        helmetPanel.SetActive(false);
        torsoPanel.SetActive(false);
        handsPanel.SetActive(false);
        legsPanel.SetActive(false);
        accessoryPanel.SetActive(false);

    }

    public void ShowRangedPanel()
    {
        weaponPanel.SetActive(false);
        rangedPanel.SetActive(true);
        helmetPanel.SetActive(false);
        torsoPanel.SetActive(false);
        handsPanel.SetActive(false);
        legsPanel.SetActive(false);
        accessoryPanel.SetActive(false);

    }

    public void ShowHelmetPanel()
    {
        weaponPanel.SetActive(false);
        rangedPanel.SetActive(false);
        helmetPanel.SetActive(true);
        torsoPanel.SetActive(false);
        handsPanel.SetActive(false);
        legsPanel.SetActive(false);
        accessoryPanel.SetActive(false);

    }

    public void ShowTorsoPanel()
    {
        weaponPanel.SetActive(false);
        rangedPanel.SetActive(false);
        helmetPanel.SetActive(false);
        torsoPanel.SetActive(true);
        handsPanel.SetActive(false);
        legsPanel.SetActive(false);
        accessoryPanel.SetActive(false);

    }

    public void ShowHandsPanel()
    {
        weaponPanel.SetActive(false);
        rangedPanel.SetActive(false);
        helmetPanel.SetActive(false);
        torsoPanel.SetActive(false);
        handsPanel.SetActive(true);
        legsPanel.SetActive(false);
        accessoryPanel.SetActive(false);

    }

    public void ShowLegsPanel()
    {
        weaponPanel.SetActive(false);
        rangedPanel.SetActive(false);
        helmetPanel.SetActive(false);
        torsoPanel.SetActive(false);
        handsPanel.SetActive(false);
        legsPanel.SetActive(true);
        accessoryPanel.SetActive(false);

    }

    public void ShowAccessoryPanel()
    {
        weaponPanel.SetActive(false);
        rangedPanel.SetActive(false);
        helmetPanel.SetActive(false);
        torsoPanel.SetActive(false);
        handsPanel.SetActive(false);
        legsPanel.SetActive(false);
        accessoryPanel.SetActive(true);

    }

    public void ShowSubPanel()
    {
        subPanel.SetActive(true);
    }
    public void CloseSubPanel()
    {
        subPanel.SetActive(false);
    }

    
}
