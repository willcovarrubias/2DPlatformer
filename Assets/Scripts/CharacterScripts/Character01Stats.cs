//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;

//public class Character01Stats : MonoBehaviour {

//    //THIS SCRIPT WILL UNLOCK INDIVIDUAL STAT BUTTONS FOR EACH CHARACTER.
//	private List<GameObject> models;
//	private int selectionIndex = 0;

//	void Start ()
//    {
        

//        models = new List<GameObject> ();
//		foreach (Transform t in transform)
//        {
//			models.Add (t.gameObject);
//			t.gameObject.SetActive (false);
//		}

//        InitialStats();      
//        CheckForStatUnlocks();
//        CheckForIconColor();
//        CheckForPerkUnlocks();
//    }
//    //Buttons Already Pressed Array
//    //00=char01_HP01, 01=char01_MP01, 02=char01_Att01, 03=char01_SpAtt01, 04=char01_Def01, 05=char01_Spd01,
//    //06=char01_HP02, 07=char01_MP02, 08=char01_Att02, 09=char01_SpAtt02, 10=char01_Def02, 11=char01_Spd02,
//    //12=char01_HP03, 13=char01_MP03, 14=char01_Att03, 15=char01_SpAtt03, 16=char01_Def03, 17=char01_Spd03,
//    //18=char01_HP04, 19=char01_MP04, 20=char01_Att04, 21=char01_SpAtt04, 22=char01_Def04, 23=char01_Spd04,
//    //24=char01_HP05, 25=char01_MP05, 26=char01_Att05, 27=char01_SpAtt05, 28=char01_Def05, 29=char01_Spd05;

