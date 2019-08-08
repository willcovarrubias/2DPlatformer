using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmorSelector : MonoBehaviour {


    //THIS SCRIPT SELECTS THE ARMOR TO EQUIP IN THE CHARACTER'S SKELETAL RIG BY SELECTING AND DESELECTING APPROPRIATE LAYERS.
    //POSSIBLE TO RE-USE THIS SCRIPT FOR ALL CHARACTERS BY USING THE CHART BELOW TO SIMPLY CHECK RESPECTIVE GEAR/ENUM ASSIGNMENTS.
    //ALSO, IN ORDER FOR THIS TO WORK, ALL RESPECTIVE PIECES OF GEAR IN A CHARACTER'S SKELETAL RIG MUST BE ASSIGNED A VALUE.
	private List<GameObject> models;
	private int selectionIndex = 0;

    

    //**Test
    public int armorSlotIdentifier;

	// Use this for initialization
	void Start () {


        
        models = new List<GameObject> ();
		foreach (Transform t in transform) 
		{
			models.Add (t.gameObject);
			//t.gameObject.SetActive (false);
		}

        //Character01:  0: Weapon,   1: Ranged,     2: Helm,     3: Body,    4: Hands,     5: Legs
        //Character02:  6: Weapon,   7: Ranged,     8: Helm,     9: Body,   10: Hands,    11: Legs
        //Character03: 12: Weapon,  13: Ranged,    14: Helm,    15: Body,   16: Hands,    17: Legs
        //Character04: 18: Weapon,  19: Ranged,    20: Helm,    21: Body,   22: Hands,    23: Legs
        //Character05: 24: Weapon,  25: Ranged,    26: Helm,    27: Body,   28: Hands,    29: Legs
        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character1)
        {
            SetCursorsForCharacter01();
        }
      

        //models [selectionIndex].SetActive (true);
    }

	public void Select(int index){

		if (index == selectionIndex)
			return;
		if (index < 0 || index >= models.Count)
			return;

		models [selectionIndex].SetActive (false);
		selectionIndex = index;
		models [selectionIndex].SetActive (true);
		//Debug.Log (index);
	}

    private void SetCursorsForCharacter01()
    {
        if (armorSlotIdentifier == 0)
        {
            if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;

            }
            if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;

            }
            if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char01Weapons == GameMaster.Character01Weapons.Wep5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }
    }

        

        

}
