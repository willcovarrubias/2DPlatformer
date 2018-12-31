using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    //Simple script that spawns appropriate character, depending on what was chosen in the Character Select menu.
    //To add more characters, simply add more characters to the characterChosen attributes in GameMaster.

	public GameObject character1, character2, character3;
	// Use this for initialization
	void Start () {
		PlayerSpawner ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayerSpawner()
	{
		if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character1) {
			Instantiate (character1, transform.position, transform.rotation);
		}
		if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character2) {
			Instantiate (character2, transform.position, transform.rotation);
		}
		if (GameMaster.gameMaster.characterChosen == GameMaster.CharacterChosen.Character3) {
			Instantiate (character3, transform.position, transform.rotation);
		}
	}

}
