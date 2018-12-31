using UnityEngine;
using System.Collections;

public class PickupTesterScript : MonoBehaviour {

    public int itemIdentifier;
    private bool m_isAxisInUse = false;

    void Update()
    {
        if (Input.GetAxisRaw("Triggers") == 0)
        {
            m_isAxisInUse = false;
        }
        if (Input.GetAxis("Triggers") > 0 || Input.GetAxis("Triggers") < 0)
        {
            m_isAxisInUse = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetAxis("Triggers") > 0 && m_isAxisInUse == false)
            {
                m_isAxisInUse = true;
                AddItemToLeftBumper(itemIdentifier);
                Destroy(gameObject);
            }
            if (Input.GetAxis("Triggers") < 0 && m_isAxisInUse == false)
            {
                m_isAxisInUse = true;
                AddItemToRightBumper(itemIdentifier);
                Destroy(gameObject);
            }
        }


    }

    void AddItemToLeftBumper(int identifier)
    {
        GameObject inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        inventoryObj.GetComponent<Inventory>();
        //if (itemIdentifier == identifier)
        inventoryObj.GetComponent<Inventory>().AddActiveItemToInventoryList(identifier, 0);
    }

    void AddItemToRightBumper(int identifier)
    {
        GameObject inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        inventoryObj.GetComponent<Inventory>();
        //if (itemIdentifier == identifier)
        inventoryObj.GetComponent<Inventory>().AddActiveItemToInventoryList(identifier, 1);
    }

    IEnumerator TriggerPickupEffects()
    {
        yield return new WaitForSeconds(5);
    }
}
