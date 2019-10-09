using UnityEngine;
using System.Collections;

public class TravelRight : MonoBehaviour {

	public GameObject ObjectToDestroy;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player")
		{
			GameMaster.gameMaster.Load();
			Application.LoadLevel ("Level02");
			//GameMaster.gameMaster.PlayerToSpawn.transform.position = Vector3.zero;
			//Destroy(ObjectToDestroy);
		}
		//example of sending data to gameMaster
		//if (GUI.Button (new Rect (10, 100, 100, 30), "Health Up")) 
		//{
		//	GameMaster.gameMaster.health += 10;
		//}
	}
}
