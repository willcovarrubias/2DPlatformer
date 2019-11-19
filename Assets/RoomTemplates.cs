using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] topOpenRooms;
    public GameObject[] bottomOpenRooms;
    public GameObject[] leftOpenRooms;
    public GameObject[] rightOpenRooms;

    public GameObject closedRoom;
    public GameObject bossRoom;

    public GameObject objectWithCameraBoundaryHitBox;
    private BoxCollider2D cameraBoundary;
    public GameObject objectWithVirtualCamera;
    private Cinemachine.CinemachineConfiner cinemachineConfiner;

    public float furthestPointEast = 0.0f;

    public float waitTime;
    private bool bossSpawned;

    public List<GameObject> rooms;

    private void Start()
    {
        cameraBoundary = objectWithCameraBoundaryHitBox.GetComponent<BoxCollider2D>();
        cinemachineConfiner = objectWithVirtualCamera.GetComponent<Cinemachine.CinemachineConfiner>();

        Invoke("SetCameraRestraints", 3f);
    }

    private void Update()
    {
        //if (waitTime <= 0 && !bossSpawned)
        //{
        //    Instantiate(bossRoom, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
        //    bossSpawned = true;
        //}
        //else
        //{
        //    waitTime -= Time.deltaTime;
        //}
    }

    public void SetCameraRestraints()
    {
        var xOffset = (((furthestPointEast + 15) / 100) * 50) - 15;
        cameraBoundary.offset = new Vector2(xOffset, 0);
        cameraBoundary.size = new Vector2(furthestPointEast + 15, 40);

        cinemachineConfiner.InvalidatePathCache();
    }
}
