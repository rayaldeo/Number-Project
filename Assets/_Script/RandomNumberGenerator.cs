using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour {

    //public float timeUntilNextNumber;
    public Text textBox;
    //private IEnumerator coroutine;
    public int min, max;
    public GameManager gameManager;

	// Use this for initialization
	void Start () {

    }

    public void PickNewNumber(int solution)
    {
        int value = Random.Range(min, max);
        if(value == solution)//To avoid Duplicate Correct Answers
        {
            value = Random.Range(min, solution);
        }
        textBox.text = (value).ToString();
    }

    public void StartNewQuestion()
    {
        gameManager.StartNewRound();
    }

}
