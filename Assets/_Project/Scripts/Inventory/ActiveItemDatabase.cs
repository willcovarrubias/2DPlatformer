using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ActiveItemDatabase : MonoBehaviour {
	private List<ActiveItem> databaseB = new List<ActiveItem>();
	private JsonData activeItemData;

	void Start()
	{
		activeItemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/ActiveItems.json"));	
		ConstructItemDatabase ();

		//Debug.Log (FetchItemByIDB(0).Title);
	}

	public ActiveItem FetchItemByID(int idB)
	{
		for (int h = 0; h < databaseB.Count; h++) 
		{
			if (databaseB[h].ID == idB)
				return databaseB[h];
		}
		return null;

	}

	void ConstructItemDatabase()
	{
		for (int i = 0; i < activeItemData.Count; i++) 
		{
            databaseB.Add(new ActiveItem((int)activeItemData[i]["id"], activeItemData[i]["title"].ToString(), (int)activeItemData[i]["value"], activeItemData[i]["slug"].ToString()));
		}
	}
}

public class ActiveItem
{
	public int ID { get; set; }
	public string Title{ get; set; }
	public int Value{ get; set; }
	public string Slug { get; set; }
	public Sprite Sprite{get; set;}
    


	public ActiveItem(int id, string title, int value, string slug)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Items/" + slug);
        
	}

	public ActiveItem()
	{
		this.ID = -1;
	}
}
