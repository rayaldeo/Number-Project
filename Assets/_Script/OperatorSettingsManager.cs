using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OperatorSettingsManager : MonoBehaviour {

    public Toggle additionToggle, substractionToggle, multiplicationToggle, divisionToggle;
    public RandomOperator randomOperator;

	// Update is called once per frame
	void Update () {
        //Addition
        if (additionToggle.isOn)
        {
            randomOperator.AddOperator("+");
        }
        else if (!additionToggle.isOn)
        {
            randomOperator.RemoveOperator("+");
        }

        //Substraction
        if (substractionToggle.isOn)
        {
            randomOperator.AddOperator("-");
        }
        else if (!substractionToggle.isOn)
        {
            randomOperator.RemoveOperator("-");
        }

        //Multiplication
        if (multiplicationToggle.isOn)
        {
            randomOperator.AddOperator("*");
        }
        else if (!multiplicationToggle.isOn)
        {
            randomOperator.RemoveOperator("*");
        }

        //Division
        if (divisionToggle.isOn)
        {
            randomOperator.AddOperator("\u00F7");
        }
        else if (!divisionToggle.isOn)
        {
            randomOperator.RemoveOperator("\u00F7");
        }

        //The User is unable to disable all operatos.
        //Trying to disable all operators will enable all of them
        if(!additionToggle.isOn && !substractionToggle.isOn && !multiplicationToggle.isOn  && !divisionToggle.isOn)
        {
            additionToggle.isOn = true; substractionToggle.isOn=true; multiplicationToggle.isOn=true; divisionToggle.isOn=true;
        }
    }
}
