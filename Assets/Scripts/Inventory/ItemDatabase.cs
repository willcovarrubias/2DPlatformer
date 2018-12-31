﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
	private List<Item> database = new List<Item>();
	private JsonData itemData;

	void Start()
	{
		itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));	
		ConstructItemDatabase ();

		Debug.Log (FetchItemByID(1).Title);
	}

	public  Item FetchItemByID(int id)
	{
		for (int i = 0; i < database.Count; i++) 
		{
			if (database[i].ID == id)
				return database [i];
		}
		return null;

	}

	void ConstructItemDatabase()
	{
		for (int i = 0; i < itemData.Count; i++) 
		{
			database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"], itemData[i]["slug"].ToString()));
		}
	}
}

public class Item
{
	public int ID { get; set; }
	public string Title{ get; set; }
	public int Value{ get; set; }
	public string Slug { get; set; }
	public Sprite Sprite{get; set;}
    


	public Item(int id, string title, int value, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Items/" + slug);
        
	}

	public Item()
	{
		this.ID = -1;
	}
}