//    public void HPButton01()
//	{
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[0] == false)
//        {
//            models[0].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[0] = true;
//            models[6].SetActive (true);
//            //TODO: Augment base stats in GameMaster
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[0] = true;
//            //TODO: Save();
//            //TODO: Add requirement for being able to click this. Something like: 
//            //if (GameMaster.gameMaster.char01statUnlocks[1] == false)
//            //   Debug.Log("Brilliant code worked!");
//        }
//    }
//    public void HPButton02()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[6] == false)
//        {
//            models[6].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[6] = true;
//            models[12].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[6] = true;
//        }
//    }
//    public void HPButton03()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[12] == false)
//        {
//            models[12].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[12] = true;
//            models[18].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[12] = true;
//        }
//    }
//    public void HPButton04()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[18] == false)
//        {
//            models[18].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[18] = true;
//            models[24].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[18] = true;
//        }
//    }
//    public void HPButton05()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[24] == false)
//        {
//            models[24].GetComponent<Image>().color = new Color(255, 255, 255);
//            //GameMaster.gameMaster.char01HPUnlock02 = true;
//            //models[32].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[24] = true;
//        }
//    }
//    public void MPButton01()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[1] == false)
//        {
//            models[1].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[1] = true;
//            models[7].SetActive(true);
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[1] = true;
//        }
//    }
//    public void MPButton02()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[7] == false)
//        {
//            models[7].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[7] = true;
//            models[13].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[7] = true;
//        }
//    }
//    public void MPButton03()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[13] == false)
//        {
//            models[13].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[13] = true;
//            models[19].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[13] = true;
//        }
//    }
//    public void MPButton04()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[19] == false)
//        {
//            models[19].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[19] = true;
//            models[25].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[19] = true;
//        }
//    }
//    public void MPButton05()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[25] == false)
//        {
//            models[25].GetComponent<Image>().color = new Color(255, 255, 255);
//            //No other button unlocked here.
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[25] = true;
//        }
//    }
//    public void AttButton01()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[2] == false)
//        {
//            models[2].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[2] = true;
//            models[8].SetActive(true);
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[2] = true;
//        }
//    }
//    public void AttButton02()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[8] == false)
//        {
//            models[8].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[8] = true;
//            models[14].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[8] = true;
//        }
//    }
//    public void AttButton03()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[14] == false)
//        {
//            models[14].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[14] = true;
//            models[20].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[14] = true;
//        }
//    }
//    public void AttButton04()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[20] == false)
//        {
//            models[20].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[20] = true;
//            models[26].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[20] = true;
//        }
//    }
//    public void AttButton05()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[26] == false)
//        {
//            models[26].GetComponent<Image>().color = new Color(255, 255, 255);
//            //No other button unlocked here.
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[26] = true;
//        }
//    }
//    public void SpAttButton01()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[3] == false)
//        {
//            models[3].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[3] = true;
//            models[9].SetActive(true);
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[3] = true;
//        }
//    }
//    public void SpAttButton02()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[9] == false)
//        {
//            models[9].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[9] = true;
//            models[15].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[9] = true;
//        }
//    }
//    public void SpAttButton03()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[15] == false)
//        {
//            models[15].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[15] = true;
//            models[21].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[15] = true;
//        }
//    }
//    public void SpAttButton04()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[21] == false)
//        {
//            models[21].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[21] = true;
//            models[27].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[21] = true;
//        }
//    }
//    public void SpAttButton05()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[27] == false)
//        {
//            models[27].GetComponent<Image>().color = new Color(255, 255, 255);
//            //No other button unlocked here.
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[27] = true;
//        }
//    }
//    public void DefButton01()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[4] == false)
//        {
//            models[4].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[4] = true;
//            models[10].SetActive(true);
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[4] = true;
//        }
//    }
//    public void DefButton02()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[10] == false)
//        {
//            models[10].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[10] = true;
//            models[16].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[10] = true;
//        }
//    }
//    public void DefButton03()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[16] == false)
//        {
//            models[16].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[16] = true;
//            models[22].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[16] = true;
//        }
//    }
//    public void DefButton04()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[22] == false)
//        {
//            models[22].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[22] = true;
//            models[28].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[22] = true;
//        }
//    }
//    public void DefButton05()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[28] == false)
//        {
//            models[28].GetComponent<Image>().color = new Color(255, 255, 255);
//            //No other button unlocked here.
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[28] = true;
//        }
//    }
//    public void SpdButton01()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[5] == false)
//        {
//            models[5].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[5] = true;
//            models[11].SetActive(true);
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[5] = true;
//        }
//    }
//    public void SpdButton02()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[11] == false)
//        {
//            models[11].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[11] = true;
//            models[17].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[11] = true;
//        }
//    }
//    public void SpdButton03()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[17] == false)
//        {
//            models[17].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[17] = true;
//            models[23].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[17] = true;
//        }
//    }
//    public void SpdButton04()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[23] == false)
//        {
//            models[23].GetComponent<Image>().color = new Color(255, 255, 255);
//            GameMaster.gameMaster.char01statUnlocks[23] = true;
//            models[29].SetActive(true);
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[23] = true;
//        }
//    }
//    public void SpdButton05()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[29] == false)
//        {
//            models[29].GetComponent<Image>().color = new Color(255, 255, 255);
//            //No other button unlocked here.
//            //TODO: Augment base stats in GameMaster
//            //TODO: Set this so it can't be re-clicked.
//            //TODO: Save();
//            GameMaster.gameMaster.char01_buttonsAlreadyPressed[29] = true;
//        }
//    }

//    void CheckForPerk01Unlock()
//    {
//        //TODO: Here I can use buttonsAlreadyPressed array to determine if pre-reqs for unlocking perks are met.
//        //Also, add these functions to appropriate button presses and to start function.
//    }


//    void InitialStats()
//    {
//        models[0].SetActive(true);
//        models[1].SetActive(true);
//        models[2].SetActive(true);
//        models[3].SetActive(true);
//        models[4].SetActive(true);
//        models[5].SetActive(true);
//    }

//    void CheckForStatUnlocks()
//    {

