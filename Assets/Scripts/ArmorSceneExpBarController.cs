using UnityEngine;
using System.Collections;

public class ArmorSceneExpBarController : MonoBehaviour {

    //THIS SCRIPT IS TO TEST EXP BARS IN THE ARMOR SELECT SCREEN.
    ArmorManager armorManager;
    public GameObject expBar;
    //public int allArmorIndex;

    void Start () {
        armorManager = GetComponent<ArmorManager>();
        SetEXPBar(0);

    }
	
	// Update is called once per frame
	void Update () {

        

        /*
        float calc_MP = GameMaster.gameMaster.char01Wep02xp / 10;
        SetBar2(calc_MP);

        float calc_Attack = GameMaster.gameMaster.char01Wep03xp / 20;
        SetBar3(calc_Attack);*/

     
    }

    

    public void SetExpBarOnHover(int allArmorIndex)
    {
        float calc_EXP = (float)GameMaster.gameMaster.allArmorExp[allArmorIndex] / (float)armorManager.SetActiveArmor(allArmorIndex).ExpToCap;
        Debug.Log("Current EXP: " + GameMaster.gameMaster.allArmorExp[allArmorIndex] + ". And EXP to CAP: " + armorManager.SetActiveArmor(allArmorIndex).ExpToCap);
        SetEXPBar(calc_EXP);

    }

    public void SetEXPBar(float bar)
    {
        expBar.transform.localScale = new Vector3(bar, expBar.transform.localScale.y, expBar.transform.localScale.z);
        expBar.transform.localScale = new Vector3(Mathf.Clamp(bar, 0f, 1f), expBar.transform.localScale.y, expBar.transform.localScale.z);
    }
    
}
