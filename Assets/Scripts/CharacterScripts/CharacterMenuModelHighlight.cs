using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMenuModelHighlight : MonoBehaviour {

	//public Transform camera;

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

		models [1].SetActive (true);
        //CheckIfCharacterIsUnlocked();
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



	/*void Update() {
		
	}
	public void MoveCamBack()
	{
		//camera.transform.position.y = 10;
		camera.position = new Vector3(0, 0, -10);
		Debug.Log ("This buttons is chosen");

		//Vector2 dir =  new Vector2(0, camera.gameObject.transform.position.y - 10);
		//dir *= cameraMovementSpeed * Time.deltaTime;
	}
	public void MoveCamHere()
	{
		//camera.transform.position.y = 10;
		//camera.position = new Vector3(0, -30, -10);
		Debug.Log ("This buttons is chosen");
		target.position = new Vector3 (0, -30, -10);

		//Vector2 dir =  new Vector2(0, camera.gameObject.transform.position.y - 10);
		//dir *= cameraMovementSpeed * Time.deltaTime;
	}*/



	

}
