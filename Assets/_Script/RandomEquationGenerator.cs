using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomEquationGenerator : MonoBehaviour {

    public Text topNumber, bottomNumber;
    public RandomOperator operatorValue;
    public static int subAddMin, subAddMax;
    public int SubAddMin
    {
        get { return subAddMin; }
        set { subAddMin = value; }
    }

    public int SubAddMax
    {
        get { return subAddMax; }
        set { subAddMax = value; }
    }

    private int[,] multiplicationMatrix =new int[,] { {0,1,2,3,4,5,6,7,8,9,10,11,12},
                                                      {0,2,4,6,8,10,12,14,16,18,20,22,24},
                                                      {0,3,6,9,12,15,18,21,24,27,30,33,36},
                                                      {0,4,8,12,16,20,24,28,32,36,40,44,48},
                                                      {0,5,10,15,20,25,30,35,40,45,50,55,60},
                                                      {0,6,12,18,24,30,36,42,48,54,60,66,72},
                                                      {0,7,14,21,28,35,42,49,56,63,70,77,84},
                                                      {0,8,16,24,32,40,48,56,64,72,80,88,96},
                                                      {0,9,18,27,36,45,54,63,72,81,90,99,108},
                                                      {0,10,20,30,40,50,60,70,80,90,100,110,120},
                                                      {0,11,22,33,44,55,66,77,88,99,110,121,132},
                                                      {0,12,24,36,48,60,72,84,96,108,120,132,144}    };
    public void Awake()
    {
        //Set Min and Max Values to Default Values
        this.SubAddMax = subAddMax = 250;
        this.SubAddMin = subAddMin = 0;
    }

    public void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    CreateRandomDivision();
        //}
    }

    public void CreateRandomMultiplication()
    {
        topNumber.text = multiplicationMatrix[0, Random.Range(0, 13)].ToString();
        bottomNumber.text = multiplicationMatrix[0, Random.Range(0, 13)].ToString();
    }

    public void CreateRandomAddition()
    {
        topNumber.text = Random.Range(subAddMin, subAddMax+1).ToString();
        bottomNumber.text = Random.Range(subAddMin, subAddMax+1).ToString();
    }

    public void CreateRandomSubtraction()
    {
        topNumber.text = Random.Range(subAddMin, subAddMax+1).ToString();
        bottomNumber.text = Random.Range(subAddMin, subAddMax+1).ToString();
    }

    public void CreateRandomDivision()
    {
        int columnNumber = Random.Range(1, 12);
        int topNumberValue = multiplicationMatrix[Random.Range(1, 12), columnNumber];
        int bottomNumberValue = multiplicationMatrix[0, columnNumber];
        topNumber.text = topNumberValue.ToString();
        bottomNumber.text = bottomNumberValue.ToString();
        //print("Top Number: " + topNumberValue);
        //print("Bottom Number: " + bottomNumberValue);
    }
}
