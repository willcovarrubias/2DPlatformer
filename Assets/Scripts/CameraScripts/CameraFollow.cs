using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Player target;
	//public Controller2D target;
	float verticalOffset = 8;
	public float lookAheadDstX;
	public float lookSmoothTimeX;
	public float verticalSmoothTime;
	public Vector2 focusAreaSize;
    float tempVerticalOffset;


	FocusArea focusArea;

	float currentLookAheadX;
	float targetLookAheadX;
	float lookAheadDirX;
	float smoothLookVelocityX;
	float smoothVelocityY;

	bool lookAheadStopped;

	public static float yPosRestriction;
	public static float yPosRestrictionUp;
	public static float xPosRestriction;
	public static float xPosRestrictionRight;

    //public float zoomOutAmount = -20;
    public Camera thisCamera;

	void Start()
    {
        
        focusArea = new FocusArea(target.GetComponent<Collider2D>().bounds, focusAreaSize);
        thisCamera = GetComponent<Camera>();
	}

	void Update() {

        //test below:
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //This clamps the camera when the player is in a boss fight.
        if (GameMaster.gameMaster.inABossFight == true) 
		{
            thisCamera.orthographicSize = 66;
            Vector3 newPos = new Vector3 (xPosRestriction, yPosRestriction, -1);
            transform.position = newPos;

        }
        else
		{
            thisCamera.orthographicSize = 180;

            
                focusArea.Update(target.GetComponent<Collider2D>().bounds);

                Vector2 focusPosition = focusArea.centre + Vector2.up * verticalOffset;
                //Camera.main.orthographicSize = 6;

                if (focusArea.velocity.x != 0)
                {
                    lookAheadDirX = Mathf.Sign(focusArea.velocity.x);

                    if (Mathf.Sign(input.x) == Mathf.Sign(focusArea.velocity.x) && input.x != 0)
                    {
                        if (Mathf.Sign(input.x) == Mathf.Sign(focusArea.velocity.x) && input.x != 0)
                        {
                            lookAheadStopped = false;
                            targetLookAheadX = lookAheadDirX * lookAheadDstX;
                        }
                        else
                        {
                            if (!lookAheadStopped)
                            {
                                lookAheadStopped = true;
                                targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX) / 4f;
                            }
                        }

                    }
                }

                currentLookAheadX = Mathf.SmoothDamp(currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);

                if (Input.GetAxis("RStickVertical") > 0)
                {
                    focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y - 20, ref smoothVelocityY, verticalSmoothTime);
                }
                else if (Input.GetAxis("RStickVertical") < 0)
                {
                    focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y + 20, ref smoothVelocityY, verticalSmoothTime);
                }
                else
                {
                    focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
                }

                focusPosition += Vector2.right * currentLookAheadX;
                transform.position = (Vector3)focusPosition + Vector3.forward * -10;

            
		}
	}
			

	void OnDrawGizmos() {
		Gizmos.color = new Color (1, 0, 0, .5f);
		Gizmos.DrawCube (focusArea.centre, focusAreaSize);
	}

	struct FocusArea {
		public Vector2 centre;
		public Vector2 velocity;
		float left,right;
		float top,bottom;


		public FocusArea(Bounds targetBounds, Vector2 size) {
			left = targetBounds.center.x - size.x/2;
			right = targetBounds.center.x + size.x/2;
			bottom = targetBounds.min.y;
			top = targetBounds.min.y + size.y;

			velocity = Vector2.zero;
			centre = new Vector2((left+right)/2,(top +bottom)/2);
		}

		public void Update(Bounds targetBounds) {
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bottom) {
				shiftY = targetBounds.min.y - bottom;
			} else if (targetBounds.max.y > top) {
				shiftY = targetBounds.max.y - top;
			}
			top += shiftY;
			bottom += shiftY;
			centre = new Vector2((left+right)/2,(top +bottom)/2);
			velocity = new Vector2 (shiftX, shiftY);
		}
	}

}