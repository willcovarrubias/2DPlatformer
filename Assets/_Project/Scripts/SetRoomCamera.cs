using UnityEngine;
using System.Collections;

public class SetRoomCamera : MonoBehaviour {


    public Transform centerPoint;
    public int roomOrthoSize;
    GameObject mainCamera;
    GameObject mainCameraScript;
    //public static Vector3 mainCameraTarget;
    //public float speed;
    // Use this for initialization
    void Start () {

        mainCamera = GameObject.FindGameObjectWithTag("Camera");
        mainCamera.GetComponent<MainCameraScript>();
        //mainCameraTarget = new Vector3(10, 0, -1);

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            mainCamera = GameObject.FindGameObjectWithTag("Camera");
            mainCamera.GetComponent<MainCameraScript>().mainCameraTarget = new Vector3(centerPoint.position.x, centerPoint.position.y, -1);
            mainCamera.GetComponent<Camera>().orthographicSize = roomOrthoSize;

            //mainCamera.mainCameraTarget = new Vector3(100,100, -1);
        }
    }

    void SetCameraPosition()
    {
        
        Debug.Log(centerPoint.position);
        
    }
}
