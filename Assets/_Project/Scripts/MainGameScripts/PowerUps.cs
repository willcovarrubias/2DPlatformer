using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "Player")
		{
			Destroy (gameObject);
			//Instantiate(BloodSplat, other.transform.position, other.transform.rotation);
			//float calc_Health = cur_Health / GameMaster.gameMaster.playerHealth;
			//GameMaster.SetHealthBar(calc_Health);
		}		
	}
}
