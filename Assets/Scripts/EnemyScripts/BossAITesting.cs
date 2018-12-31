using UnityEngine;
using System.Collections;

public class BossAITesting : MonoBehaviour {

	int waitTime = 80;
	int timer = 0;
	public int speed = 2;
	int direction;
	bool whatWay = true;
	Vector3 vector_direction;

	void Update() {

		timer += 1;
		if(timer >= waitTime)
		{
			timer = 0;
			direction = Random.Range(0, 4);

			/*if(whatWay == true)
			{
				whatWay = false;
				return;
			}

			if(whatWay == false)
			{
				whatWay = true;
				return;
			}*/
		}

		transform.Translate(vector_direction * Time.deltaTime);

		if(direction == 0)
		{
			//transform.localScale.x = -5;
			vector_direction = (new Vector3(-speed, 0,0));
		}

		if(direction == 1)
		{
			//transform.localScale.x = 5;
			vector_direction = (new Vector3(speed, 0,0));
		}

		if(direction == 2)
		{
			//transform.localScale.x = -5;
			vector_direction = (new Vector3(0, speed, 0));
		}
		
		if(direction == 3)
		{
			//transform.localScale.x = 5;
			vector_direction = (new Vector3(0, -speed, 0));
		}


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		direction =4;

		if(other.gameObject.tag == "TopMax")
		{
			vector_direction = (new Vector3(0, -speed,0));
			Debug.Log("Hit max, going down!");
		}

		if(other.gameObject.tag == "BottomMax")
		{
			vector_direction = (new Vector3(0, speed,0));
			Debug.Log("Hit max, going up!");
		}

		if(other.gameObject.tag == "RightMax")
		{
			vector_direction = (new Vector3(-speed, 0,0));
			Debug.Log("Hit max, going left!");
		}

		if(other.gameObject.tag == "LeftMax")
		{
			vector_direction = (new Vector3(speed, 0,0));
			Debug.Log("Hit max, going right!");
		}
	}
}
