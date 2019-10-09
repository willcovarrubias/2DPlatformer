using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_HandArmorSelected : MonoBehaviour {

    public int thisCharacter;

    private List<GameObject> models;
    private int selectionIndex = 0;
    // Use this for initialization
    void Start () {

        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        if (thisCharacter == 1)
        {
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands1)
            {
                models[0].SetActive(true);
                selectionIndex = 0;
            }
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands2)
            {
                models[1].SetActive(true);
                selectionIndex = 1;
            }
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands3)
            {
                models[2].SetActive(true);
                selectionIndex = 2;
            }
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands4)
            {
                models[3].SetActive(true);
                selectionIndex = 3;
            }
            if (GameMaster.gameMaster.char01Hands == GameMaster.Character01Hands.Hands5)
            {
                models[4].SetActive(true);
                selectionIndex = 4;
            }
        }
        
	}

    public void Select(int index)
    {

        if (index == selectionIndex)
            return;
        if (index < 0 || index >= models.Count)
            return;

        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);
        //Debug.Log (index);
    }


}
