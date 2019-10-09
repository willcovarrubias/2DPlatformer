using UnityEngine;

[System.Serializable]
public class PlayerAttack : MonoBehaviour {

    public static PlayerAttack playerAttackInstance;

    public bool chargingUpMelee = false;
    public bool chargingUpRanged = false;

	public bool playerMeleeing = false;

    public GameObject playerGameObject;

    public Transform ChargeUpProjectile;
    public Transform ChargeUpEnergyWave;
    public Transform Projectile;
    public Transform visualTransformToDetermineDirection;
    public Transform firePointForProjectiles;
    public Transform firePointForChargeUpAttacks;
    
    public Collider2D meleeTriggerHitBoxHorizontal;
    public Collider2D meleeTriggerHitBoxVertical;

    private Animator anim;
    private Player player;
    
    //Regular melee timers and cooldown.
    private float meleeTimer = 0;
	private float meleeCD = .1f;
     
	//Charge Attack Attributes
    private float chargeTime = 0;

    //Ranged attack attributes.
    private float timeToSpawnEffect = 0;
    private float effectSpawnRate = 10;
    private float nextFire = 0.5f;
    private float fireRate = .5f;
    private float attackToUse = 0;

    //Attributes for switching between Animator Controllers during runtime.
    public bool currentlySwitchingAnimator = false;
    public bool currentlyInRangeMode = false;


    public float animatorSwitchCoolDown = 1f;
    public float animatorSwitchTimer = 0;



    void Awake ()
    {
		meleeTriggerHitBoxHorizontal.enabled = false;
        meleeTriggerHitBoxVertical.enabled = false;

    }

