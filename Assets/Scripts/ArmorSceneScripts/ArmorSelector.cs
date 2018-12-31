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
			t.gameObject.SetActive (false);
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
        if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character2)
        {
            SetCursorsForCharacter02();
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


        if (armorSlotIdentifier == 1)
        {
            if (GameMaster.gameMaster.char01Ranged == GameMaster.Character01Ranged.Ranged1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char01Ranged == GameMaster.Character01Ranged.Ranged2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char01Ranged == GameMaster.Character01Ranged.Ranged3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char01Ranged == GameMaster.Character01Ranged.Ranged4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char01Ranged == GameMaster.Character01Ranged.Ranged5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }


        if (armorSlotIdentifier == 2)
        {
            if (GameMaster.gameMaster.char01Helmets == GameMaster.Character01Helmets.Helm1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char01Helmets == GameMaster.Character01Helmets.Helm2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char01Helmets == GameMaster.Character01Helmets.Helm3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char01Helmets == GameMaster.Character01Helmets.Helm4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char01Helmets == GameMaster.Character01Helmets.Helm5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }

        if (armorSlotIdentifier == 3)
        {
            if (GameMaster.gameMaster.char01Body == GameMaster.Character01Body.Body1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char01Body == GameMaster.Character01Body.Body2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char01Body == GameMaster.Character01Body.Body3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char01Body == GameMaster.Character01Body.Body4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char01Body == GameMaster.Character01Body.Body5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }

        if (armorSlotIdentifier == 4)
        {
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }

        if (armorSlotIdentifier == 5)
        {
            if (GameMaster.gameMaster.char01Legs == GameMaster.Character01Legs.Legs1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char01Legs == GameMaster.Character01Legs.Legs2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char01Legs == GameMaster.Character01Legs.Legs3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char01Legs == GameMaster.Character01Legs.Legs4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char01Legs == GameMaster.Character01Legs.Legs5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }

        if (armorSlotIdentifier == 6)
        {
            if (GameMaster.gameMaster.char01Accessory == GameMaster.Character01Accessory.Accessory1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char01Accessory == GameMaster.Character01Accessory.Accessory2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char01Accessory == GameMaster.Character01Accessory.Accessory3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char01Accessory == GameMaster.Character01Accessory.Accessory4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char01Accessory == GameMaster.Character01Accessory.Accessory5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }
    }

    private void SetCursorsForCharacter02()
    {
        if (armorSlotIdentifier == 0)
        {
            if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;

            }
            if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;

            }
            if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char02Weapons == GameMaster.Character02Weapons.Wep5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }


        if (armorSlotIdentifier == 1)
        {
            if (GameMaster.gameMaster.char02Ranged == GameMaster.Character02Ranged.Ranged1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char02Ranged == GameMaster.Character02Ranged.Ranged2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char02Ranged == GameMaster.Character02Ranged.Ranged3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char02Ranged == GameMaster.Character02Ranged.Ranged4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char02Ranged == GameMaster.Character02Ranged.Ranged5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }


        if (armorSlotIdentifier == 2)
        {
            if (GameMaster.gameMaster.char02Helmets == GameMaster.Character02Helmets.Helm1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char02Helmets == GameMaster.Character02Helmets.Helm2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char02Helmets == GameMaster.Character02Helmets.Helm3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char02Helmets == GameMaster.Character02Helmets.Helm4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char02Helmets == GameMaster.Character02Helmets.Helm5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }

        if (armorSlotIdentifier == 3)
        {
            if (GameMaster.gameMaster.char02Body == GameMaster.Character02Body.Body1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char02Body == GameMaster.Character02Body.Body2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char02Body == GameMaster.Character02Body.Body3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char02Body == GameMaster.Character02Body.Body4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char02Body == GameMaster.Character02Body.Body5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }

        if (armorSlotIdentifier == 4)
        {
            if (GameMaster.gameMaster.char02Hands == GameMaster.Character02Hands.Hands1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char02Hands == GameMaster.Character02Hands.Hands2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char02Hands == GameMaster.Character02Hands.Hands3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char02Hands == GameMaster.Character02Hands.Hands4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char02Hands == GameMaster.Character02Hands.Hands5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }

        if (armorSlotIdentifier == 5)
        {
            if (GameMaster.gameMaster.char02Legs == GameMaster.Character02Legs.Legs1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char02Legs == GameMaster.Character02Legs.Legs2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char02Legs == GameMaster.Character02Legs.Legs3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char02Legs == GameMaster.Character02Legs.Legs4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char02Legs == GameMaster.Character02Legs.Legs5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }

        if (armorSlotIdentifier == 6)
        {
            if (GameMaster.gameMaster.char02Accessory == GameMaster.Character02Accessory.Accessory1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char02Accessory == GameMaster.Character02Accessory.Accessory2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char02Accessory == GameMaster.Character02Accessory.Accessory3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char02Accessory == GameMaster.Character02Accessory.Accessory4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char02Accessory == GameMaster.Character02Accessory.Accessory5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }
    }

}
