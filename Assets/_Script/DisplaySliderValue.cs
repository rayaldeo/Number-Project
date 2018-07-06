using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplaySliderValue : MonoBehaviour {

    public Text minValueText,maxValueText;
    public Slider minValueSlider, maxValueSlider;
    public RandomEquationGenerator randomEquation;

	// Use this for initialization
	void Start () {
        //print("Min: "+ randomEquation.SubAddMin);
        //print("Max: "+ randomEquation.SubAddMax);
        //Setting Default Values in Settings Dialogue
        minValueSlider.value = randomEquation.SubAddMin;
        maxValueSlider.value = randomEquation.SubAddMax;

    }
	
	// Update is called once per frame
	void Update () {
        minValueText.text = minValueSlider.value.ToString();
        maxValueText.text = maxValueSlider.value.ToString();
        randomEquation.SubAddMax = (int)maxValueSlider.value;
        randomEquation.SubAddMin = (int)minValueSlider.value;

        if(maxValueSlider.value< minValueSlider.value)
        {
            minValueSlider.value = maxValueSlider.value - 5;
        }
    }
}

