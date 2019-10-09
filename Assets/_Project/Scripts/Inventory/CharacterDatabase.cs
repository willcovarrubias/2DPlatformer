using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;
using System;

public class CharacterDatabase : MonoBehaviour
{
    private List<Characters> database = new List<Characters>();
    private JsonData characterData;

    void Start()
    {
        characterData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Characters.json"));
        ConstructCharacterDatabase();
    }

    public Characters FetchCharacterByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ID == id)
                return database[i];
        }
        return null;
    }

    private void ConstructCharacterDatabase()
    {
        for (int i = 0; i < characterData.Count; i++)
        {
            database.Add(new Characters((int)characterData[i]["id"],
                characterData[i]["profession"].ToString(),
                characterData[i]["title"].ToString(),
                (int)characterData[i]["life"],
                (int)characterData[i]["mana"],
                (int)characterData[i]["attack"],
                (int)characterData[i]["magicAttack"],
                (int)characterData[i]["defense"],
                (int)characterData[i]["speed"]));
        }
    }
}


public class Characters
{
    public int ID { get; set; }
    public string Profession { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int Attack { get; set; }
    public int MagicAttack { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }




    public Characters(int id, string profession, string name, int hp, int mp, int attack, int magicAttack, int defense, int speed)
    {
        this.ID = id;
        this.Profession = profession;
        this.Name = name;
        this.HP = hp;
        this.MP = mp;
        this.Attack = attack;
        this.MagicAttack = magicAttack;
        this.Defense = defense;
        this.Speed = speed;
    }    

    public Characters()
    {
        this.ID = -1;
    }
}