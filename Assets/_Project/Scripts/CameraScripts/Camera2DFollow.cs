using System.Collections;
using UnityEngine;


    public class Camera2DFollow : MonoBehaviour {
	
		public static Camera2DFollow camera2DFollow;
		public GameObject target;
        public float damping = 1;
        public float lookAheadFactor;
        public float lookAheadReturnSpeed;
        public float lookAheadMoveThreshold;
		
		public float lookUpFactor;
		public float lookUpReturnSpeed;
		public float lookUpMoveThreshold;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;
	private Vector3 m_LookUpPos;
		//public static float yPosRestriction;
		//public static float yPosRestrictionUp;
		//public static float xPosRestriction;
		//public static float xPosRestrictionRight;
		Vector3 cursorPos;

	public float testFloat;

	//public float sensitivityX = 10F;
	//public float sensitivityY = 10F;
	
	//public float minimumX = -360F;
	//public float maximumX = 360F;
	
	//public float minimumY;
	//public float maximumY;
	
	//float positionY = 0F;
	//float positionX = 0F;
	
	//public float cameraSpeedFloat;
	
	Transform cameraTransform;

	//private int theScreenWidth;
	//private int theScreenHeight;
	//public int boundary = 50;

        // Use this for initialization
        private void Start()
        {
        //yPosRestriction = 3.5f;
        //yPosRestrictionUp = 3.5f;
        //xPosRestriction = 8;
        //xPosRestrictionRight = 8;
        Invoke("FindPlayer", 1);
		cameraTransform = transform;
		target = GameObject.FindGameObjectWithTag("Player");

		//theScreenWidth = Screen.width;
		//theScreenHeight = Screen.height;

			m_LastTargetPosition = target.transform.position;
            m_OffsetZ = (transform.position - target.transform.position).z;
            transform.parent = null;
        }


    void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
        // Update is called once per frame
        private void Update()
        {
            
			// only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.transform.position - m_LastTargetPosition).x;

		/*testingbelow:
			float yMoveDelta = (target.transform.position - m_LastTargetPosition).y;
		bool updateLookUpTarget = Mathf.Abs(yMoveDelta) > lookUpMoveThreshold;*/

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

		//testingbelow:
			/*if (updateLookUpTarget)
			{
			m_LookUpPos = lookUpFactor*Vector3.up*Mathf.Sign(yMoveDelta);
			}
			else
			{
			m_LookUpPos = Vector3.MoveTowards(m_LookUpPos, Vector3.zero, Time.deltaTime*lookUpReturnSpeed);
			}*/


            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.transform.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);



          	
			//newPos = new Vector3 (Mathf.Clamp (newPos.x, xPosRestriction, xPosRestrictionRight), Mathf.Clamp (newPos.y, yPosRestriction, yPosRestrictionUp), newPos.z);
		//newPos = new Vector3 (Mathf.Clamp (newPos.x, xPosRestriction, xPosRestrictionRight), (target.transform.position.y + testFloat), newPos.z);
			//transform.position = newPos;


            m_LastTargetPosition = target.transform.position;

		/*	if (Input.mousePosition.x > target.transform.position.x)
		{
			Debug.Log("Right limit");
			positionX += Input.GetAxis("Mouse X") * sensitivityX;
			//positionX = Mathf.Clamp (positionX, minimumX, maximumX);
			
			cameraTransform.position = new Vector3(target.transform.position.x + positionX, newPos.y, transform.position.z);
			//cameraTransform.position.x += speed * Time.deltaTime;
		}
		if (Input.mousePosition.x < target.transform.position.x)
		{
			Debug.Log("Left limit");
			
			positionX -= Input.GetAxis("Mouse X") * sensitivityX;
			//positionX = Mathf.Clamp (positionX, minimumX, maximumX);
			
			cameraTransform.position = new Vector3(target.transform.position.x + -positionX, newPos.y, transform.position.z);
			//cameraTransform.position.x -= speed * Time.deltaTime;
		}
		if(Input.mousePosition.y > target.transform.position.y)
			{
			Debug.Log("North limit");
			
			
			positionY += Input.GetAxis("Mouse Y") * sensitivityY;
			//positionY = Mathf.Clamp(10, target.transform.position.y, 20);
			//positionY = Mathf.Clamp (target.transform.position.y, target.transform.position.y, Input.mousePosition.y);
			
			//cameraTransform.position = new Vector3(newPos.x, positionY, transform.position.z);

			cameraTransform.position = new Vector3(newPos.x, target.transform.position.y + positionY, transform.position.z);
			//cameraTransform.position.y += speed * Time.deltaTime;
		}
	}

		if(Input.mousePosition.y < target.transform.position.y)
		{
			Debug.Log("South limit");
			
			
			positionY -= Input.GetAxis("Mouse Y") * sensitivityY;
			//positionY = Mathf.Clamp(10, target.transform.position.y, 5);
			//positionY = Mathf.Clamp (target.transform.position.y, target.transform.position.y, -Input.mousePosition.y);
			
			//cameraTransform.position = new Vector3(newPos.x, -positionY, transform.position.z);
			cameraTransform.position = new Vector3(newPos.x, target.transform.position.y + -positionY, transform.position.z);
			//cameraTransform.position.y -= speed * Time.deltaTime;
		}
        }

	void OnGUI() 
	{
		GUI.Box( new Rect( (Screen.width / 2) - 140, 5, 280, 25 ), "Mouse Position = " + Input.mousePosition );
		GUI.Box( new Rect( (Screen.width / 2) - 70, Screen.height - 30, 140, 25 ), "Mouse X = " + Input.mousePosition.x );
		GUI.Box( new Rect( 5, (Screen.height / 2) - 12, 140, 25 ), "Mouse Y = " + Input.mousePosition.y );
	}*/
	}
    }

