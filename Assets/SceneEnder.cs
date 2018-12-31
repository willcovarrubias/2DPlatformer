using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnder : MonoBehaviour {

    public GameObject sceneTransitioner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            SceneTransitioner();
            Application.LoadLevel("TestScene002");
            //Application.LoadLevel("EndMenu");
            GameMaster.gameMaster.inABossFight = false;
        }


    }

    void SceneTransitioner()
    {
        Instantiate(sceneTransitioner, Vector3.zero, Quaternion.Euler(0, 0, 0));
    }
}
