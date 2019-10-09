using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Portrait_Main : MonoBehaviour
{

    private List<GameObject> models;
    private int selectionIndex = 0;


    // Use this for initialization
    void Start()
    {

        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        //models [selectionIndex].SetActive (true);
        models[1].SetActive(true);
        selectionIndex = 1;

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
}
