using UnityEngine;
using System.Collections;

public class BossIntroCanvasScript : MonoBehaviour {

    //float delayToCancelCutScene = 1;
    public float cutsceneTimer;
	// Use this for initialization
	void Start () {

        cutsceneTimer = 50;

	}
	
	// Update is called once per frame
	void Update () {
        //Time.time = 0;

        cutsceneTimer -= Time.time/100;
        //delayToCancelCutScene++;
		if (GameMaster.gameMaster.inACutscene == true && cutsceneTimer <= 0) 
		{
			if (Input.GetButtonDown("Cancel"))
			{
				GameMaster.gameMaster.inACutscene = false;
				Time.timeScale = 1f;
				Destroy (gameObject);
			}
		}
	}
}
