using UnityEngine;
using System.Collections;

public class ProjectileAttacking : MonoBehaviour {



	public Transform ProjectileToFire, visualTransformToDetermineDirection;
	//public Transform MuzzlePrefab;
	float timeToSpawnEffect = 0;
	public float effectSpawnrate = 10;

	private float nextFire = 0.5f;
    private float fireRate = .5f;
	public Transform firePointForProjectiles;

    public GameObject playerGameObject;
    private Animator _animator;
    Player player;



    //Charge Ranged Attack Attributes
    private float chargeTime = 0;

    // Use this for initialization
    void Awake () {
        //firePoint = transform.FindChild ("FirePoint");
        player = this.GetComponent<Player>();
        

		if (firePointForProjectiles == null) 
		{
			Debug.LogError ("No FirePoint found!");
		}
	
	}

	void Start(){
      
        _animator = playerGameObject.GetComponent<Animator>();
     

    }

  

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (GameMaster.gameMaster.isPaused == false && !GameMaster.gameMaster.inACutscene)
        {
            if (Input.GetButtonDown("Attack2") && Time.time > nextFire && !Input.GetButton("Attack1"))
            {
                nextFire = Time.time + fireRate;
                if (player.slidingAgainstAWall == false && player.currentlyDucking == false)
                {
                   Shoot();
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
            else
            {
                //_animator.SetBool("Shooting", false);
            }

            
        }

        //Charged attacks.
        if (Input.GetButton("Attack2") && !Input.GetButton("Attack1"))
        {
            chargeTime += Time.deltaTime;
            //_animator.SetBool("Charging", true);
            //_animator.Play("ChargingUp");
            _animator.SetBool("RangeCharging", true);
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
        if (Input.GetButtonUp("Attack2") && chargeTime > 2)
        {
            if (player.currentlyDucking)
            {
                //TO DO: Lose charge effect.
                ShootWhileDucking();
                chargeTime = 0;
                _animator.SetBool("RangeCharging", false);
                _animator.SetBool("RangeChargingDone", false);
            }
            else
            {
                Shoot();
                chargeTime = 0;
                _animator.SetBool("RangeCharging", false);
                _animator.SetBool("RangeChargingDone", false);
            }
        }
        if (Input.GetButtonUp("Attack2") && chargeTime < 2)
        {
            chargeTime = 0;
            _animator.SetBool("RangeCharging", false);
            _animator.SetBool("RangeChargingDone", false);
        }
    }
    


	void Shoot()
    {
        //Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
        //		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
        //		if (hit.collider != null) 
        //		{
        //		//Debug.DrawLine (firePointPosition, hit.point, Color.red);
        //			Enemy enemy = hit.collider.GetComponent<Enemy>();
        //			if(enemy != null)
        //		{
        //				enemy.DamageEnemy (Damage);
        //				Debug.Log ("Hitting enemy!");
        //		}
        //_animator.SetBool("Shooting", true);
        _animator.Play("ShortyRanged2");
        if (Time.time >= timeToSpawnEffect) 
		{
            
            Effect();
			timeToSpawnEffect = Time.time + 1/effectSpawnrate;

        }
	}

		//Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*10);



	void Effect()
	{

		if (visualTransformToDetermineDirection.localScale.x < 1 ) {
		//	Debug.Log ("Facing right and shooting");
		//Instantiate (ProjectileToFire, firePoint.position, Quaternion.Euler(0, 0, AnimationTesting.rotZ));
			//Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
			Instantiate (ProjectileToFire, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z + 180));
		} else{
		//else if (PlayerController.facingRight == false)
		//{
		//Debug.Log ("Facing LEFT and shooting");
		//	Instantiate (BulletTrailPrefab, firePoint.position, Quaternion.Euler(0, 0, -PlayerController.rotZ + 180));
			Instantiate (ProjectileToFire, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z));}


		}

    void EffectFlipped()
    {

        if (visualTransformToDetermineDirection.localScale.x < 1)
        {
            //	Debug.Log ("Facing right and shooting");
            //Instantiate (ProjectileToFire, firePoint.position, Quaternion.Euler(0, 0, AnimationTesting.rotZ));
            //Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
            Instantiate(ProjectileToFire, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z));
        }
        else
        {
            //else if (PlayerController.facingRight == false)
            //{
            //Debug.Log ("Facing LEFT and shooting");
            //	Instantiate (BulletTrailPrefab, firePoint.position, Quaternion.Euler(0, 0, -PlayerController.rotZ + 180));
            Instantiate(ProjectileToFire, firePointForProjectiles.position, Quaternion.Euler(0, 0, firePointForProjectiles.rotation.z + 180));
        }


    }

    void ShootWhileOnWalls()
    {
        //Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
        //		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
        //		if (hit.collider != null) 
        //		{
        //		//Debug.DrawLine (firePointPosition, hit.point, Color.red);
        //			Enemy enemy = hit.collider.GetComponent<Enemy>();
        //			if(enemy != null)
        //		{
        //				enemy.DamageEnemy (Damage);
        //				Debug.Log ("Hitting enemy!");
        //		}
        //_animator.SetBool("Shooting", true);
        _animator.Play("WallShooting");
        if (Time.time >= timeToSpawnEffect)
        {

            EffectFlipped();
            timeToSpawnEffect = Time.time + 1 / effectSpawnrate;

        }
    }

    void ShootWhileJumping()
    {
        //Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
        //		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
        //		if (hit.collider != null) 
        //		{
        //		//Debug.DrawLine (firePointPosition, hit.point, Color.red);
        //			Enemy enemy = hit.collider.GetComponent<Enemy>();
        //			if(enemy != null)
        //		{
        //				enemy.DamageEnemy (Damage);
        //				Debug.Log ("Hitting enemy!");
        //		}
        //_animator.SetBool("Shooting", true);
        _animator.Play("JumpShooting");
        if (Time.time >= timeToSpawnEffect)
        {

            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnrate;

        }
    }

    void ShootWhileSliding()
    {
        //Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
        //		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
        //		if (hit.collider != null) 
        //		{
        //		//Debug.DrawLine (firePointPosition, hit.point, Color.red);
        //			Enemy enemy = hit.collider.GetComponent<Enemy>();
        //			if(enemy != null)
        //		{
        //				enemy.DamageEnemy (Damage);
        //				Debug.Log ("Hitting enemy!");
        //		}
        //_animator.SetBool("Shooting", true);
        _animator.Play("SlideShooting");
        if (Time.time >= timeToSpawnEffect)
        {

            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnrate;

        }
    }

    void ShootWhileDucking()
    {
        //Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
        //		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
        //		if (hit.collider != null) 
        //		{
        //		//Debug.DrawLine (firePointPosition, hit.point, Color.red);
        //			Enemy enemy = hit.collider.GetComponent<Enemy>();
        //			if(enemy != null)
        //		{
        //				enemy.DamageEnemy (Damage);
        //				Debug.Log ("Hitting enemy!");
        //		}
        //_animator.SetBool("Shooting", true);
        _animator.Play("CrouchShooting");
        if (Time.time >= timeToSpawnEffect)
        {

            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnrate;

        }
    }


    //}
}

