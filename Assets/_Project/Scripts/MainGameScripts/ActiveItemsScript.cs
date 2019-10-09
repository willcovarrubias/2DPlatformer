using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveItemsScript : MonoBehaviour {

	public static ActiveItemsScript activeItemsScript;

	public enum ActiveItems{Item001, Item002, Item003}
	public static ActiveItems activeItems;


	private List<GameObject> models;
	private int selectionIndex = 0;

	void Start () {

		activeItems = ActiveItems.Item001;

		models = new List<GameObject> ();
		foreach (Transform t in transform) 
		{
			models.Add (t.gameObject);
			t.gameObject.SetActive (false);
		}



		models [selectionIndex].SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//TODO: This will determine what items should be set to active. The command will happen in the
		//collision with the pickup item.
		if (activeItems == ActiveItems.Item002) 
		{
			models [1].SetActive (true);

			//Debug.Log ("Item002 is selected!");
		}
		if (activeItems == ActiveItems.Item003) 
		{
			models [2].SetActive (true);
		}

		//Debug.Log (activeItems);
	}


	public void Item001()
	{
		activeItems = ActiveItems.Item001;
	}
	public void Item002()
	{
		activeItems = ActiveItems.Item002;
	}
	public void Item003()
	{
		activeItems = ActiveItems.Item003;
	}
}
