using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StreakMeter : MonoBehaviour {

    public Image fillImage;
    public int streak = 1;
    public Text text;

    private float fillAmount =0f;
    //Testing
    private float waitTime = 1f;
    private IEnumerator coroutine;

    // Use this for initialization
    void Start () {
        //coroutine = FillMeter(1f);
        //StartCoroutine(coroutine);
    }

    public void SetMeterAmount(float currentAmount)
    {
        if(fillImage.fillAmount != 1) {
            fillImage.fillAmount += currentAmount;
        }else
        {
            streak++;
            fillImage.fillAmount = currentAmount;
            SetStreakText("X" + streak.ToString());
        }
    }

    public void Reset()
    {
        this.streak = 1;
        SetStreakText("X" + streak.ToString());
        fillImage.fillAmount = 0.0f;
    }

    public void SetStreakText(string value)
    {
        text.text = value;
    }
    
    public int GetStreakValue()
    {
        return this.streak;
    }

    //Testing Purposes
    //private IEnumerator FillMeter(float waitTime)
    //{
    //    while (true) {
    //        SetMeterAmount(0.1f);
    //        yield return new WaitForSeconds(waitTime);
    //     }
    //}
}
