using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
[System.Serializable]
public class Player : MonoBehaviour
{
    public static Player PlayerInstance;
    
    //Jumping Properties
    public float maxJumpHeight = 100;
    public float minJumpHeight = 50;
    public float timeToJumpApex = .4f;
    public float moveSpeed = 10;

    private float accelerationTimeAirborne = .2f;
    private float accelerationTimeGrounded = .1f;

    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = 1f;
    float timeToWallUnstick;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    public Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;
    PlayerAttack playerAttack;
    AudioSource audioSource;
    public AudioClip[] audioClips;
    private bool canPlayLandingSound = false;

    public GameObject bloodEffectsSprite, bloodEffectsSprite2, bloodEffectsSprite3;
    public Transform bloodEffectTransformHead, bloodEffectTransformTorso, bloodEffectTransformWeapon;

    bool flightOn;
    bool alreadyJumped;
    bool doubleJumpIsOn;
    bool landed;
    public float slideSpeed;
    public float dodgeBackSpeed;
    private float dodgeRate = .6f;
    private float slideRate = .6f;
    private float nextDodge;
    public float attackRangeX;
    public float attackRangeY;
    public Transform shoulderPos;
    public LayerMask whatToHit;

    //public float dodgeDuration = 10f;
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
        controller = GetComponent<Controller2D>();
        playerAttack = GetComponent<PlayerAttack>();
        audioSource = GetComponent<AudioSource>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {   
        if (GameMaster.gameMaster.isPaused == false && !GameMaster.gameMaster.inACutscene )
        {
            Vector2 input;
            if (!playerisDead && !takingDamage && !playerAttack.playerMeleeing)
            {
                input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            else
            {
                input = new Vector2(0, Input.GetAxis("Vertical"));
            }
            
            int wallDirX = (controller.collisions.left) ? -1 : 1;

            if (input.x > 0)
                FaceRight();
            else if (input.x < 0)
                FaceLeft();

            float targetVelocityX = input.x * moveSpeed;
            float targetVelocityY = input.y * moveSpeed;

            anim.SetFloat("Velocity", Mathf.Abs(targetVelocityX));

            

            //Check if player is on the ground.
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
            //WALL HUGGING LOGIC
            if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0 && !takingDamage)
            {

                if (controller.collisions.left)
                    FaceLeft();
                if (controller.collisions.right)
                    FaceRight();


                wallSliding = true;

                slidingAgainstAWall = true;
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
            if (input.y == -1 && velocity.y >= 0 && Input.GetAxis("Horizontal") == 0 && onTheGround)
            {
                if (!playerAttack.playerMeleeing)
                {
                    anim.SetBool("Ducking", true);
                    currentlyDucking = true;
                }
                    
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

            
            //JUMPING logic.
            if (Input.GetButtonDown("Jump") &&  !playerAttack.currentlySwitchingAnimator && !takingDamage && !playerisDead && !playerAttack.playerMeleeing)
            {
                if (wallSliding)
                {
                    if (wallDirX == input.x)
                    {
                        velocity.x = -wallDirX * wallLeap.x;
                        velocity.y = wallLeap.y;
                        anim.SetTrigger("WallLeap");
                        JumpDust();
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
                if (controller.collisions.below && input.y != -1)
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
                        anim.SetTrigger("DoubleJump");
                        JumpDust();
                    }
                }

            }
            if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > minJumpVelocity)
                {
                    velocity.y = minJumpVelocity;                    
                }
            }           

            //Quick teleports that go left and right
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

            //Example of how to use triggers.
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
                                  
            //test Flight
            //TODO: Fix animations for when the character can fly. Possibly replace the AnimatorController.
            if (flightOn == true)
            {
                if (input.y > 0)
                    velocity.y = targetVelocityY;
                else if (input.y < 0)
                    velocity.y = targetVelocityY;
                else
                    velocity.y = 0;

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
                anim.SetBool("Jumping", false);
                LandNoise();
            }

            if (!controller.collisions.below && velocity.y < 0)
            {
                anim.SetBool("Jumping", true);
                canPlayLandingSound = true;
            }


            //Test for flight.
            //TODO: Remove once a flight item is implemented and flight animations are added.
            if (Input.GetKeyDown(KeyCode.N))
            {
                flightOn = true;
                Debug.Log("Flight's on!");
            }
            if (Input.GetKeyDown(KeyCode.M))
                flightOn = false;

            //Test for specials. 
            //TODO: Add other logic to specials, like restrict movement perhaps?
            if (Input.GetKeyDown(KeyCode.B))
                anim.Play("ShortySpecial");

            //All the sound stuff.
            if ((velocity.x > .1f || velocity.x < -0.1f)&& onTheGround && !audioSource.isPlaying)
            {
                if (velocity.x >= 2.1f || velocity.x <= -2.1f)
                {
                    audioSource.clip = audioClips[0];
                }
                else
                {
                    audioSource.clip = audioClips[1];
                }
                audioSource.pitch = Random.Range(.8f, 1f);
                audioSource.volume = Random.Range(.75f, .9f) / 2;
                audioSource.Play();
            }

            


        }
    }

