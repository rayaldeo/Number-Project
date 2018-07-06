using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameBreaksManager : MonoBehaviour {

    public Toggle loseNoHeartsToggle;
    public GameManager gameManager;

    public Toggle noTimeLimitToggle;
    public LoadingScript loadingScript;


    // Update is called once per frame
    void Update () {
        //If Activate, User loses no hearts from Incorrect Answers,Else Game works as Default
        if (loseNoHeartsToggle.isOn)
        {
            gameManager.LoseNoHeartSetting = true;
        }
        else if (!loseNoHeartsToggle.isOn)
        {
            gameManager.LoseNoHeartSetting = false;
        }

        //print("No Time Limit Setting:" + noTimeLimitToggle.isOn);
        if (noTimeLimitToggle.isOn)
        {
            loadingScript.NoTimeLimitSetting = true;
        }
        else
        {
            loadingScript.NoTimeLimitSetting = false;
        }

        if (noTimeLimitToggle.isOn && loseNoHeartsToggle.isOn)//Both Game Breaks Can not be On at the Same time
        {
            noTimeLimitToggle.isOn = false;
            loseNoHeartsToggle.isOn = false;
        }
    }
}
