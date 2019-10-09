using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSelector : MonoBehaviour
{
    //Check for duplicate of this script.

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

        models[selectionIndex].SetActive(true);
    }

    public void Selector(int index)
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
