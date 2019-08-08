using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarManager : MonoBehaviour {

    public GameObject healthBar;
    public GameObject manaBar;
	// Use this for initialization
	void Start () {
        //UpdateLifeBar();
        //healthBar = GameObject.FindGameObjectWithTag("PlayerHealth").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //float calc_HP = (float)GameMaster.gameMaster.curHP / (float)GameMaster.gameMaster.maxHP;
        //UpdateLifeBar(calc_HP);

        //float calc_MP = (float)GameMaster.gameMaster.curMP / (float)GameMaster.gameMaster.maxMP;
        //UpdateManaBar(calc_MP);
    }

    void UpdateLifeBar(float myHP)
    {
        healthBar.transform.localScale = new Vector3(myHP, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHP, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        //Debug.Log("Current HP: " + GameMaster.gameMaster.curHP + "/" + GameMaster.gameMaster.maxHP);
    }

    void UpdateManaBar(float myMana)
    {
        manaBar.transform.localScale = new Vector3(myMana, manaBar.transform.localScale.y, manaBar.transform.localScale.z);
        manaBar.transform.localScale = new Vector3(Mathf.Clamp(myMana, 0f, 1f), manaBar.transform.localScale.y, manaBar.transform.localScale.z);
    }
}
