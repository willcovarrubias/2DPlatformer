using UnityEngine;
using System.Collections;

public class BossInstantiater : MonoBehaviour {

	public GameObject BossToSpawn, BossHPBar, BossIntroAnimation, TempBoundary;
	public Transform EntranceBlockLocation, ExitBlockLocation, BossSpawnPoint, CenterOfRoom;
	Transform newPos;

	GameObject bossHPBar;

	//public static bool currentlyInABossFight, currentlyPlayingBossIntro;

	// Use this for initialization
	void Start () {

		//bossHPBar = GameObject.FindGameObjectWithTag("BossHealth");
		//bossHPBar.SetActive (false);

		//GameObject go = GameObject.Find("MainCamera");
		//newPos = go.transform;
	
	}
	

	void OnTriggerEnter2D (Collider2D other)
	{
		
		if(other.gameObject.tag == "Player")
		{

			Time.timeScale = 0f;
			//currentlyPlayingBossIntro = true;
            GameMaster.gameMaster.inACutscene = true;
            GameMaster.gameMaster.inABossFight = true;
			Instantiate (BossIntroAnimation, Vector3.zero, Quaternion.Euler (0, 0, 0));
			Instantiate (BossToSpawn, BossSpawnPoint.position, BossSpawnPoint.rotation);
			Instantiate (BossHPBar, Vector3.zero, Quaternion.Euler(0,0,0));
			Instantiate (TempBoundary, EntranceBlockLocation.position, EntranceBlockLocation.rotation);
			Instantiate (TempBoundary, ExitBlockLocation.position, ExitBlockLocation.rotation);

			//CameraFollow.xPosRestrictionRight += 1;
			CameraFollow.xPosRestriction = CenterOfRoom.transform.position.x;
			CameraFollow.yPosRestriction = CenterOfRoom.transform.position.y;


			//bossHPBar.SetActive (true);

			//GameMaster.gameMaster.fireHat = true;
			//UnicornHornRight.gameObject.SetActive(true);
			//UnicornHornLeft.gameObject.SetActive(true);
			//GraphicsMaster.graphicsMaster.CheckForGraphics();
			Destroy(gameObject);
		}


	}
}
