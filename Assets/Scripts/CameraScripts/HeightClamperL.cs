using UnityEngine;
using System.Collections;

public class HeightClamperL : MonoBehaviour {
	int i;
	public Transform HalfwayPoint;
	bool panningCam;
	public GameObject DoorTemp;
	public GameObject DoorFinal;
	public Transform DoorRight;
	public Transform DoorLeft;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update(){
		if (panningCam == true) {
			if (i < 55) {
				i++;
				//Debug.Log(i);
				Camera2DFollow.xPosRestriction += .3f;
				Camera2DFollow.xPosRestrictionRight += .3f;
				Camera2DFollow.xPosRestriction = Camera2DFollow.xPosRestrictionRight;
			} else {
				Destroy (gameObject);
				Camera2DFollow.xPosRestrictionRight = (HalfwayPoint.transform.position.x + 12);
			}
		}
	}*/

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			panningCam = true;	
			Instantiate (DoorTemp, DoorRight.transform.position, DoorRight.transform.rotation);
			Instantiate (DoorFinal, DoorLeft.transform.position, DoorLeft.transform.rotation);
			GameMaster.gameMaster.waveGoing = true;
			Destroy (gameObject);


			}
			//Camera2DFollow.yPosRestriction = (HalfwayPoint.transform.position.y + -6);
			//Camera2DFollow.yPosRestrictionUp = (HalfwayPoint.transform.position.y + 6);
			//Camera2DFollow.xPosRestriction = (HalfwayPoint.transform.position.x - 12);
			//Camera2DFollow.xPosRestrictionRight = (HalfwayPoint.transform.position.x + 12);

			Debug.Log ("Height Camera is clamped!");

		}
	}

