using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUnlockAnimationController : MonoBehaviour {

    public int armorID;

    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
        ShouldUnlockAnimationsPlay();
	}

    void ShouldUnlockAnimationsPlay()
    {
        int characterOffset = armorID * 35;
        for (int i = armorID; i < (armorID + 5); i++)
        {
            if (GameMaster.gameMaster.hasUIUnlockAnimationPlayed[i] == false && GameMaster.gameMaster.armorUnlocks[i] == true)
            {
                anim.Play((i).ToString());
                GameMaster.gameMaster.hasUIUnlockAnimationPlayed[i] = true;
                //Debug.Log("Playing Animation: " + (i - characterOffset).ToString());
            }
            
        }
    }
}
