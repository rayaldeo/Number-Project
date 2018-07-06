using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine;

public class AdManager : MonoBehaviour {

    public void RunAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
	
}
