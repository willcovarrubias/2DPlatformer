using UnityEngine;
using System.Collections;

public class SpecialAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        
        if (GameMaster.gameMaster.isPaused == false)
        {

            
            //TODO: Add mana requirements to the if conditions below. Also reduce current mana by X amount each time ability is used.
            if (Input.GetButtonDown("Item"))
            {
                if (GameMaster.gameMaster.currentActiveItem == GameMaster.CurrentActiveItem.activeItem001)
                    Debug.Log("Just used special 001!");
                if (GameMaster.gameMaster.currentActiveItem == GameMaster.CurrentActiveItem.activeItem002)
                    Debug.Log("Just used special 002!");
                if (GameMaster.gameMaster.currentActiveItem == GameMaster.CurrentActiveItem.activeItem003)
                    Debug.Log("Just used special 003!");
            }

        }
    }

    //TODO: Make active item abilities here as functions.
}