	void Start()
    {
		anim = playerGameObject.GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    
    void Update()
    {
        if (GameMaster.gameMaster.isPaused == false && !GameMaster.gameMaster.inACutscene && !currentlySwitchingAnimator && !player.playerisDead && !player.takingDamage)
        {

            //Regular attacks.
            if (Input.GetButtonDown("Attack1") && player.slidingAgainstAWall == false && !currentlyInRangeMode)
            {
                Attack();                
            }


            //Melee charged attacks.
            if (Input.GetButton("Attack1") && !currentlyInRangeMode)
            {
                chargingUpMelee = true;
                chargeTime += Time.deltaTime;

                if (chargeTime > .5f)
                {
                    anim.SetBool("Charging", true);
                }
                if (chargeTime > 2)
                {
                    anim.SetBool("ChargingDone", true);
                    anim.SetBool("Charging", false);                
                }
                else
                {
                    anim.SetBool("ChargingDone", false);
                }
            }
            else if(Input.GetButtonUp("Attack1") && !currentlyInRangeMode)
            {
                chargingUpMelee = false;
            }
            

            if (Input.GetButtonUp("Attack1") && chargeTime > 2 && !currentlyInRangeMode)
            {
                if (player.slidingAgainstAWall)
                {
                    chargingUpMelee = false;
                    chargeTime = 0;
                    anim.SetBool("Charging", false);
                    anim.SetBool("ChargingDone", false);      
                }
                else
                {
                    if (Input.GetAxis("Vertical") > 0.9f && Input.GetAxis("Horizontal") == 0)
                    {
                        chargingUpMelee = false;
                        chargeTime = 0;
                        anim.SetBool("Charging", false);
                        anim.SetBool("ChargingDone", false);
                        ChargeAttackUpward();
                    }
                    else
                    {
                        chargingUpMelee = false;
                        chargeTime = 0;
                        anim.SetBool("Charging", false);
                        anim.SetBool("ChargingDone", false);
                        ChargeAttack();
                    }
                    
                }
            }
            if (Input.GetButtonUp("Attack1") && chargeTime < 2 && !currentlyInRangeMode)
            {
                chargeTime = 0;
                chargingUpMelee = false;
                anim.SetBool("Charging", false);
                anim.SetBool("ChargingDone", false);
            }

            if (playerMeleeing)
            {
                if (meleeTimer > 0)
                {
                    meleeTimer -= Time.deltaTime;                    
                }
                else
                {
                    anim.SetBool("Meleeing", false);
                    playerMeleeing = false;
                    meleeTriggerHitBoxHorizontal.enabled = false;
                    meleeTriggerHitBoxVertical.enabled = false;
                }
            }

            //RANGED ATTACKS.
            if (Input.GetButtonDown("Attack1") && Time.time > nextFire && currentlyInRangeMode)
            {
                nextFire = Time.time + fireRate;
                if (player.slidingAgainstAWall == false && player.currentlyDucking == false)
                {
                    if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0 && !player.currentlyDodging)
                    {

                        ShootUp();
                    }
                    else
                    {
                        Shoot();
                    }
                    
                }
                if (player.slidingAgainstAWall == true)
                {

                    ShootWhileOnWalls();
                }
                if (player.currentlyDucking == true)
                {
                    ShootWhileDucking();
                }
            }

            //Ranged Charged attacks.
            if (Input.GetButton("Attack1") && currentlyInRangeMode)
            {
                chargeTime += Time.deltaTime;
                //_animator.SetBool("RangeCharging", true);

                if (chargeTime > .5f)
                {
                    anim.SetBool("RangeCharging", true);
                }
                if (chargeTime > 2)
                {
                    anim.SetBool("RangeChargingDone", true);
                    anim.SetBool("RangeCharging", false);
                }
                else
                {
                    anim.SetBool("RangeChargingDone", false);
                }
            }
            if (Input.GetButtonUp("Attack1") && chargeTime > 2 && currentlyInRangeMode)
            {
                if (player.currentlyDucking)
                {
                    //TO DO: Lose charge effect.
                    ShootSpecialWhileDucking();
                    chargeTime = 0;
                    anim.SetBool("RangeCharging", false);
                    anim.SetBool("RangeChargingDone", false);  
                }
                else
                {
                    if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0 && !player.currentlyDodging)
                    {
                        ShootSpecialUp();
                        chargeTime = 0;
                        anim.SetBool("RangeCharging", false);
                        anim.SetBool("RangeChargingDone", false);
                    }
                    else
                    {
                        ShootSpecial();
                        chargeTime = 0;
                        anim.SetBool("RangeCharging", false);
                        anim.SetBool("RangeChargingDone", false);
                    }
                        

                }
            }
            if (Input.GetButtonUp("Attack1") && chargeTime < 2 && currentlyInRangeMode)
            {
                chargeTime = 0;
                anim.SetBool("RangeCharging", false);
                anim.SetBool("RangeChargingDone", false);

            }
            

            if (Input.GetButtonDown("Attack2") && player.onTheGround && !currentlySwitchingAnimator &&  chargeTime <= 0 && !player.currentlyDucking && !player.slidingAgainstAWall && !player.currentlyDodging)
            {
                animatorSwitchTimer = animatorSwitchCoolDown;
                currentlySwitchingAnimator = true;

                if (currentlyInRangeMode)
                {
                    anim.Play("SwitchingFromRangedToMelee");
                    LoadMeleeAnimator();
                }
                else
                {
                    anim.Play("SwitchingFromMeleeToRanged");
                    LoadRangedAnimator();
                }
            }      
                
                        
        }

