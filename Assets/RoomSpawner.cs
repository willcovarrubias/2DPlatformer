using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int directionOfNextRoom; //  1 --> bottom,   2 --> top,   3 --> left,   4 --> right

    private RoomTemplates roomTemplates;
    private int randomRoom;
    private bool spawned = false;
    private bool collisionHappened = false;

    private  float waitTimeBeforeDestroying = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTimeBeforeDestroying);
        roomTemplates = GameObject.FindGameObjectWithTag("RoomTemplates").GetComponent<RoomTemplates>();

        Invoke("SpawnRooms", .1f);
    }

    private void SpawnRooms()
    {
        if (spawned == false  && roomTemplates.rooms.Count < 10)
        {
            if (directionOfNextRoom == 1)
            {
                // Need to spawn a room with a BOTTOM door.
                randomRoom = Random.Range(0, roomTemplates.bottomOpenRooms.Length);
                Instantiate(roomTemplates.bottomOpenRooms[randomRoom], transform.position, roomTemplates.bottomOpenRooms[randomRoom].transform.rotation);
            }
            else if (directionOfNextRoom == 2)
            {
                // Need to spawn a room with a TOP door.
                randomRoom = Random.Range(0, roomTemplates.topOpenRooms.Length);
                Instantiate(roomTemplates.topOpenRooms[randomRoom], transform.position, roomTemplates.topOpenRooms[randomRoom].transform.rotation);
            }
            else if (directionOfNextRoom == 3)
            {
                // Need to spawn a room with a LEFT door.
                randomRoom = Random.Range(0, roomTemplates.leftOpenRooms.Length);
                Instantiate(roomTemplates.leftOpenRooms[randomRoom], transform.position, roomTemplates.leftOpenRooms[randomRoom].transform.rotation);
            }
            else if (directionOfNextRoom == 4)
            {
                // Need to spawn a room with a RIGHT door.
                randomRoom = Random.Range(0, roomTemplates.rightOpenRooms.Length);
                Instantiate(roomTemplates.rightOpenRooms[randomRoom], transform.position, roomTemplates.rightOpenRooms[randomRoom].transform.rotation);
            }

            
            spawned = true;
        }

        //if (!collisionHappened && roomTemplates.rooms.Count >= 20)
        //{
        //    Instantiate(roomTemplates.closedRoom, transform.position, Quaternion.identity);
        //}


    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "SpawnPoint")
    //    {
    //        try
    //        {
    //            if (!collision.GetComponent<RoomSpawner>().spawned && !spawned)
    //            {
    //                Instantiate(roomTemplates.closedRoom, transform.position, Quaternion.identity);
    //                Destroy(gameObject);
    //            }
    //        }
    //        catch (System.Exception e)
    //        {

    //        }
    //        spawned = true;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpawnPoint")
        {
            collisionHappened = true;

            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {

                Instantiate(roomTemplates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            spawned = true;
        }
    }
}
