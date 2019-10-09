using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponAndArmorUnlocks : MonoBehaviour
{


    //Use this to identify which armor, for which character needs to be checked for unlocks.
    //Char01 =  1 Weapon, 2 Ranged, 3 Helmet, 4 Body, 5 Hands, 6 Legs, 7 Accessory
    public int idFromArmorDB;

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

        models[0].SetActive(true);
        //selectionIndex = 0;



        for (int i = 0; i < 5; i++)
        {
            if (GameMaster.gameMaster.armorUnlocks[i + idFromArmorDB] == true)
                models[i].SetActive(true);
           
        }
      
    }

    
}
