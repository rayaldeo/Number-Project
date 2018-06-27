using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMeterManager : MonoBehaviour {

    public GameObject[] heartsArray;
    private int index;

	// Use this for initialization
	void Start () {
        index = heartsArray.Length;
    }
	
    public void LoseHeart()
    {
        heartsArray[index-1].SetActive(false);
        if (index > 0) { index--; }
    }

    public void Reset()
    {
        foreach(GameObject heart in heartsArray)
        {
            heart.SetActive(true);
        }
        index = heartsArray.Length;
    }

    public bool IsHeartMeterDepleted()
    {
        if (index <= 0)
        {
            print("Heart Index:" + index);
            return true;
        }else
        {
            return false;
        }
    }
}
