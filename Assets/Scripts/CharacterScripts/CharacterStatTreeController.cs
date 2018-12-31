using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterStatTreeController : MonoBehaviour {

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

        //models [selectionIndex].SetActive (true);
        models[1].SetActive(true);
        selectionIndex = 1;
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

    public void CheckIfSkillTree02IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[2] == true)
            Select(2);
        else
            Select(0);
             
    }
    public void CheckIfSkillTree03IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[3] == true)
            Select(3);
        else
            Select(0);
    }
    public void CheckIfSkillTree04IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[4] == true)
            Select(4);
        else
            Select(0);
    }
    public void CheckIfSkillTree05IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[5] == true)
            Select(5);
        else
            Select(0);
    }
    public void CheckIfSkillTree06IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[6] == true)
            Select(6);
        else
            Select(0);
    }
    public void CheckIfSkillTree07IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[7] == true)
            Select(7);
        else
            Select(0);
    }
    public void CheckIfSkillTree08IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[8] == true)
            Select(8);
        else
            Select(0);
    }
    public void CheckIfSkillTree09IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[9] == true)
            Select(9);
        else
            Select(0);
    }
    public void CheckIfSkillTree10IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[10] == true)
            Select(10);
        else
            Select(0);
    }
    public void CheckIfSkillTree11IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[11] == true)
            Select(11);
        else
            Select(0);
    }
    public void CheckIfSkillTree12IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[12] == true)
            Select(12);
        else
            Select(0);
    }
    public void CheckIfSkillTree13IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[13] == true)
            Select(13);
        else
            Select(0);
    }
    public void CheckIfSkillTree14IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[14] == true)
            Select(14);
        else
            Select(0);
    }
    public void CheckIfSkillTree15IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[15] == true)
            Select(15);
        else
            Select(0);
    }
    public void CheckIfSkillTree16IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[16] == true)
            Select(16);
        else
            Select(0);
    }
    public void CheckIfSkillTree17IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[17] == true)
            Select(17);
        else
            Select(0);
    }
    public void CheckIfSkillTree18IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[18] == true)
            Select(18);
        else
            Select(0);
    }
    public void CheckIfSkillTree19IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[19] == true)
            Select(19);
        else
            Select(0);
    }
    public void CheckIfSkillTree20IsUnlocked()
    {
        if (GameMaster.gameMaster.chars_Unlocked[20] == true)
            Select(20);
        else
            Select(0);
    }


}