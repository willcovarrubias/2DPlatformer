using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ArmorManager : MonoBehaviour {

    //public static Inventory inventory;
    //ArrayList activeItemsList = new ArrayList {};
    //public int nameCount = 0;
    //int maxItems = 0;



    //int[] itemsToScroll;
    //int minArrayNumber = 1; //does this do anything?
    //int maxArrayNumber = 5;
    //int arrayNumber = 1;
    //public static Inventory inventory;

    //public GameObject armorPanel;
    //GameObject armorUIPanel;
    GameObject slotPanelA;
    GameObject slotPanelB;
    GameObject slotPanelC;
    ArmorDatabase database;
    public GameObject slotToAddArmor;
    public GameObject armorToDisplay;
    //public GameObject inventoryItemB;

    int slotAmount;
    int slotBAmount;
    public List<Armor> armor = new List<Armor>();
    //public List<ItemB> itemsB = new List<ItemB>();
    public List<GameObject> slots = new List<GameObject>();
    //public List<GameObject> slotsB = new List<GameObject>();
    //public List<GameObject> slotsC = new List<GameObject>();

    void Start()
    {



        database = GetComponent<ArmorDatabase>();

        slotAmount = 10;
        //armorPanel = GameObject.Find("ShortyModel");
        //slotPanelA = armorPanel.transform.Find("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            armor.Add(new Armor());
            //This adds whatever is the slotToAddArmor as clones.
            slots.Add(Instantiate(slotToAddArmor));

            //This sets the parent to tell the slotToAddArmor where to spawn.
            //slots[i].transform.SetParent(armorPanel.transform);
            


            //GameObject pieceofArmor = Instantiate(armorToDisplay);
            //pieceofArmor.transform.SetParent(armorPanel.transform);
            //pieceofArmor.SetActive(false);
            //slot.transform.localPosition = new Vector3(slot.transform.localPosition.x, slot.transform.localPosition.y, 0);
            //slot.transform.localScale = new Vector3(1, 1, 1);
            //slots.Add(pieceofArmor);



        }

        //armor.Insert(3, new Armor());
        //Debug.Log("This is the item inserted:" + database.FetchArmorByID(3).Title);

        //This is for the IU Panel.
        //slotAmount = 10;
        //armorUIPanel = GameObject.Find("Inventory UI Panel");
        //slotPanelC = armorUIPanel.transform.Find("Slot Panel C").gameObject;
        /*for (int i = 0; i < slotAmount; i++)
        {
            armor.Add(new Armor());
            //slots.Add(Instantiate(inventorySlot));
            //slots[i].transform.SetParent(slotPanel.transform);
            //GameObject slotC = Instantiate(inventorySlot);
            //slotC.transform.SetParent(slotPanelC.transform);
            //slotC.transform.localPosition = new Vector3(slotC.transform.position.x, slotC.transform.position.y, 0);
            //slotC.transform.localScale = new Vector3(1, 1, 1);
            //slotsC.Add(slotC);



        }*/





        SetActiveArmor(5);
        
        
       

    }

    public void AddArmorToCharacter(int id)
    {
        Armor armorToSet = database.FetchArmorByID(id);
        for (int i = 0; i < armor.Count; i++)
        {
            if (armor[i].ID == -1)
            {
                armor[i] = armorToSet;
                GameObject armorObj = Instantiate(armorToDisplay);
                armorObj.transform.SetParent(slots[i].transform);
                            
                armorObj.name = armorToSet.Title;
                armorObj.GetComponent<SpriteRenderer>().sprite = armorToSet.Sprite;

                break;
            }
        }
    }

    public void AddArmorToUI(int id)
    {
        Armor itemToAddB = database.FetchArmorByID(id);
        for (int h = 0; h < armor.Count; h++)
        {
            if (armor[h].ID == -1)
            {
                /*armor[h] = itemToAddB;
                GameObject itemObj = Instantiate(inventoryItemB);
                itemObj.transform.SetParent(slotsB[h].transform);
                itemObj.transform.localPosition = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAddB.Sprite;
                itemObj.name = itemToAddB.Title;*/
                //itemObj.GetComponent<InventoryItemEventTriggers>().SetID(itemToAddB.ID);
                break;
            }
        }
    }

    public Armor SetActiveArmor(int id)
    {
        
        //database = this.GetComponent<ArmorDatabase>();
        Armor numberToSendOff = database.FetchArmorByID(id);

        //Debug.Log("Sending the following armor- ID:" + id + " Life value is: " + numberToSendOff.Life + "Title: " + numberToSendOff.Title);
        return numberToSendOff;
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {            
            Debug.Log(armor.ToString());
        }        
    }

}
