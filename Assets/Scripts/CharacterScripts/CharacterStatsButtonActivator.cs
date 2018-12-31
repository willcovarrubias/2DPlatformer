using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterStatsButtonActivator : MonoBehaviour {

    //CAN PROBABLY USE THIS SCRIPT TO BE THE ONE THAT UNLOCKS CHARACTERS.
	private List<GameObject> models;
	private int selectionIndex = 0;


	// Use this for initialization
	void Start () {

		models = new List<GameObject> ();
		foreach (Transform t in transform) 
		{
			models.Add (t.gameObject);
			//t.gameObject.SetActive (false);
		}
        models[12].SetActive(true);
        CheckForCharacterUnlocks();
	}

	public void Select(int index){

		if (index == selectionIndex)
			return;
		if (index < 0 || index >= models.Count)
			return;

		//models [selectionIndex].SetActive (false);
		selectionIndex = index;
		models [selectionIndex].SetActive (true);
	}

	public void HideAllButtons(){
		foreach (Transform t in transform) 
		{
			models.Add (t.gameObject);
			//t.gameObject.SetActive (false);
		}

		models [selectionIndex].SetActive (true);
	}

	public void UnhideAllButtons(){
		foreach (Transform t in transform) 
		{
			models.Add (t.gameObject);
			t.gameObject.SetActive (true);


		}

		//models [selectionIndex].SetActive (true);
	}

    void CheckForCharacterUnlocks()
    {
        //SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
        //sprite_renderer.color = new Color(1f, 1f, 1f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[2] == false)
            models[2].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[3] == false)
            models[3].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[4] == false)
            models[4].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[5] == false)
            models[5].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[6] == false)
            models[6].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[7] == false)
            models[7].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[8] == false)
            models[8].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[9] == false)
            models[9].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[10] == false)
            models[10].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[11] == false)
            models[11].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[12] == false)
            models[12].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[13] == false)
            models[13].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[14] == false)
            models[14].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[15] == false)
            models[15].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[16] == false)
            models[16].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[17] == false)
            models[17].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[18] == false)
            models[18].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[19] == false)
            models[19].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
        if (GameMaster.gameMaster.chars_Unlocked[20] == false)
            models[20].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);

        //01=12       02=11        03=13      04=16         05=6
        //06=3        07=19        08=14      09=10         10=9
        //11=8        12=18        13=15      14=17         15=7
        //16=5        17=1        18=2       19=4          20=0
    }
}

//20, 17, 18, 06, 19, 16, 05, 15, 11, 10, 09, 02, 01, 03, 08, 13, 04, 14, 12, 07