using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPManager : MonoBehaviour {
    

    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
      
            
            //gameMaster.Save();
        }
		
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Give EXP to everything"))
        {
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Weapons ] += 1000;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Ranged + 5] += 1000;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Helmets + 10] += 1000;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Body + 15] += 1000;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Hands + 20] += 1000;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Legs + 25] += 1000;
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Accessory + 30] += 1000;
        }
        /*if (GUI.Button(new Rect(10, 140, 100, 30), "Give EXP to Range"))
        {
            GameMaster.gameMaster.allArmorExp[(int)GameMaster.gameMaster.char01Ranged  + 5] += 5;
        }*/
        if (GUI.Button(new Rect(10, 180, 100, 30), "Save"))
        {
            GameMaster.gameMaster.Save();
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "Load"))
        {
            GameMaster.gameMaster.Load();
        }


    }
}
