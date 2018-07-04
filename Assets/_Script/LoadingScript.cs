using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingScript : MonoBehaviour {

    public Transform loadingBar;
    public Transform textIndicator;
    public float currentAmount;
    public float speed;
    public GameManager gameManager;
    public HealthMeterManager healtManager;

    //No Time Limit Setting
    public static bool noTimeLimitSetting;
    public bool NoTimeLimitSetting
    {
        get { return noTimeLimitSetting; }
        set { noTimeLimitSetting = value; }
    }

    private float timeLeft;
    
    public void SetLoadingScript( float currentAmount, float speed)
    {
        this.currentAmount = currentAmount;
        print("No Time Limit Setting: " + NoTimeLimitSetting + " Speed: " + speed +" Current Amount: "+ currentAmount);
        if (!NoTimeLimitSetting) {
            this.speed = speed;
        }else
        {
            this.speed = 0.0f;
        }
       
    }
         	
	// Update is called once per frame
	void Update () {
		if( currentAmount > 0 && !healtManager.IsHeartMeterDepleted())
        {
            currentAmount -= speed * Time.deltaTime;
            timeLeft = (int)currentAmount / speed;
            textIndicator.GetComponent<Text>().text =(timeLeft).ToString();
        }else
        {
            textIndicator.GetComponent<Text>().text = "DONE!";
            gameManager.ActivateLoseMenu();
        }

        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }

    public float GetTimeLeft()
    {
        return this.timeLeft;
    }
}
