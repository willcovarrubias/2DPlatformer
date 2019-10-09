using UnityEngine;
using System.Collections;

public class CameraClampFirst : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Camera2DFollow.xPosRestrictionRight = 40;
			//Camera2DFollow.xPosRestriction = 40;
			//Debug.Log ("Collider is proc'ing");
			Destroy(gameObject);
		}
	}
}
