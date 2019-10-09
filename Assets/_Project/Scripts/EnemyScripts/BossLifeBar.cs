using UnityEngine;
using System.Collections;

public class BossLifeBar : MonoBehaviour {

	public static BossLifeBar bossLifeBar;

	//public GameObject bossLifeCanvas;
	GameObject bossHPBar;


	// Use this for initialization
	void Start () {

		bossHPBar = GameObject.FindGameObjectWithTag("BossHealth");
		//bossHPBar.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {




		//float calc_BossHealth = cur_Health / max_Health;
		//SetBossHealthBar (calc_BossHealth);
	
	}


}
