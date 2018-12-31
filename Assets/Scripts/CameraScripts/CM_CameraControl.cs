using UnityEngine;
using System.Collections;

public class CM_CameraControl : MonoBehaviour {

	public Transform MainCamera;
	Vector3 target;
	public float speed;
	// Use this for initialization
	void Start () {
		target = new Vector3 (0, 0, -10);
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		MainCamera.position = Vector3.MoveTowards(MainCamera.position, target, step);
	}

	public void MoveCamToCharacter04()
	{
		//camera.transform.position.y = 10;
		//camera.position = new Vector3(0, -30, -10);
		Debug.Log ("This buttons is chosen");
		target = new Vector3 (0, 0, -10);

		//Vector2 dir =  new Vector2(0, camera.gameObject.transform.position.y - 10);
		//dir *= cameraMovementSpeed * Time.deltaTime;
	}

	public void MoveCamToCharacter05()
	{		
		target = new Vector3 (90, 0, -10);
   	}
    public void MoveCamToCharacter06()
    {
        target = new Vector3(100, -0, -10);
    }

    public void MoveCamToCenter(float xPos)
    {
        target = new Vector3(xPos, 0, -10);
    }
}