        //Testing for switching between animators.
        if (currentlySwitchingAnimator)
        {
            if (animatorSwitchTimer > 0)
            {
                animatorSwitchTimer -= Time.deltaTime;
            }
            else
            {
                currentlySwitchingAnimator = false;
            }
        }
    }        
    

    void Attack()
    {   
        playerMeleeing = true;
        meleeTimer = meleeCD;
        
        //If player is holding up, attack up.
        if (Input.GetAxis("Vertical") > 0.9f && Input.GetAxis("Horizontal") == 0)
        {
            AttackUp();
        }
        else if (!player.currentlyDucking) //Normal melee attacks.
        {
            meleeTriggerHitBoxHorizontal.enabled = true;

            switch (attackToUse)
            {
                case 0:
                    anim.Play("Melee3");
                    attackToUse = 1;
                    break;
                case 1:
                    anim.Play("Melee2");
                    attackToUse = 2;
                    break;
                case 2:
                    anim.Play("Melee");
                    attackToUse = 0;
                    break;
                default:
                    anim.Play("Melee");
                    break;
            }
        }
        else
        {
            anim.Play("CrouchMelee");

        }
    }

    void AttackUp()
    {
        meleeTriggerHitBoxVertical.enabled = true;
        anim.Play("MeleeUp");
        Debug.Log("Attacking Up!");            
    }

    void ChargeAttack()
    {
        //TODO fix logic here so that meleeTrigger is enabled on release, not on hold.

        meleeTriggerHitBoxHorizontal.enabled = true;
        playerMeleeing = true;
        meleeTimer = meleeCD;
        ChargeUpSpecialEffect();
                    
        anim.Play("MeleeCharge");         
    }

    void ChargeAttackUpward()
    {
        //TODO fix logic here so that meleeTrigger is enabled on release, not on hold.

        meleeTriggerHitBoxHorizontal.enabled = true;
        playerMeleeing = true;
        meleeTimer = meleeCD;
        ShootSpecialEffectUp();

        anim.Play("MeleeUp");
    }

    void ChargeUpSpecialEffect()
    {
        if (visualTransformToDetermineDirection.localScale.x < 1)
        {
            Instantiate(ChargeUpProjectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z + 180));
            Instantiate(ChargeUpEnergyWave, firePointForChargeUpAttacks.position, Quaternion.Euler(0, 0, firePointForChargeUpAttacks.rotation.z + 180));
        }
        else
        {
            Instantiate(ChargeUpProjectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z));
            Instantiate(ChargeUpEnergyWave, firePointForChargeUpAttacks.position, Quaternion.Euler(0, 0, firePointForChargeUpAttacks.rotation.z));
        }
    }

    void Shoot()
    {
        anim.Play("Ranged");
        if (Time.time >= timeToSpawnEffect)
        {

            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootUp()
    {
        anim.Play("RangedUp");
        if (Time.time >= timeToSpawnEffect)
        {

            UpwardEffect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootSpecial()
    {
        anim.Play("ShortyRanged2");
        if (Time.time >= timeToSpawnEffect)
        {

            ShootSpecialEffect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootSpecialWhileDucking()
    {
        anim.Play("CrouchShooting");
        if (Time.time >= timeToSpawnEffect)
        {

            ShootSpecialEffect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootSpecialUp()
    {
        anim.Play("BowUpwardAttack");
        if (Time.time >= timeToSpawnEffect)
        {

            ShootSpecialEffectUp();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootSpecialEffect()
    {

        if (visualTransformToDetermineDirection.localScale.x < 1)
        {
            Instantiate(ChargeUpProjectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z + 180));
        }
        else
        {
            Instantiate(ChargeUpProjectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z));
        }


    }

    void ShootSpecialEffectUp()
    {

          Instantiate(ChargeUpProjectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z + 90));


    }

    void Effect()
    {

        if (visualTransformToDetermineDirection.localScale.x < 1)
        {
            Instantiate(Projectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z + 180));
        }
        else
        {
            Instantiate(Projectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z));
        }


    }

    void UpwardEffect()
    {

            Instantiate(Projectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z + 90));
       

    }

    void EffectFlipped()
    {
        if (visualTransformToDetermineDirection.localScale.x < 1)
        {
           Instantiate(Projectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z));
        }
        else
        {
            Instantiate(Projectile, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z + 180));
        }
    }

    void ShootWhileOnWalls()
    {
        anim.Play("WallShooting");
        if (Time.time >= timeToSpawnEffect)
        {
            EffectFlipped();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    void ShootWhileDucking()
    {
        anim.Play("CrouchShooting");
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    void LoadMeleeAnimator()
    {


        //_animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/PlayerMainStance", typeof(RuntimeAnimatorController)));
        anim.SetBool("InRangeMode", false);
        currentlyInRangeMode = false;
    }

    void LoadRangedAnimator()
    {

        //_animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/PlayerRangedStance", typeof(RuntimeAnimatorController)));
        anim.SetBool("InRangeMode", true);

        currentlyInRangeMode = true;
    }
}

	

