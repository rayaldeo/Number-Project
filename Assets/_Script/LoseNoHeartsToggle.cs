using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoseNoHeartsToggle : MonoBehaviour {

    public Toggle loseNoHeartsToggle;
    public GameManager gameManager;

	// Update is called once per frame
	void Update () {
        //If Activate, User loses no hearts from Incorrect Answers,Else Game works as Default
        if (loseNoHeartsToggle.isOn)
        {
            gameManager.LoseNoHeartSetting = true;
        }else
        {
            gameManager.LoseNoHeartSetting = false;
        }
	}
}
