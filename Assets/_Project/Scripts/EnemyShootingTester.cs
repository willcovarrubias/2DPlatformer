using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingTester : MonoBehaviour {

    public GameObject EnemyBullet;
    //public GameObject MuzzlePrefab;
    public float minTime;
    public float maxTime;
    private float fireRate;
    private float nextFire;
    public Transform enemyFirePoint;

    void Start()
    {
        Invoke("FireEnemyBullet", 2f);
        //enemyFirePoint = transform.Find("EnemyFirePoint");
        if (enemyFirePoint == null)
        {
            Debug.LogError("No FirePoint found!");
        }
        fireRate = Random.Range(minTime, maxTime);
        nextFire = Time.time + fireRate;

    }

    void Update()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            FireEnemyBullet();
        }
    }

    void FireEnemyBullet()
    {
        //GameObject playerTarget = GameObject.FindGameObjectWithTag("Player");

       // if (playerTarget != null)
       // {
            //	if (EnemySentry.facingRight == true) {
            //	Debug.Log ("Facing right and shooting");
            Instantiate(EnemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
            //Instantiate(MuzzlePrefab, enemyFirePoint.position, enemyFirePoint.rotation);
            //	} 
            //	else if (EnemySentry.facingRight == false)
            //	{
            //Debug.Log ("Facing LEFT and shooting");
            //		Instantiate (EnemyBullet, enemyFirePoint.position, Quaternion.Euler(0, 0, -EnemySentry.rotZ + 180));
            //		Instantiate (MuzzlePrefab, enemyFirePoint.position, Quaternion.Euler(0, 0, -EnemySentry.rotZ + 180));
            //	}
       // }
    }
}
