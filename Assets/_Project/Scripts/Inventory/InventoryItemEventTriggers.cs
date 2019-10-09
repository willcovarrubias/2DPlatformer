using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryItemEventTriggers : MonoBehaviour {

    bool testBool1;
    bool testBool2;
    //EventTrigger trigger;
   // private AudioListener audioListener;
    public int identifier;
    // Use this for initialization
    ActiveItemsUIScript activeItemScript;
    GameObject activeItem;

    void Awake()
    {
        //audioListener = GetComponent<AudioListener>();
        //EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        //EventTrigger.Entry entry = new EventTrigger.Entry();
        //entry.eventID = EventTriggerType.Select;
        //entry.callback = new EventTrigger.TriggerEvent();
        //UnityAction<BaseEventData> l_callback = new UnityAction<BaseEventData>(OnSelectOption);
        //entry.callback.AddListener(l_callback);
        //trigger.triggers.Add(entry);
    }

    void Start () {
       /* if (identifier == 0)
        {
            //activeItem.GetComponent<ActiveItemsUIScript>().Select(0);
            Debug.Log("This is item 0");
            //testBool1 = true;
            //GameMaster.gameMaster.currentActiveItem = GameMaster.CurrentActiveItem.activeItem000;
            //GameMaster.gameMaster.activeItem001isOn = true;
        }


        if (identifier == 1)
        {
            //activeItem.GetComponent<ActiveItemsUIScript>().Select(0);
            Debug.Log("This is item 1");
            // GameMaster.gameMaster.currentActiveItem = GameMaster.CurrentActiveItem.activeItem001;
            //GameMaster.gameMaster.activeItem002isOn = true;
        }

        if (identifier == 2)
        {
            //activeItem.GetComponent<ActiveItemsUIScript>().Select(0);
            Debug.Log("This is item 2");
            // GameMaster.gameMaster.currentActiveItem = GameMaster.CurrentActiveItem.activeItem002;
            //GameMaster.gameMaster.activeItem003isOn = true;
        }*/



        //activeItem = GameObject.FindGameObjectWithTag("ActiveItem");
        //activeItem = activeItem.GetComponent<ActiveItemsUIScript>().gameObject;
    }

    private void OnSelectOption(BaseEventData eventData)
    {
        
        if (identifier == 0)
        {
            activeItem.GetComponent<ActiveItemsUIScript>().Select(0);
            Debug.Log("This is item 0");
        }
        if (identifier == 1)
        {
            activeItem.GetComponent<ActiveItemsUIScript>().Select(1);
            Debug.Log("This is item 1");
        }
        if (identifier == 2)
        {
            activeItem.GetComponent<ActiveItemsUIScript>().Select(2);
            Debug.Log("This is item 2");
        }

       
    }

    // Update is called once per frame
    void Update () {

        //Debug.Log("Test Bool 1:" + testBool1);
        //Debug.Log("Test Bool 2:" + testBool2);
         /*if (identifier == 0)
        {
            //activeItem.GetComponent<ActiveItemsUIScript>().Select(0);
            Debug.Log("This is item 0");
            //testBool1 = true;
            //GameMaster.gameMaster.currentActiveItem = GameMaster.CurrentActiveItem.activeItem000;
            //GameMaster.gameMaster.activeItem001isOn = true;
        }*/


        if (identifier == 1)
        {
            //activeItem.GetComponent<ActiveItemsUIScript>().Select(0);
            //Debug.Log("This is item 1");
            GameMaster.gameMaster.currentActiveItem = GameMaster.CurrentActiveItem.activeItem001;
            //GameMaster.gameMaster.activeItem002isOn = true;
        }

        if (identifier == 2)
        {
            //activeItem.GetComponent<ActiveItemsUIScript>().Select(0);
            //Debug.Log("This is item 2");
            GameMaster.gameMaster.currentActiveItem = GameMaster.CurrentActiveItem.activeItem002;
            //GameMaster.gameMaster.activeItem003isOn = true;
        }
        if (identifier == 3)
        {
            //activeItem.GetComponent<ActiveItemsUIScript>().Select(0);
            //Debug.Log("This is item 2");
            GameMaster.gameMaster.currentActiveItem = GameMaster.CurrentActiveItem.activeItem003;
            //GameMaster.gameMaster.activeItem003isOn = true;
        }
    }

    public void SetID(int id)
    {
        identifier = id;
    }
}
