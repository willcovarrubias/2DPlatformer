using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {

    public static MainCameraScript mainCameraScript;
    public Transform mainCamera;
    public Vector3 mainCameraTarget;
    public float speed;
    // Use this for initialization
    void Start () {
        mainCameraTarget = new Vector3(0, 0, -10);

    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        mainCamera.position = Vector3.MoveTowards(mainCamera.position, mainCameraTarget, step);

    }
}
