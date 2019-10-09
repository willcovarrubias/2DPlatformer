using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

	private List<GameObject> models;
	private int selectionIndex = 0;
    public Button weaponButton;

    
    public GameObject heroNamePanel, heroProfessionPanel, heroStatPanel;
    private Text heroNameText, heroProfessionText, heroStatsText;
    private CharacterManager characterManager;
    private CharacterDatabase characterDB;
    private Characters character;

    private ArmorManager armorManager;
    private ArmorDatabase armorDB;
    private Armor armor;

    private ArmorSceneController armorSceneController;
    public GameObject armorSceneControllerParent;


	// Use this for initialization
	void Start () {

        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        models[selectionIndex].SetActive(true);

        characterManager = GameObject.FindGameObjectWithTag("GM").GetComponent<CharacterManager>();
        characterDB = GameObject.FindGameObjectWithTag("GM").GetComponent<CharacterDatabase>();
        character = characterDB.FetchCharacterByID(selectionIndex);

        armorManager = GameObject.FindGameObjectWithTag("GM").GetComponent<ArmorManager>();
        armorDB = GameObject.FindGameObjectWithTag("GM").GetComponent<ArmorDatabase>();
        armor = armorDB.FetchArmorByID(selectionIndex);

        armorSceneController = armorSceneControllerParent.GetComponent<ArmorSceneController>();

        heroNameText = heroNamePanel.GetComponent<Text>();
        heroProfessionText = heroProfessionPanel.GetComponent<Text>();
        heroStatsText = heroStatPanel.GetComponent<Text>();
    }

    void Update()
	{
		//if(Input.GetButton("Cancel"))
		//	Application.LoadLevel("MainMenu");
		
	}


	public void Selector(int index){

		if (index == selectionIndex)
			return;
		if (index < 0 || index >= models.Count)
			return;

		models [selectionIndex].SetActive (false);
		selectionIndex = index;
		models [selectionIndex].SetActive (true);

        character = characterManager.GetCharacterStats(selectionIndex);


        heroNameText.text = character.Name;
        heroProfessionText.text = character.Profession;

        //heroNameText.text = characterManager.GetCharacterStats(selectionIndex).Name;
        //heroProfessionText.text = characterManager.GetCharacterStats(selectionIndex).Profession;
        ShowFormattedCharacterStats(selectionIndex);
    }

    private void ShowFormattedCharacterStats(int index)
    {
        heroStatsText.text = "HP: " + character.HP + "<color=green>" + armorSceneController.GetHPFromEquippedArmor() + "</color>" +
            "\nMP: " + character.MP;
    }

	public void SelectCharacter(int id)
	{
        PlayerPrefs.SetInt("CurrentCharacter", id);
        //Application.LoadLevel ("ArmorSelect");

        PlayerPrefs.SetInt("ActiveWeapon", PlayerPrefs.GetInt(id + "Weapon"));
        //ChangeFocusToWeapon();

        Debug.Log("Character set: " + id + ". The new active weapon: " + PlayerPrefs.GetInt("ActiveWeapon"));
        PlayerPrefs.Save();
    }

    public void ChangeFocusToWeapon()
    {
        //Finds and assigns the selectable to the Right of the main button.
        Selectable newSelectable = weaponButton;
        newSelectable.Select();
    }

    public void ChangeFocusToTheRight()
    {
        //Finds and assigns the selectable to the Right of the main button.
        Selectable newSelectable = weaponButton.FindSelectableOnRight();
        newSelectable.Select();
    }

}
