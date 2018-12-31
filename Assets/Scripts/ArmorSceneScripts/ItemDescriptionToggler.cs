using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemDescriptionToggler : MonoBehaviour {

    ArmorManager armorManager;

    private List<GameObject> models;
	private int selectionIndex = 0;
    public Text textToDisplay;

    void Start ()
    {
        armorManager = GetComponent<ArmorManager>();
   	}

	public void RecallItemInfo(int id)
    {
        textToDisplay.text = armorManager.SetActiveArmor(id).Title.ToString();
    }
}

