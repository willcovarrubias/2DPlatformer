using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortraitSplitter : MonoBehaviour {

    private List<GameObject> models;
    private int selectionIndex = 0;

    void Start()
    {

        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        //models [selectionIndex].SetActive (true);
        //models[1].SetActive(true);
        //selectionIndex = 1;
       
    }

    void Update()
    {
        
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
    }

    public void PortraitIdentifier(int portrait)
    {
        Debug.Log("This portrait is:" + portrait);


    }

    //TODO: Add the rest of the Portrait pieces for each character here.
    public void Portrait01()
    {
        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[24] == true)
            models[0].SetActive(true);
        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[25] == true)
            models[1].SetActive(true);
        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[26] == true)
            models[2].SetActive(true);
        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[27] == true)
            models[3].SetActive(true);
        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[28] == true)
            models[4].SetActive(true);
        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[29] == true)
            models[5].SetActive(true);
    }
    public void Portrait02()
    {
        Debug.Log("4");
        Debug.Log("5");
        Debug.Log("6");

    }
}
