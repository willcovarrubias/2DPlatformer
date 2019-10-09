using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveItemsUIScript : MonoBehaviour {

	private List<GameObject> models;
	private int selectionIndex = 0;

	//public static ActiveItemsUIScript activeItemsUIScript;

	//ActiveItemsScript activeItemsScript;

	public GameObject eventSystem;

	void Start () {
        


        //activeItemsScript = GetComponent<ActiveItemsScript>();

        models = new List<GameObject> ();
		foreach (Transform t in transform) 
		{
			models.Add (t.gameObject);
			t.gameObject.SetActive (false);
		}



		//models [selectionIndex].SetActive (false);
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


    public void Update()
    {
        GameObject inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        //inventoryObj.transform.position = new Vector2(0, 500);
        inventoryObj.GetComponent<Inventory>();

        if (inventoryObj.GetComponent<Inventory>().nameCount == 1)
        {
            models[0].SetActive(true);
        }
        else
            models[0].SetActive(false);

        if (inventoryObj.GetComponent<Inventory>().nameCount == 2)
        {
            models[1].SetActive(true);
        }
        else
            models[1].SetActive(false);

        if (inventoryObj.GetComponent<Inventory>().nameCount == 3)
        {
            models[2].SetActive(true);
        }
        else
            models[2].SetActive(false);

        if (inventoryObj.GetComponent<Inventory>().nameCount == 4)
        {
            models[3].SetActive(true);
        }
        else
            models[3].SetActive(false);

        if (inventoryObj.GetComponent<Inventory>().nameCount == 5)
        {
            models[4].SetActive(true);
        }
        else
        {
            models[4].SetActive(false);
        }
        if (inventoryObj.GetComponent<Inventory>().nameCount == 6)
        {
            models[5].SetActive(true);
        }
        else
            models[5].SetActive(false);

        if (inventoryObj.GetComponent<Inventory>().nameCount == 7)
        {
            models[6].SetActive(true);
        }
        else
        {
            models[6].SetActive(false);
        }
        if (inventoryObj.GetComponent<Inventory>().nameCount == 8)
        {
            models[7].SetActive(true);
        }
        else
            models[7].SetActive(false);

        if (inventoryObj.GetComponent<Inventory>().nameCount == 9)
        {
            models[8].SetActive(true);
        }
        else
        {
            models[8].SetActive(false);
        }
        if (inventoryObj.GetComponent<Inventory>().nameCount == 10)
        {
            models[9].SetActive(true);
        }
        else
        {
            models[9].SetActive(false);
        }


    }

}