    public void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 theScale = tf.localScale;        

        if (Time.time > nextDodge && !playerisDead && !playerAttack.currentlyInRangeMode && !playerAttack.playerMeleeing)
        {
            //Sliding logic.
            if (!facingRight && (onTheGround && velocity.y == 0) && Input.GetButtonDown("Slide") && !Input.GetButtonDown("Jump") && !playerAttack.currentlySwitchingAnimator)
            {
                SlideLeft();

            }
            else if (facingRight && (onTheGround && velocity.y == 0) && Input.GetButtonDown("Slide") && !Input.GetButtonDown("Jump") && !playerAttack.currentlySwitchingAnimator)
            {
                SlideRight();
            }
            else
            {
                SetCurrentlyDodging(false);
            }

            //Dodge logic.
            if (facingRight)
            {
                if (controller.collisions.below && Input.GetButtonDown("Dodge_R") && !playerAttack.currentlySwitchingAnimator)
                {
                    velocity.x = slideSpeed;
                    anim.Play("DodgeForward");
                    //ShoulderTackle();
                    SetCurrentlyDodging(true);
                    nextDodge = Time.time + dodgeRate;
                    Invoke("JumpDust", .1f);
                }
                if (controller.collisions.below && Input.GetButtonDown("Dodge_L") && !playerAttack.currentlySwitchingAnimator && input.x == 0)
                {
                    velocity.x = -dodgeBackSpeed;
                    anim.Play("DodgeBack");
                    SetCurrentlyDodging(true);
                    nextDodge = Time.time + dodgeRate;
                    Invoke("JumpDust", .1f);
                }
            }
            else
            { 
                if (controller.collisions.below && Input.GetButtonDown("Dodge_R") && !playerAttack.currentlySwitchingAnimator && input.x == 0)
                {
                    velocity.x = dodgeBackSpeed;
                    anim.Play("DodgeBack");
                    SetCurrentlyDodging(true);
                    nextDodge = Time.time + dodgeRate;
                    Invoke("JumpDust", .1f);
                }
                if (controller.collisions.below && Input.GetButtonDown("Dodge_L") && !playerAttack.currentlySwitchingAnimator)
                {
                    velocity.x = -slideSpeed;
                    anim.Play("DodgeForward");
                   // ShoulderTackle();
                    SetCurrentlyDodging(true);
                    nextDodge = Time.time + dodgeRate;
                    Invoke("JumpDust", .1f);
                }
            }            

            //Example of using Triggers as buttons.
            //if (controller.collisions.below && Input.GetAxis("Triggers") < 0 && !playerAttack.currentlySwitchingAnimator && playerAttack.currentlyInMeleeMode)
        }
    }

    private void ShoulderTackle()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(shoulderPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatToHit);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().DamageEnemy(0, 5, true);

            Debug.Log("Camera should be shaking!");
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
        nextDodge = Time.time + slideRate;
        velocity.x = slideSpeed;
        anim.Play("Dodging");
        Debug.Log("Dodging right!");
        SetCurrentlyDodging(true);
        JumpDust();
    }

    void SlideLeft()
    {
        SetCurrentlyDodging(true);
        nextDodge = Time.time + slideRate;
        velocity.x = -slideSpeed;
        anim.Play("Dodging");
        Debug.Log("Dodging left!");
        JumpDust();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(shoulderPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }

        void JumpDust()
    {
        JumpNoise();
        Instantiate(jumpDust, jumpDustTransform.position, Quaternion.Euler(0, 0, 0));
    }

    void WallJumpDust()
    {
        Instantiate(wallJumpDust, wallJumpDustTransform.position, Quaternion.Euler(0, 0, 0));
    }

    private void JumpNoise()
    {
        audioSource.volume = .75f;
        audioSource.PlayOneShot(audioClips[2]);
    }

    private void LandNoise()
    {
        //audioSource.clip = audioClips[1];
        if (!audioSource.isPlaying && canPlayLandingSound)
        {
            audioSource.volume = 1;
            audioSource.PlayOneShot(audioClips[3]);
            canPlayLandingSound = false;
        }
        
    }

    public void SpawnEnemyBloodSplatter()
    {
        Instantiate(bloodEffectsSprite, bloodEffectTransformHead.position, Quaternion.Euler(0, 0, Random.Range(0, 45)), bloodEffectTransformHead);
        Instantiate(bloodEffectsSprite2, bloodEffectTransformTorso.position, Quaternion.Euler(0, 0, Random.Range(0, 45)), bloodEffectTransformTorso);
        Instantiate(bloodEffectsSprite3, bloodEffectTransformWeapon.position, bloodEffectTransformWeapon.rotation, bloodEffectTransformWeapon);


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
