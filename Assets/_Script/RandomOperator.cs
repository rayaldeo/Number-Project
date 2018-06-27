using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomOperator : MonoBehaviour {

    string[] operators = { "+", "-", "*", "\u00F7" };
    public enum Operators {
        ADDITION,
        SUBTRACTION,
        DIVISION,
        MULTIPLICATION};
 
    //public float timeUntilNextNumber;
    public Text textBox;
    //private IEnumerator coroutine;
    public Operators action;

    // Use this for initialization
    void Start () {
        //PickNewOperator();
    }

    public Operators PickNewOperator()
    {
            string operatorSelected = operators[Random.Range(0, operators.Length)].ToString();
            textBox.text = operatorSelected;
            return ShowState(operatorSelected);
    }

    public Operators ShowState(string operatorAction)
    {
        switch (operatorAction)
        {
            case "+":
                action = Operators.ADDITION;
                break;
            case "-":
                action = Operators.SUBTRACTION;
                break;
            case "\u00F7":
                action = Operators.DIVISION;
                break;
            default:
                action = Operators.MULTIPLICATION;
                break;
        }
        return action;
    }

    public Operators getOperator()
    {
        return action;
    }
}
