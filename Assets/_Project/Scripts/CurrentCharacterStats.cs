﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentCharacterStats : MonoBehaviour {

    /// <summary>
    /// This script will set a character's stats at the point of being spawned.
    /// It will take whatever the current values are in the GameMaster script and set those as the character's stats.
    /// Base stats are predetermined in the GameMaster script, as well as any updated stats (via player progress/unlocks).
    /// The stats are also then modded by armor values in the Armor Selection scenes, using the CharacterStatsMain script.
    /// </summary>



    Controller2D controller;
    Player player;
    Rigidbody2D rigidBody;
    Animator anim;

    CharacterManager characterManager;
    ArmorManager armorManager;

    //public int numberOfBodyParts = 15;
    public GameObject[] visualWhereRendererIs;
    public Color collideColor, normalColor;
    SpriteRenderer[] renderer = new SpriteRenderer[15];
    private string sceneName;


    public Text statsText;


    //Base character attritbutes.
    public int maxHP, currentHP, maxMP, currentMP, attack, magicAttack, defense, speed;

    //Modded character stats from armor.
    private int hpFromArmor;

    private int activeWeapon, activeRanged, activeHelm, activeBody, activeHands, activeLegs, activeAcc;

    private float iFrameTimer = 2f;
    public float iFrameDuration;

    private void Awake()
    {
        

        
    }

    void Start () {

        statsText = GameObject.FindGameObjectWithTag("DevUI").GetComponent<Text>();
        controller = GetComponent<Controller2D>();
        player = GetComponent<Player>();
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        characterManager = GameObject.FindGameObjectWithTag("GM").GetComponent<CharacterManager>();
        armorManager = GameObject.FindGameObjectWithTag("GM").GetComponent<ArmorManager>();

        if (armorManager == null)
            Debug.Log("Looks like it didn't properly reference the Armor Manager script.");


        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;

        //renderer = visualWhereRendererIs.GetComponent<SpriteRenderer>();
        //visualWhereRendererIs = new GameObject[5];
        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i] = visualWhereRendererIs[i].GetComponent<SpriteRenderer>();
            //Debug.Log("Current renderer: " + renderer[i]);
        }

        GetStatsFromArmor();
        InitialStatSetter();

    }

    private int GetActiveWeapon()
    {
        int activeWeapon = PlayerPrefs.GetInt("ActiveWeapon");
        return activeWeapon;
        //activeRanged = PlayerPrefs.GetInt("ActiveRanged");
        //activeHelm = PlayerPrefs.GetInt("ActiveHelm");
        //activeBody = PlayerPrefs.GetInt("ActiveBody");
        //activeHands = PlayerPrefs.GetInt("ActiveHands");
        //activeLegs = PlayerPrefs.GetInt("ActiveLegs");
        //activeAcc = PlayerPrefs.GetInt("ActiveAcc");
    }

    void Update () {

        ShowUpdateStats();

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            currentHP--;
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            currentHP++;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            DamagePlayer(1);
        }
     

        if (currentHP <= 0)
        {
            //KillPlayer();
        }

        if (iFrameTimer >= 0)
        {
            //player.takingDamage = false;
            iFrameTimer -= Time.deltaTime;
            
        }

        if (iFrameTimer <= .5f)
        {
            player.takingDamage = false;
        }
	}

    void ShowUpdateStats()
    {
        statsText.text = "Starting Stats: " +
        "\nLife: " + maxHP + "\nCurrent Life: " + currentHP +
        "\nMana: " + maxMP + "\nCurrent Mana: " + currentMP +
        "\nAttack: " + attack +
        "\nMagicAttack: " + magicAttack +
        "\nDefense: " + defense +
        "\nSpeed: " + speed;
    }

    void InitialStatSetter()
    {
        //

        maxHP = characterManager.GetCharacterStats(PlayerPrefs.GetInt("CharacterSelected")).HP + hpFromArmor;        
        maxMP = characterManager.GetCharacterStats(PlayerPrefs.GetInt("CharacterSelected")).MP;
        attack = characterManager.GetCharacterStats(PlayerPrefs.GetInt("CharacterSelected")).Attack;
        magicAttack = characterManager.GetCharacterStats(PlayerPrefs.GetInt("CharacterSelected")).MagicAttack;
        defense = characterManager.GetCharacterStats(PlayerPrefs.GetInt("CharacterSelected")).Defense;
        speed = characterManager.GetCharacterStats(PlayerPrefs.GetInt("CharacterSelected")).Speed;

        if (sceneName == "Level1")
        {
            currentHP = maxHP;
            PlayerPrefs.SetInt("CurrentHP", currentHP);

            currentMP = maxMP;
            PlayerPrefs.SetInt("CurrentMP", currentMP);
        }
        else
        {
            currentHP = PlayerPrefs.GetInt("CurrentHP");
            currentMP = PlayerPrefs.GetInt("CurrentMP");
        }
        

    }

    void GetStatsFromArmor()
    {
        hpFromArmor = armorManager.GetArmorHP(activeWeapon); // + armorManager.GetActiveArmor(activeRanged).Life + armorManager.GetActiveArmor(activeHelm).Life +
            //armorManager.GetActiveArmor(activeBody).Life + armorManager.GetActiveArmor(activeHands).Life + armorManager.GetActiveArmor(activeLegs).Life + armorManager.GetActiveArmor(activeAcc).Life;
    }

    void DamagePlayer(int damage)
    {
        anim.SetTrigger("TakingDamage");
        //KnockBack();
        player.takingDamage = true;
        //Debug.Log("Current life: " + currentLife);
        currentHP -= damage;
        StartCoroutine(collideFlash());
    }

    void KillPlayer()
    {
        //DYING LOGIC
       
            for (int i = 0; i < 2; i++)
            {
                anim.Play("Death" + i);
                Debug.Log("Playing the " + i + "'th animation!");
                player.playerisDead = true;
            }
        
        //  Debug.Log("Player is dead!");
    }

    void KnockToTheLeft()
    {
        if (player.slidingAgainstAWall)
        {
            player.velocity.y = 0;

            if (controller.collisions.left)
                controller.Move(new Vector3(2, 0, 0), true);
            else if (controller.collisions.right)
                controller.Move(new Vector3(-2, 0, 0), true);
            else
                controller.Move(new Vector3(2, 0, 0), true);
        }
        else
        {
            player.velocity.y = 8;
            controller.Move(new Vector3(1, 0, 0), true);
        }
               
            
    }

    void KnockToTheRight()
    {
        if (player.slidingAgainstAWall)
        {
            player.velocity.y = 0;

            if(controller.collisions.left)
                controller.Move(new Vector3(2, 0, 0), true);
            else if(controller.collisions.right)
                controller.Move(new Vector3(-2, 0, 0), true);
            else
                controller.Move(new Vector3(-2, 0, 0), true);
        }
        else
        {
            player.velocity.y = 8;
            controller.Move(new Vector3(-1, 0, 0), true);
        }
        
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "EnemyProjectile" || collision.gameObject.tag == "Enemy") && !player.playerisDead )
        {
            if (iFrameTimer <= 0)
            {
                iFrameTimer = iFrameDuration;
                DamagePlayer(50);

                var relativePosition = collision.GetContact(0);
                Vector2 positionOfHit = relativePosition.point;

                Debug.Log(relativePosition.point);

                if (positionOfHit.x < transform.position.x)
                {
                    KnockToTheLeft();
                }
                else if (positionOfHit.x > transform.position.x)
                {
                    KnockToTheRight();
                }
            }          
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes"  && !player.playerisDead)
        {
            
            if (iFrameTimer <= 0)
            {
                if (collision.transform.position.x < player.transform.position.x) //Being shot from the  left.
                {
                    KnockToTheLeft();
                    Debug.Log("Knock to the left from spikes!");
                }
                else if (collision.transform.position.x > player.transform.position.x) //Being shot from the right.
                {
                    KnockToTheRight();
                    Debug.Log("Knock to the right from spikes!");

                }
                Debug.Log("I'm taking damange from spikes!");
                DamagePlayer(1);
                iFrameTimer = iFrameDuration;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !player.playerisDead)
        {
            if (iFrameTimer <= 0)
            {
                iFrameTimer = iFrameDuration;
                DamagePlayer(50);

                var relativePosition = collision.GetContact(0);
                Vector2 positionOfHit = relativePosition.point;

                Debug.Log(relativePosition.point);

                if (positionOfHit.x < transform.position.x)
                {
                    KnockToTheLeft();
                }
                else if (positionOfHit.x > transform.position.x)
                {
                    KnockToTheRight();
                }
            }
        }

    }

    IEnumerator collideFlash()
    {
        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i].material.color = collideColor;
        }
        yield return new WaitForSeconds(.12f);

        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i].material.color = normalColor;
        }       
        yield return new WaitForSeconds(.12f);

        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i].material.color = collideColor;
        }
        yield return new WaitForSeconds(.12f);

        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i].material.color = normalColor;
        }

        yield return new WaitForSeconds(.12f);

        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i].material.color = collideColor;
        }
        yield return new WaitForSeconds(.12f);

        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i].material.color = normalColor;
        }
        yield return new WaitForSeconds(.12f);

        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i].material.color = normalColor;
        }


    }

}