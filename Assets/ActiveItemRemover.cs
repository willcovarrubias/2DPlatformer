using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItemRemover : MonoBehaviour {

    public bool isTheLeftActiveItem;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Z) && isTheLeftActiveItem)
        {
            Destroy(gameObject);
            // RemoveActiveItem();
        }

        if (Input.GetKeyDown(KeyCode.X) && !isTheLeftActiveItem)
        {
            Destroy(gameObject);
        }
    }
}
