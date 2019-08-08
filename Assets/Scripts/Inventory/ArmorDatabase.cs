using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ArmorDatabase : MonoBehaviour {
	private List<Armor> database = new List<Armor>();
	private JsonData armorData;

	void Start()
	{
        armorData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Armor.json"));
        ConstructArmormDatabase();

		//Debug.Log (FetchArmorByID(1).Title);
	}

	public  Armor FetchArmorByID(int id)
	{
		for (int i = 0; i < database.Count; i++) 
		{
			if (database[i].ID == id)
				return database [i];
		}
		return null;

	}

	void ConstructArmormDatabase()
	{
		for (int i = 0; i < armorData.Count; i++) 
		{
			database.Add(new Armor((int)armorData[i]["id"], 
                armorData[i]["type"].ToString(), 
                armorData[i]["title"].ToString(), 
                (int)armorData[i]["life"], 
                (int)armorData[i]["mana"],
                (int)armorData[i]["attack"], 
                (int)armorData[i]["magicAttack"],
                (int)armorData[i]["defense"], 
                (int)armorData[i]["speed"], 
                (int)armorData[i]["expToCap"],
                armorData[i]["characterOwner"].ToString(), 
                armorData[i]["slug"].ToString(),
                (int)armorData[i]["slotID"]));
		}
	}
}

public class Armor
{
	public int ID { get; set; }
    public string Type { get; set; }
    public string Title{ get; set; }
    public int Life{ get; set; }
    public int Mana { get; set; }
    public int Attack { get; set; }
    public int MagicAttack { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    public int ExpToCap { get; set; }
    public string CharacterOwner { get; set; }
    public string Slug { get; set; }
    public int SlotID { get; set; }
	public Sprite Sprite{get; set;}
    


	public Armor(int id, string type, string title, int life, int mana, int attack, int magicAttack, int defense, int speed, int expToCap, string characterOwner, string slug, int slotID)
	{
		this.ID = id;
        this.Type = type;
		this.Title = title;
		this.Life = life;
        this.Mana = mana;
        this.Attack = attack;
        this.MagicAttack = magicAttack;
        this.Defense = defense;
        this.Speed = speed;
        this.ExpToCap = expToCap;
        this.CharacterOwner = characterOwner;
        this.Slug = slug;
        this.SlotID = slotID;
        this.Sprite = Resources.Load<Sprite>("Items/" + slug);
        
	}

	public Armor()
	{
		this.ID = -1;
	}
}
