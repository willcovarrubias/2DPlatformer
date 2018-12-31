using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusBarsRenderCamera : MonoBehaviour {
	Canvas myCanvas;
	Camera mainCamera;
	bool cameraIsLoaded;

	// Use this for initialization
	void Awake () {
		Invoke("ChangeRenderCamera", .1f);
		Invoke ("ChangeRenderCameraBackup", 5);
	}


	
	// Update is called once per frame
	void ChangeRenderCamera () {

		//yield return new WaitForSeconds (.1f);
		mainCamera = GameObject.FindGameObjectWithTag ("Camera").GetComponent<Camera> ();
		myCanvas = gameObject.GetComponent<Canvas> ();
		myCanvas.worldCamera = mainCamera;
		cameraIsLoaded = true;

		Debug.Log ("Camera is being selected");
	}

	void ChangeRenderCameraBackup()
	{
		if (cameraIsLoaded == false) 
		{
			ChangeRenderCamera ();
			Debug.Log ("Testing backup!");
		}
	}

	
}
