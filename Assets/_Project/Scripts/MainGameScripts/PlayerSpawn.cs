using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    //Simple script that spawns appropriate character, depending on what was chosen in the Character Select menu.
    //To add more characters, simply add more characters to the characterChosen attributes in GameMaster.

	public GameObject character;
	// Use this for initialization
	void Start () {
		PlayerSpawner ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayerSpawner()
	{
        Instantiate(character, transform.position, transform.rotation);
		
	}

}
