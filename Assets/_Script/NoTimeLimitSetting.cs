using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NoTimeLimitSetting : MonoBehaviour {

    public Toggle noTimeLimitToggle;
    public LoadingScript loadingScript;

	// Update is called once per frame
	void Update () {
        //print("No Time Limit Setting:" + noTimeLimitToggle.isOn);
        if (noTimeLimitToggle.isOn)
        {
            loadingScript.NoTimeLimitSetting = true;
        }else
        {
            loadingScript.NoTimeLimitSetting = false;
        }
	}
}
