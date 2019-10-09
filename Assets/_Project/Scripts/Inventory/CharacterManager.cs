using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class CharacterManager : MonoBehaviour
{
    CharacterDatabase characterDatabase;
    // Start is called before the first frame update
    void Start()
    {
        characterDatabase = GetComponent<CharacterDatabase>();
    }

    public Characters GetCharacterStats(int id)
    {
        Characters characterStats = characterDatabase.FetchCharacterByID(id);
        return characterStats;
    }
}
