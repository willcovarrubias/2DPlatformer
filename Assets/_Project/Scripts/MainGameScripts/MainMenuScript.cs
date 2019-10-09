using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public AudioSource music;

	void Update()
	{
		if(Input.GetButton("Cancel"))
			Application.LoadLevel("MainMenu");
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void NewGame()
	{
		//GameMaster.gameMaster.roomClears = 0;
		//GameMaster.gameMaster.roomCount = 0;
		SceneManager.LoadScene("ArmorSelect");
	}

	//public void SetMusicVolume(float vol)
	//{
	//	music.volume = vol; //Use a slider to call this function. 
	//}

	public void CharacterMenu()
	{
		Application.LoadLevel ("Gallery");
	}

	public void ExitToMain()
	{

		Application.LoadLevel("MainMenu");
	}
}