//        //00=  HP02Unlock, 01= MP02Unlock, 02= Att02Unlock, 03= SpAtt02Unlock, 04= Def02Unlock, 05= Spd02Unlock,
//        //06=  HP03Unlock, 07= MP03Unlock, 08= Att03Unlock, 09= SpAtt03Unlock, 10= Def03Unlock, 11= Spd03Unlock,
//        //12=  HP04Unlock, 13= MP04Unlock, 14= Att04Unlock, 15= SpAtt04Unlock, 16= Def04Unlock, 17= Spd04Unlock,
//        //18=  HP05Unlock, 19= MP05Unlock, 20= Att05Unlock, 21= SpAtt05Unlock, 22= Def05Unlock, 23 =Spd05Unlock;
//        //if (GameMaster.gameMaster.char01statUnlocks[0] == true)
//        //    models[6].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[1] == true)
//        //    models[7].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[2] == true)
//        //    models[8].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[3] == true)
//        //    models[9].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[4] == true)
//        //    models[10].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[5] == true)
//        //    models[11].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[6] == true)
//        //    models[12].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[7] == true)
//        //    models[13].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[8] == true)
//        //    models[14].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[9] == true)
//        //    models[15].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[10] == true)
//        //    models[16].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[11] == true)
//        //    models[17].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[12] == true)
//        //    models[18].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[13] == true)
//        //    models[19].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[14] == true)
//        //    models[20].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[15] == true)
//        //    models[21].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[16] == true)
//        //    models[22].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[17] == true)
//        //    models[23].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[18] == true)
//        //    models[24].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[19] == true)
//        //    models[25].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[20] == true)
//        //    models[26].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[21] == true)
//        //    models[27].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[22] == true)
//        //    models[28].SetActive(true);
//        //if (GameMaster.gameMaster.char01statUnlocks[23] == true)
//        //    models[29].SetActive(true);
//    }

//    void CheckForIconColor()
//    {
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[0] == true)
//            models[0].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[1] == true)
//            models[1].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[2] == true)
//            models[2].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[3] == true)
//            models[3].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[4] == true)
//            models[4].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[5] == true)
//            models[5].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[6] == true)
//            models[6].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[7] == true)
//            models[7].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[8] == true)
//            models[8].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[9] == true)
//            models[9].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[10] == true)
//            models[10].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[11] == true)
//            models[11].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[12] == true)
//            models[12].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[13] == true)
//            models[13].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[14] == true)
//            models[14].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[15] == true)
//            models[15].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[16] == true)
//            models[16].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[17] == true)
//            models[17].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[18] == true)
//            models[18].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[19] == true)
//            models[19].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[20] == true)
//            models[20].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[21] == true)
//            models[21].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[22] == true)
//            models[22].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[23] == true)
//            models[23].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[24] == true)
//            models[24].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[25] == true)
//            models[25].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[26] == true)
//            models[26].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[27] == true)
//            models[27].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[28] == true)
//            models[28].GetComponent<Image>().color = new Color(255, 255, 255);
//        if (GameMaster.gameMaster.char01_buttonsAlreadyPressed[29] == true)
//            models[29].GetComponent<Image>().color = new Color(255, 255, 255);
//    }

//    void CheckForPerkUnlocks()
//    {
//        if (GameMaster.gameMaster.char01statUnlocks[24] == true)
//            models[30].SetActive(true);
//        if (GameMaster.gameMaster.char01statUnlocks[25] == true)
//            models[31].SetActive(true);
//        if (GameMaster.gameMaster.char01statUnlocks[26] == true)
//            models[32].SetActive(true);
//        if (GameMaster.gameMaster.char01statUnlocks[27] == true)
//            models[33].SetActive(true);
//        if (GameMaster.gameMaster.char01statUnlocks[28] == true)
//            models[34].SetActive(true);
//        if (GameMaster.gameMaster.char01statUnlocks[29] == true)
//            models[35].SetActive(true);
//        if (GameMaster.gameMaster.char01statUnlocks[30] == true)
//            models[36].SetActive(true);
//        if (GameMaster.gameMaster.char01statUnlocks[31] == true)
//            models[37].SetActive(true);
//    }
//}
