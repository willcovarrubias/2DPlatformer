using UnityEngine;
using System.Collections;

public class OneWayPlatforms : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HitByRay()
	{
		StartCoroutine (ChangePlatformLayer());
	}

	IEnumerator ChangePlatformLayer()
	{
		gameObject.layer = LayerMask.NameToLayer ("Enemy");
		yield return new WaitForSeconds (.5f);
		gameObject.layer = LayerMask.NameToLayer ("collisionMask");


	}
}
