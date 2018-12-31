using UnityEngine;
using System.Collections;

public class ClampTester : MonoBehaviour {

	float panSpeed;
	float panMax = 12;
	int i;

	//public GameObject mainCamera;
	// Use this for initialization
	void Awake () {


		//Camera2DFollow.camera2DFollow.xPosRestrictionRight = Camera2DFollow.camera2DFollow.xPosRestrictionRight;

		//Camera2DFollow camera2DFollow = Camera2DFollow.camera2DFollow.GetComponent<Camera2DFollow>();

		//GameObject go = GameObject.Find("MainCamera");

		//GameObject player = GameObject.FindWithTag("Player");
		//player.GetComponent<OtherScript>().DoSomething();
	}
	
	// Update is called once per frame
	void Start () {

		//for (int i = 0; i < 12; i++) {

			//Debug.Log ("This should type out 12 times");
			
		//	Camera2DFollow.xPosRestrictionRight += 1;

		//}

		//GameObject cam = GameObject.FindWithTag("Camera");
		//cam.GetComponent<Camera2DFollow>();
		//mainCamera = mainCamera.GetComponent<Camera2DFollow> ();
		Debug.Log ("This should be clamping!");

	
		//Camera2DFollow.xPosRestriction = i;
		//Camera2DFollow.xPosRestrictionRight = i;


			

		//cam.camera2dFollow.xPosRestrictionRight += 100;
	}

	void Update(){
		if (i < 74) {
			i++;
			//Debug.Log(i);
			//Camera2DFollow.xPosRestriction += .1f;
		//	Camera2DFollow.xPosRestrictionRight += .1f;
		//	Camera2DFollow.xPosRestriction = Camera2DFollow.xPosRestrictionRight;
		}//else

		//Destroy (gameObject);
	}




	}
	

