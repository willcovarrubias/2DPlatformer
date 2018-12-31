using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    //public int numberOfBodyParts = 15;
    public GameObject[] visualWhereRendererIs;
    public Color collideColor, normalColor;
    SpriteRenderer[] renderer = new SpriteRenderer[15];


    public Text statsText;

    //characterAttributes
    public int maxLife, currentLife, maxMana, currentMana, attack, magicAttack, defense, speed;

    public float iFrameTimer = 2f;

    void Start () {
        statsText = GameObject.FindGameObjectWithTag("DevUI").GetComponent<Text>();
        controller = GetComponent<Controller2D>();
        player = GetComponent<Player>();
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //renderer = visualWhereRendererIs.GetComponent<SpriteRenderer>();
        //visualWhereRendererIs = new GameObject[5];
        for (int i = 0; i < visualWhereRendererIs.Length; i++)
        {
            renderer[i] = visualWhereRendererIs[i].GetComponent<SpriteRenderer>();
            //Debug.Log("Current renderer: " + renderer[i]);
        }

        ShowUpdateStats();
        StatSetter();

    }
	
	// Update is called once per frame
	void Update () {

        StatSetter();
        ShowUpdateStats();

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            GameMaster.gameMaster.curHP--;
            StatSetter();
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            GameMaster.gameMaster.curHP++;
            StatSetter();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            player.takingDamage = true;
        }
     

        if (GameMaster.gameMaster.curHP <= 0)
        {
            //KillPlayer();
        }

        if (iFrameTimer >= 0)
        {
            //player.takingDamage = false;
            iFrameTimer -= Time.deltaTime;
            
        }

        if (iFrameTimer <= 1.5f)
        {
            player.takingDamage = false;
        }
	}

    void ShowUpdateStats()
    {
        statsText.text = "STATS: " +
        "\nLife: " + GameMaster.gameMaster.maxHP +
        "\nMana: " + GameMaster.gameMaster.maxMP +
        "\nAttack: " + GameMaster.gameMaster.curSpAttack +
        "\nMagicAttack: " + GameMaster.gameMaster.curSpAttack +
        "\nDefense: " + GameMaster.gameMaster.curDefense +
        "\nSpeed: " + GameMaster.gameMaster.curSpeed +
        "\nCurrent Character: " + GameMaster.gameMaster.characterChosen;
    }

    void StatSetter()
    {
        maxLife = GameMaster.gameMaster.maxHP;
        currentLife = GameMaster.gameMaster.curHP;
        maxMana = GameMaster.gameMaster.maxMP;
        currentMana = GameMaster.gameMaster.curMP;
        attack = GameMaster.gameMaster.curAttack;
        magicAttack = GameMaster.gameMaster.curSpAttack;
        defense = GameMaster.gameMaster.curDefense;
        speed = GameMaster.gameMaster.curSpeed;
    }

    void DamagePlayer(int damage)
    {
        anim.Play("TakingDamage");
        //KnockBack();
        player.takingDamage = true;
        //Debug.Log("Current life: " + currentLife);
        GameMaster.gameMaster.curHP -= damage;      
        
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

    void KnockBack(bool knockBackLeft)
    {
        //player.velocity.x = -50;
        player.velocity.y = 50;
        if (knockBackLeft)
        {
            controller.Move(new Vector3(3, 0, 0), true);
        }
        else
        {
            controller.Move(new Vector3(-3, 0, 0), true);
        }
        

            
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Enemy") && !player.playerisDead)
        {

            if (iFrameTimer <= 0)
            {
                if (collision.transform.position.x < player.transform.position.x) //Being shot from the  left.
                {
                    DamagePlayer(1);
                    KnockBack(true);
                    iFrameTimer = 1;
                    StartCoroutine(collideFlash());

                }
                if (collision.transform.position.x > player.transform.position.x) //Being shot from the right.
                {
                    DamagePlayer(1);
                    KnockBack(false);
                    iFrameTimer = 1;
                    StartCoroutine(collideFlash());
                }
            }       
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile" && !player.playerisDead )
        {
            if (iFrameTimer <= 0)
            {
                if (collision.transform.position.x < player.transform.position.x) //Being shot from the  left.
                {
                    DamagePlayer(50);
                    KnockBack(true);
                    iFrameTimer = 1;
                    StartCoroutine(collideFlash());
                }

                if (collision.transform.position.x > player.transform.position.x) //Being shot from the right.
                {
                    DamagePlayer(50);
                    KnockBack(false);
                    iFrameTimer = 1;
                    StartCoroutine(collideFlash());
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


    }

}
