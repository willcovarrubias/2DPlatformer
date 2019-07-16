using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public bool chargingUpMelee = false;
    public bool chargingUpRanged = false;

	public bool playerMeleeing = false;

    public Player player;

    public GameObject playerGameObject;

    public Transform ChargeUpProjectile;
    public Transform ChargeUpEnergyWave;
    public Transform Projectile;
    public Transform visualTransformToDetermineDirection;
    public Transform firePointForProjectiles;
    public Transform firePointForChargeUpAttacks;
    
    public Collider2D meleeTriggerHitBoxHorizontal;
    public Collider2D meleeTriggerHitBoxVertical;

    private Animator _animator;
    
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


    //Attributes for switching between Animator Controllers during runtime.
    public bool currentlySwitchingAnimator;
    public bool currentlyInMeleeMode = true;
    public bool currentlyInRangeMode = false;

    public float animatorSwitchCoolDown = .5f;
    public float animatorSwitchTimer = 0;



    void Awake ()
    {
		meleeTriggerHitBoxHorizontal.enabled = false;
        meleeTriggerHitBoxVertical.enabled = false;

    }

	void Start()
    {
		_animator = playerGameObject.GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    
    void Update()
    {
        if (GameMaster.gameMaster.isPaused == false && !GameMaster.gameMaster.inACutscene && !currentlySwitchingAnimator && !player.playerisDead)
        {

            //Regular attacks.
            if (Input.GetButtonDown("Attack1") && player.slidingAgainstAWall == false && currentlyInMeleeMode)
            {
                Attack();                
            }


            //Melee charged attacks.
            if (Input.GetButton("Attack1") && currentlyInMeleeMode)
            {
                chargingUpMelee = true;
                chargeTime += Time.deltaTime;

                if (chargeTime > .5f)
                {
                    _animator.SetBool("Charging", true);
                }

                if (chargeTime > 2)
                {
                    _animator.SetBool("ChargingDone", true);
                    _animator.SetBool("Charging", false);
                
                }
                else
                {
                    _animator.SetBool("ChargingDone", false);
                }
            }
            else if(Input.GetButtonUp("Attack1") && currentlyInMeleeMode)
            {
                chargingUpMelee = false;
            }
            

            if (Input.GetButtonUp("Attack1") && chargeTime > 2 && currentlyInMeleeMode)
            {
                if (player.slidingAgainstAWall)
                {
                    chargingUpMelee = false;
                    chargeTime = 0;
                    _animator.SetBool("Charging", false);
                    _animator.SetBool("ChargingDone", false);
      
                }
                else
                {
                    if (Input.GetAxis("Vertical") > 0.9f && Input.GetAxis("Horizontal") == 0)
                    {
                        chargingUpMelee = false;
                        chargeTime = 0;
                        _animator.SetBool("Charging", false);
                        _animator.SetBool("ChargingDone", false);
                        ChargeAttackUpward();
                    }
                    else
                    {
                        chargingUpMelee = false;
                        chargeTime = 0;
                        _animator.SetBool("Charging", false);
                        _animator.SetBool("ChargingDone", false);
                        ChargeAttack();
                    }
                    
                }
            }
            if (Input.GetButtonUp("Attack1") && chargeTime < 2 && currentlyInMeleeMode)
            {
                chargeTime = 0;
                chargingUpMelee = false;
                _animator.SetBool("Charging", false);
                _animator.SetBool("ChargingDone", false);

            }



            if (playerMeleeing)
            {
                if (meleeTimer > 0)
                {
                    meleeTimer -= Time.deltaTime;                    
                }
                else
                {
                    _animator.SetBool("Meleeing", false);
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
                    _animator.SetBool("RangeCharging", true);
                }


                if (chargeTime > 2)
                {
                    _animator.SetBool("RangeChargingDone", true);
                    _animator.SetBool("RangeCharging", false);



                }
                else
                {
                    _animator.SetBool("RangeChargingDone", false);
                }
            }
            if (Input.GetButtonUp("Attack1") && chargeTime > 2 && currentlyInRangeMode)
            {
                if (player.currentlyDucking)
                {
                    //TO DO: Lose charge effect.
                    ShootSpecialWhileDucking();
                    chargeTime = 0;
                    _animator.SetBool("RangeCharging", false);
                    _animator.SetBool("RangeChargingDone", false);
  
                }
                else
                {
                    if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0 && !player.currentlyDodging)
                    {
                        ShootSpecialUp();
                        chargeTime = 0;
                        _animator.SetBool("RangeCharging", false);
                        _animator.SetBool("RangeChargingDone", false);
                    }
                    else
                    {
                        ShootSpecial();
                        chargeTime = 0;
                        _animator.SetBool("RangeCharging", false);
                        _animator.SetBool("RangeChargingDone", false);
                    }
                        

                }
            }
            if (Input.GetButtonUp("Attack1") && chargeTime < 2 && currentlyInRangeMode)
            {
                chargeTime = 0;
                _animator.SetBool("RangeCharging", false);
                _animator.SetBool("RangeChargingDone", false);

            }





            

            if (Input.GetButtonDown("Attack2") && !currentlySwitchingAnimator && currentlyInRangeMode && chargeTime <= 0 && !player.currentlyDucking 
                && !player.slidingAgainstAWall)
            {
                animatorSwitchTimer = animatorSwitchCoolDown;
                currentlySwitchingAnimator = true;
                _animator.Play("SwitchingFromRangedToMelee");
                Invoke("LoadMeleeAnimator", .5f);





            }

            if (Input.GetButtonDown("Attack2") && !currentlySwitchingAnimator && currentlyInMeleeMode && chargeTime <= 0 && !player.currentlyDucking
                && !player.slidingAgainstAWall)
            {
                animatorSwitchTimer = animatorSwitchCoolDown;
                currentlySwitchingAnimator = true;
                _animator.Play("SwitchingFromMeleeToRanged");
                Invoke("LoadRangedAnimator", .5f);
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
        
        if (Input.GetAxis("Vertical") > 0.9f && Input.GetAxis("Horizontal") == 0)
        {
            AttackUp();
        }
        else if (!player.currentlyDucking)
        {
            int attackToUse = Random.Range(0, 3);
            meleeTriggerHitBoxHorizontal.enabled = true;

            if (attackToUse == 0)
            {
                _animator.Play("Melee");
                Debug.Log("Attacking! 1");
            }
            if (attackToUse == 1)
            {
                _animator.Play("Melee2");
                Debug.Log("Attacking! 2");
            }
            if (attackToUse == 2)
            {
                _animator.Play("Melee3");
                Debug.Log("Attacking! 3");
            }
        }else
        {
            _animator.Play("CrouchMelee");
            meleeTriggerHitBoxHorizontal.enabled = true;
        }        
    }

    void AttackUp()
    {
        meleeTriggerHitBoxVertical.enabled = true;
        _animator.Play("MeleeUp");
        Debug.Log("Attacking Up!");            
    }

    void ChargeAttack()
    {
        //TODO fix logic here so that meleeTrigger is enabled on release, not on hold.

        meleeTriggerHitBoxHorizontal.enabled = true;
        playerMeleeing = true;
        meleeTimer = meleeCD;
        ChargeUpSpecialEffect();
                    
        _animator.Play("MeleeCharge");         
    }

    void ChargeAttackUpward()
    {
        //TODO fix logic here so that meleeTrigger is enabled on release, not on hold.

        meleeTriggerHitBoxHorizontal.enabled = true;
        playerMeleeing = true;
        meleeTimer = meleeCD;
        ShootSpecialEffectUp();

        _animator.Play("MeleeUp");
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
        _animator.Play("ShortyRanged2");
        if (Time.time >= timeToSpawnEffect)
        {

            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootUp()
    {
        _animator.Play("BowUpwardAttack");
        if (Time.time >= timeToSpawnEffect)
        {

            UpwardEffect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootSpecial()
    {
        _animator.Play("ShortyRanged2");
        if (Time.time >= timeToSpawnEffect)
        {

            ShootSpecialEffect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootSpecialWhileDucking()
    {
        _animator.Play("CrouchShooting");
        if (Time.time >= timeToSpawnEffect)
        {

            ShootSpecialEffect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;

        }
    }

    void ShootSpecialUp()
    {
        _animator.Play("BowUpwardAttack");
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
        _animator.Play("WallShooting");
        if (Time.time >= timeToSpawnEffect)
        {
            EffectFlipped();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    void ShootWhileDucking()
    {
        _animator.Play("CrouchShooting");
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
    }

    void LoadMeleeAnimator()
    {
        
        
        _animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/PlayerMainStance", typeof(RuntimeAnimatorController)));
        currentlyInMeleeMode = true;
        currentlyInRangeMode = false;
    }

    void LoadRangedAnimator()
    {
       
        _animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Animation/PlayerRangedStance", typeof(RuntimeAnimatorController)));
        currentlyInRangeMode = true;
        currentlyInMeleeMode = false;
    }
}

	

