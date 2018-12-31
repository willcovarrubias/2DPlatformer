using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour {

	private List<GameObject> models;
	private int selectionIndex = 0;


	// Use this for initialization
	void Start () {
		
		models = new List<GameObject> ();
		foreach (Transform t in transform) 
		{
			models.Add (t.gameObject);
			t.gameObject.SetActive (false);
		}

		models [selectionIndex].SetActive (true);
	}

	void Update()
	{
		if(Input.GetButton("Cancel"))
			Application.LoadLevel("MainMenu");
		
	}


	public void Select(int index){

		if (index == selectionIndex)
			return;
		if (index < 0 || index >= models.Count)
			return;

		models [selectionIndex].SetActive (false);
		selectionIndex = index;
		models [selectionIndex].SetActive (true);
	}

	public void SelectCharacter1()
	{
		GameMaster.gameMaster.characterChosen = GameMaster.CharacterChosen.Character1;
		Application.LoadLevel ("Character01ArmorSelect");
		//Debug.Log ("Step 1");
	}

	public void SelectCharacter2()
	{
		GameMaster.gameMaster.characterChosen = GameMaster.CharacterChosen.Character2;
		Application.LoadLevel ("Character02ArmorSelect");
	}

	public void SelectCharacter3()
	{
		GameMaster.gameMaster.characterChosen = GameMaster.CharacterChosen.Character1;
		Application.LoadLevel("Scene001");
	}
	public void SelectCharacter4()
	{
		GameMaster.gameMaster.characterChosen = GameMaster.CharacterChosen.Character4;
		Application.LoadLevel("TestScene001");
	}

}
