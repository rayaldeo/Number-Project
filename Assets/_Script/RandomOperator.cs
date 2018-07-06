using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomOperator : MonoBehaviour {

    List<string> operators;
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
        operators = new List<string>();
        operators.Add("+");
        operators.Add("-");
        operators.Add("*");
        operators.Add("\u00F7");
        operators.Sort();
    }

    public Operators PickNewOperator()
    {
            string operatorSelected = operators[Random.Range(0, operators.Count)].ToString();
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

    public void RemoveOperator(string operatorValue)
    {
        operators.Remove(operatorValue);
        //for(int i = 0; i < operators.Count; i++)
        //{
        //    if (operatorValue == operators[i])
        //    {
        //        operators.RemoveAt(i);
        //    }
        //}
        SortAndDisplayOperatorsList();
    }

    public void AddOperator(string operatorValue)
    {
        if(!operators.Contains(operatorValue))
            operators.Add(operatorValue);
        SortAndDisplayOperatorsList();
    }

    private void SortAndDisplayOperatorsList()
    {
        operators.Sort();
        foreach (string thisoperator in operators)
        {
            print("RandomOperator : Sort Operator List: " + thisoperator);
        }
        print("Operators List Size:" + operators.Count);
    }
}
