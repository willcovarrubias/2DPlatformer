using UnityEngine;
using System.Collections;

public class DeathMenu : MonoBehaviour {
	
	public static bool isDead = false;
	
	public GameObject deathMenuCanvas;
	
	Player player;

	GameMaster gameMaster;
	
	void Start()
	{
		player = GetComponent<Player>();
		//gameMaster = GetComponent<GameMaster>();
	}
	// Update is called once per frame
	void Update () {
		if(isDead)
		{
			Time.timeScale = 0f;
			deathMenuCanvas.SetActive(true);
			Destroy(gameMaster);

			//playerController.GetComponent<PlayerController>().enabled = false;
		}
		

	}

	public void Restart()
	{

		Destroy(gameMaster);
		deathMenuCanvas.SetActive(false);
		isDead = false;

		Application.LoadLevel("Level01");

		//TODO: Destroy the GameMaster.
	}

	public void ExitToMain()
	{
		Destroy(gameMaster);
		isDead = false;
		deathMenuCanvas.SetActive(false);
		Application.LoadLevel("MainMenu");

		//Destroy(gameMaster);
	}
	

}
