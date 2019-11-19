using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates roomTemplates;

    public Transform furthestPointEast;

    // Start is called before the first frame update
    void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplates").GetComponent<RoomTemplates>();
        roomTemplates.rooms.Add(this.gameObject);

        roomTemplates.furthestPointEast = furthestPointEast.transform.position.x;

        
        

        Debug.Log($"The furthest point East is now {roomTemplates.furthestPointEast}.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
