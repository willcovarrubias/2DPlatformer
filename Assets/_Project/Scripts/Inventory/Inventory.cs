using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //public static Inventory inventory;
    ArrayList activeItemsList = new ArrayList {};
    public int nameCount = 0;
    int maxItems = 0;



    int[] itemsToScroll;
    //int minArrayNumber = 1; //does this do anything?
    //int maxArrayNumber = 5;
    //int arrayNumber = 1;
    //public static Inventory inventory;

    GameObject inventoryPanel;
    GameObject activeItemIconPanel;
    GameObject collectedItemsMainPanel;
    GameObject equippedArmorPanel;
    GameObject activeItemsPanel;
    ItemDatabase itemDatabase;
    ActiveItemDatabase activeItemDatabase;

    
    ArmorDatabase armorDatabase;

    public GameObject inventorySlot;
    public GameObject inventoryItem;
    public GameObject leftActiveItem;
    public GameObject rightActiveItem;
    public GameObject inventoryArmor;

    int slotAmount;
    int armorSlotAmount;
    public List<Item> items = new List<Item>();
    public List<ActiveItem> activeItems = new List<ActiveItem>();
    public List<Armor> armor = new List<Armor>();

    public List<GameObject> slotsForItems = new List<GameObject>();
    public List<GameObject> slotsForArmor = new List<GameObject>();
    public List<GameObject> slotsForActiveItems = new List<GameObject>();

    void Start()
    {
        int charactersIDOffset = (int)GameMaster.gameMaster.characterChosen * 35;  //35 is the amount of armor objects each character has.
        //AddSelectedArmorToInventoryList(1);


        //This is for regular items that are collected throughout the game. 
        //Items Collected List.
        itemDatabase = GetComponent<ItemDatabase>();
        slotAmount = 10;
        inventoryPanel = GameObject.Find("Inventory Panel");
        collectedItemsMainPanel = inventoryPanel.transform.Find("CollectedItems").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            GameObject slotForItems = Instantiate(inventorySlot);
            slotForItems.transform.SetParent(collectedItemsMainPanel.transform);
            slotForItems.transform.localPosition = new Vector3(slotForItems.transform.localPosition.x, slotForItems.transform.localPosition.y, 0);
            slotForItems.transform.localScale = new Vector3(1, 1, 1);
            slotsForItems.Add(slotForItems);
        }



        //This is for Active Items that the player picks up throughout the game.
        //Active Items List.
        activeItemDatabase = GetComponent<ActiveItemDatabase>();
        activeItemIconPanel = GameObject.Find("ActiveItemController");
        activeItemsPanel = activeItemIconPanel.transform.Find("ActiveItemIcon").gameObject;
        for (int i = 0; i < 2; i++)
        {
            activeItems.Add(new ActiveItem());
            GameObject slotForActiveItems = Instantiate(inventorySlot);
            slotForActiveItems.transform.SetParent(activeItemsPanel.transform);
            slotForActiveItems.transform.localPosition = new Vector3(slotForActiveItems.transform.localPosition.x, slotForActiveItems.transform.localPosition.y, 0);
            slotForActiveItems.transform.localScale = new Vector3(1, 1, 1);
            slotsForActiveItems.Add(slotForActiveItems);
        }
                   
                
        //This is to display the armor that the character selected previously before starting a run.
        //Selected Armor List.
        armorSlotAmount = 7;
        armorDatabase = GetComponent<ArmorDatabase>();
        equippedArmorPanel = inventoryPanel.transform.Find("CollectedArmor").gameObject;
        for (int h = 0; h < armorSlotAmount; h++)
        {
            armor.Add(new Armor());
            GameObject slotForArmor = Instantiate(inventorySlot);
            slotForArmor.transform.SetParent(equippedArmorPanel.transform);
            slotForArmor.transform.localPosition = new Vector3(slotForArmor.transform.localPosition.x, slotForArmor.transform.localPosition.y, 0);
            slotForArmor.transform.localScale = new Vector3(1, 1, 1);
            slotsForArmor.Add(slotForArmor);

        }

        

        AddItem(1);
        AddItem(2);
        AddSelectedArmorToInventoryList(0);
        AddSelectedArmorToInventoryList(1);
        //AddActiveItemToInventoryList(1);
        //AddActiveItemToInventoryList(0);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = itemDatabase.FetchItemByID(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                //GameObject itemObjUI = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slotsForItems[i].transform);
                //itemObjUI.transform.SetParent(slotsForActiveItems[i].transform);
                itemObj.transform.localPosition = Vector2.zero;
                //itemObjUI.transform.localPosition = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                //itemObjUI.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;
                //itemObjUI.name = itemToAdd.Title;
                //itemObjUI.GetComponent<InventoryItemEventTriggers>().SetID(itemToAdd.ID);

                //activeItemsList.Add(itemToAdd.Slug);
                maxItems += 1;
                break;
            }
        }
    }

     //Currently working function.
    public void AddActiveItemToInventoryList(int id, int buttonPosition)
    {
        ActiveItem activeItemToAdd = activeItemDatabase.FetchItemByID(id);
        activeItems[buttonPosition] = activeItemToAdd;
        if (buttonPosition == 1)
        {
            GameObject itemObj = Instantiate(rightActiveItem);
            itemObj.transform.SetParent(slotsForActiveItems[buttonPosition].transform);
            itemObj.transform.localPosition = Vector2.zero;
            itemObj.GetComponent<Image>().sprite = activeItemToAdd.Sprite;
            itemObj.name = activeItemToAdd.Title;
        }
        else
        {
            GameObject itemObj = Instantiate(leftActiveItem);
            itemObj.transform.SetParent(slotsForActiveItems[buttonPosition].transform);
            itemObj.transform.localPosition = Vector2.zero;
            itemObj.GetComponent<Image>().sprite = activeItemToAdd.Sprite;
            itemObj.name = activeItemToAdd.Title;
        }
        
    }

   


    void AddSelectedArmorToInventoryList(int id)
    {
        Armor armorToAddToInventory = armorDatabase.FetchArmorByID(id);
        for (int i = 0; i < armor.Count; i++)
        {
            if (armor[i].ID == -1)
            {
                armor[i] = armorToAddToInventory;
                GameObject itemObj = Instantiate(inventoryArmor);
                itemObj.transform.SetParent(slotsForArmor[i].transform);
                itemObj.transform.localPosition = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = armorToAddToInventory.Sprite;
                itemObj.name = armorToAddToInventory.Title;
                //itemObj.GetComponent<InventoryItemEventTriggers>().SetID(itemToAddB.ID);

                activeItemsList.Add(armorToAddToInventory.Description);
                break;
            }
        }
    }

    void Update()
    {
        if (GameMaster.gameMaster.isPaused == true)
            transform.position = new Vector2(0, 0);
        else
            transform.position = new Vector2(0, -1000);

        

        
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            //arrayNumber -= 1;
            //Debug.Log(arrayNumber);
            //(names, "Pup2");
            AddItem(1);
            //activeItemsList.Add("Penis gloves");
            //maxItems += 1;  

        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            //arrayNumber -= 1;
            //Debug.Log(arrayNumber);
            //(names, "Pup2");
            //Debug.Log(activeItemsList[nameCount]);
            Debug.Log("name Count:" + nameCount);
            Debug.Log("max items:" + maxItems);

        }

        
    }

}
