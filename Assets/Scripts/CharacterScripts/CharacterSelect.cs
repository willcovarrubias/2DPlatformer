using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

	private List<GameObject> models;
	private int selectionIndex = 0;
    public Button weaponButton;


	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("CurrentCharacter") == null)
        {

        }
		//models = new List<GameObject> ();
		//foreach (Transform t in transform) 
		//{
		//	models.Add (t.gameObject);
		//	t.gameObject.SetActive (false);
		//}

		//models [selectionIndex].SetActive (true);
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
	}

	public void SelectCharacter(int id)
	{
        PlayerPrefs.SetInt("CurrentCharacter", id);
        //Application.LoadLevel ("ArmorSelect");

        PlayerPrefs.SetInt("ActiveWeapon", PlayerPrefs.GetInt(id + "Weapon"));
        ChangeFocusToWeapon();

        Debug.Log("Character set: " + id + ". The new active weapon: " + PlayerPrefs.GetInt("ActiveWeapon"));
        PlayerPrefs.Save();
    }

    public void ChangeFocusToWeapon()
    {
        //Finds and assigns the selectable to the Right of the main button.
        Selectable newSelectable = weaponButton;
        newSelectable.Select();
    }

}
