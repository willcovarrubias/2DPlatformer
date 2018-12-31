using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public static Player player;
    

    public float maxJumpHeight = 100;
    public float minJumpHeight = 50;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 120;

    Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    public Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    bool flightOn;
    bool alreadyJumped;
    bool doubleJumpIsOn;
    bool landed;
    float dodgeSpeed;
    private float dodgeRate = .75f;
    private float nextDodge;
    public float dodgeDuration = 10f;
    public bool takingDamage = false;
    public bool playerisDead = false;

    
    public bool onTheGround;
    public bool slidingAgainstAWall;
    public bool currentlyDodging;
    public bool currentlyJumping;
    public bool currentlyDucking;
    Animator anim;
    public bool facingRight;
    public Transform tf;
    public Transform jumpDustTransform;
    public Transform wallJumpDustTransform;

    public GameObject jumpDust;
    public GameObject wallJumpDust;

    //Attributes for death animations.
    public int[] CharacterIdentifier;

    private PlayerAttack playerAttack;

    



    public bool GetCurrentlyDodging()
    {
        return currentlyDodging;
    }

    public void SetCurrentlyDodging(bool value)
    {
        currentlyDodging = value;
    }

    void Start()
    {
        wallJumpClimb = new Vector2(200, 360);
        //90 / 225
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);

        //test
        anim = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        
    }

    void Update()
    {

       




        if (GameMaster.gameMaster.isPaused == false && !GameMaster.gameMaster.inACutscene)
        {
            Vector2 input;
            if (!takingDamage && !playerisDead)
            {
                input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            else
            {
                input = new Vector2(0,0);
            }
            
            int wallDirX = (controller.collisions.left) ? -1 : 1;

            if (velocity.x > 0)
                FaceRight();
            else if (velocity.x < 0)
                FaceLeft();

            float targetVelocityX = input.x * moveSpeed;
            //test
            float targetVelocityY = input.y * moveSpeed;

            anim.SetFloat("Velocity", Mathf.Abs(targetVelocityX));


            if (controller.collisions.below)
            {
                onTheGround = true;
            }
            else
            {
                onTheGround = false;
            }


            //change this bool to true in gamemaster if this character has the ability to double jump or not.
            bool wallSliding = false;

            //Used for wall shooting.
            slidingAgainstAWall = false;
            anim.SetBool("Wallhugging", false);
            //currentlyDodging = false;
            //currentlyJumping = false;
            anim.SetBool("Dodging", false);


            //This If statement determines whether or not wall jumping happens.
            if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
            {

                

                wallSliding = true;

                slidingAgainstAWall = true;
                //anim.SetBool("Wallhugging", true);
                //anim.Play("Wallhugging");
                anim.SetBool("Wallhugging", true);

                if (velocity.y < -wallSlideSpeedMax)
                {
                    velocity.y = -wallSlideSpeedMax;
                }

                if (timeToWallUnstick > 0)
                {
                    velocityXSmoothing = 0;
                    velocity.x = 0;

                    if (input.x != wallDirX && input.x != 0)
                    {
                        timeToWallUnstick -= Time.deltaTime;
                    }
                    else
                    {
                        timeToWallUnstick = wallStickTime;
                    }
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }

            }


            //CROUCHING LOGIC
            if (input.y == -1 && velocity.y >= 0 && Input.GetAxis("Horizontal") == 0 && !playerAttack.currentlySwitchingAnimator && onTheGround)
            {
                anim.SetBool("Ducking", true);
                currentlyDucking = true;
            }
            else
            {
                anim.SetBool("Ducking", false);
                currentlyDucking = false;
            }

            //LOOKING UP
            if (Input.GetAxis("Vertical") > .9f && Input.GetAxis("Horizontal") == 0 && !playerAttack.currentlySwitchingAnimator && !currentlyDodging && !wallSliding && !playerisDead)
            {
                anim.SetBool("LookingUp", true);
            }
            else
            {
                anim.SetBool("LookingUp", false);
            }

            
            //Jumping logic.
            if (Input.GetButtonDown("Jump") && input.y != -1 &&  !playerAttack.currentlySwitchingAnimator && !takingDamage && !playerisDead)
            {
                if (wallSliding)
                {
                    if (wallDirX == input.x)
                    {
                        velocity.x = -wallDirX * wallJumpClimb.x;
                        velocity.y = wallJumpClimb.y;
                    }
                    else if (input.x == 0)
                    {
                        velocity.x = -wallDirX * wallJumpOff.x;
                        velocity.y = wallJumpOff.y;
                    }
                    else
                    {
                        velocity.x = -wallDirX * wallLeap.x;
                        velocity.y = wallLeap.y;
                    }
                }
                if (controller.collisions.below)
                {
                    JumpDust();
                    velocity.y = maxJumpVelocity;
                    alreadyJumped = true;
                    anim.SetBool("Jumping", true);
                    anim.SetBool("Ducking", false);

                }

               

                //Double jump
                //if double jump enabled etc.
                if (doubleJumpIsOn == false)
                {
                    if (Input.GetButtonDown("Jump") && alreadyJumped == true && !controller.collisions.below && !wallSliding)
                    {
                        velocity.y = maxJumpVelocity;
                        alreadyJumped = false;
                        anim.Play("DoubleJump");
                        Debug.Log("Double jump being called!");
                        JumpDust();
                    }




                }

            }
            if (Input.GetButtonUp("Jump") )
            {
                if (velocity.y > minJumpVelocity)
                {
                    velocity.y = minJumpVelocity;
                    
                }
            }

           
            

           

            //test: dodges/dash/rolls
            //quick teleports that go left and right
            /*
            if (controller.collisions.below && Input.GetKeyDown(KeyCode.E) && input.x > 0)
            {
                controller.Move(velocity, Vector2.right);
                Debug.Log("Testing dodges!");
            }
            if (controller.collisions.below && Input.GetKeyDown(KeyCode.E) && input.x < 0)
            {
                controller.Move(velocity, Vector2.left );
                Debug.Log("Testing dodges!");
            }*/

            //Test:: simpler dodge. I can set the dodgeSpeed via code and whether or not dodges are allowed.
            //If dodges are allowed, do the following:
            /*if (controller.collisions.below && Input.GetAxisRaw("Triggers") > 0.001 && input.x > 0 && controller.collisions.right == false)
            {
                dodgeSpeed =300;
                velocity.x = dodgeSpeed;
                anim.SetBool("Dodging", true);
            }
            if (controller.collisions.below && Input.GetAxis("Triggers") > 0.001 && input.x < 0 && controller.collisions.left == false)
            {
                dodgeSpeed = 300;
                velocity.x = -dodgeSpeed;
                anim.SetBool("Dodging", true);
                Debug.Log("I'm hitting the dash button!");
            }*/






            //Working Dodge timer
            /*
            if (Time.timeScale == 0)
                return;

            if (input.x > 0 && onTheGround && Input.GetButtonDown("Dodge") && GetCurrentlyDodging() == false)
            {
                dodgeSpeed = 400;
                velocity.x = dodgeSpeed;
                anim.Play("Dodging");
                SetCurrentlyDodging(true);

            }
            else
            {
                if (input.x > 0 && onTheGround && Input.GetButtonDown("Dodge") && Time.time > timeToDodge)
                {
                    SetCurrentlyDodging(false);
                    timeToDodge = Time.time + 1;

                }
            }



                    //if (controller.collisions.below && Input.GetAxisRaw("Triggers") != 0 && input.x < 0 && controller.collisions.left == false)
            if (input.x < 0 && onTheGround && Input.GetButtonDown("Dodge") && GetCurrentlyDodging() == false)
            {
                        //anim.SetBool("Dodging", true);
                dodgeSpeed = 400;
                velocity.x = -dodgeSpeed;
                anim.Play("Dodging");
                SetCurrentlyDodging(true);
            }
            else
            {
                if (input.x < 0 && onTheGround && Input.GetButtonDown("Dodge") && Time.time > timeToDodge)
                {
                    timeToDodge = Time.time + 1;
                    SetCurrentlyDodging(false);
                }
            }
            */



            //test Flight
            if (flightOn == true)
            {
                if (input.y > 0)
                    velocity.y = targetVelocityY;
                else if (input.y < 0)
                    velocity.y = targetVelocityY;
                else
                    velocity.y = 0;
                //test
                velocity.y = Mathf.SmoothDamp(velocity.y, targetVelocityY, ref velocityXSmoothing, 0, 0);
                velocity.x = targetVelocityX;
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
                velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            }


            //Moves the character.
            controller.Move(velocity * Time.deltaTime, input);
    

         


            //Sets animator for jumping animations.
            if (controller.collisions.below)
            {
                velocity.y = 0;

                //test
                anim.SetBool("Jumping", false);

            }
            
            if (!controller.collisions.below && velocity.y < 0)
                anim.SetBool("Jumping", true);



            //test
            if (Input.GetKeyDown(KeyCode.N))
            {
                flightOn = true;
                Debug.Log("Flight's on!");
            }
            if (Input.GetKeyDown(KeyCode.M))
                flightOn = false;

            if (Input.GetKeyDown(KeyCode.B))
                anim.Play("ShortySpecial");



            
            
            
        }
    }

    public void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Time.time > nextDodge && !playerisDead)
        {

            if (!facingRight && (onTheGround && velocity.y == 0) && Input.GetButtonDown("Dodge") && !Input.GetButtonDown("Jump") && !playerAttack.currentlySwitchingAnimator)
            {
                SlideLeft();

            }
            else if (facingRight && (onTheGround && velocity.y == 0) && Input.GetButtonDown("Dodge") && !Input.GetButtonDown("Jump") && !playerAttack.currentlySwitchingAnimator)
            {
                SlideRight();
            }
            else
            {
                SetCurrentlyDodging(false);
            }

            if (controller.collisions.below && Input.GetButtonDown("Bash") && facingRight && !playerAttack.currentlySwitchingAnimator && playerAttack.currentlyInMeleeMode)
            {
                
                    dodgeSpeed = 500;
                    velocity.x = dodgeSpeed;
                    anim.Play("DodgeBack");
                    // m_isAxisInUse = true;
                    nextDodge = Time.time + dodgeRate;
                    Invoke("JumpDust", .1f);

                

                //anim.SetBool("Dodging", true);
            }

            //Example of using Triggers as buttons.
            //if (controller.collisions.below && Input.GetAxis("Triggers") < 0 && !playerAttack.currentlySwitchingAnimator && playerAttack.currentlyInMeleeMode)
            if (controller.collisions.below && Input.GetButtonDown("Bash") && !facingRight && !playerAttack.currentlySwitchingAnimator && playerAttack.currentlyInMeleeMode)

            {
                
                    dodgeSpeed = 500;
                    velocity.x = -dodgeSpeed;
                    anim.Play("DodgeBack");
                    // m_isAxisInUse = true;
                    nextDodge = Time.time + dodgeRate;
                    Invoke("JumpDust", .1f);
                

                //anim.SetBool("Dodging", true);
            } 

            /*if (Input.GetAxisRaw("Triggers") == 0)
            {
                m_isAxisInUse = false;
            }*/

        }
    }

    
    public void FaceRight()
    {
        Vector3 theScale = tf.localScale;
        theScale.x = 1;
        facingRight = true;

        tf.localScale = theScale;

    }
    public void FaceLeft()
    {
      
        Vector3 theScale = tf.localScale;
        theScale.x = -1;
        facingRight = false;

        tf.localScale = theScale;     

    }

    void SlideRight()
    {
        nextDodge = Time.time + dodgeRate;
        dodgeSpeed = 500;
        velocity.x = dodgeSpeed;
        anim.Play("Dodging");
        Debug.Log("Dodging right!");
        SetCurrentlyDodging(true);
        JumpDust();
    }

    void SlideLeft()
    {
        SetCurrentlyDodging(true);
        nextDodge = Time.time + dodgeRate;
        dodgeSpeed = 500;
        velocity.x = -dodgeSpeed;
        anim.Play("Dodging");
        Debug.Log("Dodging left!");
        JumpDust();
    }

    void JumpDust()
    {
        Instantiate(jumpDust, jumpDustTransform.position, Quaternion.Euler(0, 0, 0));
    }

    void WallJumpDust()
    {
        Instantiate(wallJumpDust, wallJumpDustTransform.position, Quaternion.Euler(0, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Floor" || other.gameObject.tag == "Through") && controller.collisions.below)
        {
            JumpDust();

        }

        if (other.gameObject.tag == "GrabWall" && (controller.collisions.left || controller.collisions.right))
        {
            WallJumpDust();
        }
    }

}
