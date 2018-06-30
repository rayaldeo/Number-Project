using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Public Variables
    public Text topNumber, bottomNumber, points;
    public List<GameObject> optionList;
    public GameObject pauseMenu,loseMenu,highScoreMenu,settingsMenu;
    public RandomEquationGenerator randomEquation;
    public StreakMeter streakMeter;
    public LeaderBoardManager leaderBoard;
    public HealthMeterManager healthMeter;
    public Text finalScoreText;
    //Game Count
    public static int gameCount;
    public int GameCount{
        get { return gameCount; } 
        private set { gameCount = value; }
    }

    //Private
    private RandomOperator rO;
    private int solution;
    private int randomOptionNumber;
    private int pointsValue;
    private LoadingScript loadCircle;
    private int timerFillAmount =100;
    private float[] speedArray = { 5, 10, 20, 25, 50 };
    private float speed;
    private int index = 0;
    private int questionCounter = 0;
    private int correctAnswerValue = 5;
    private float streakMeterIncrementValue =0.1f;

	// Use this for initialization
	void Start () {
        ActivatePauseMenu();
        rO = FindObjectOfType<RandomOperator>();
        loadCircle = FindObjectOfType<LoadingScript>();
        //randomNumberGen = FindObjectsOfType<RandomNumberGenerator>();
        speed = speedArray[index];
        StartNewRound();
        points.text = pointsValue.ToString();
        streakMeter.SetStreakText("X1");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void PlaceCorrectValueInRandomBox()
    {
        //Calculates Soltuion
        if (rO.getOperator() == RandomOperator.Operators.ADDITION)
            {
                solution = int.Parse(topNumber.text) + int.Parse(bottomNumber.text);
            }
         else if (rO.getOperator() == RandomOperator.Operators.SUBTRACTION)
            {
                solution = int.Parse(topNumber.text) - int.Parse(bottomNumber.text);
            }
         else if (rO.getOperator() == RandomOperator.Operators.DIVISION)
            {
                solution = int.Parse(topNumber.text) / int.Parse(bottomNumber.text);
            }
        else
            {
                solution = int.Parse(topNumber.text) * int.Parse(bottomNumber.text);
            }
        //Pick a Random Number for Each Option
        for (int i = 0; i < optionList.Count; i++)
        {
            optionList[i].GetComponent<RandomNumberGenerator>().PickNewNumber(solution);
        }
        randomOptionNumber = Random.Range(0, 3);
        //print("Option list Size: "+ optionList.Count);
        optionList[randomOptionNumber].GetComponent<Text>().text=solution.ToString();
    }

    public void StartNewRound()
    {
        questionCounter++;
        SetUpNewEquation(rO.PickNewOperator());
        //randomNumberGen.SetTimeUntilNextNumber(speed);
        loadCircle.SetLoadingScript(timerFillAmount, speedArray[index]);
        PlaceCorrectValueInRandomBox();
    }

    public void SelectThisAnswer()
    {
        if (loadCircle.GetTimeLeft() != 0)
        {
            int value = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponent<Text>().text);
            //print("Selected Value: "+ value);
            //print("Solution: " + solution);
            if (value == solution)//Correct Answer
            {
                print(EventSystem.current.currentSelectedGameObject.name + " You have selected the Right answer");
                UpdateScore(correctAnswerValue * streakMeter.GetStreakValue(), false);//Update Score and add in Multiplier
                streakMeter.SetMeterAmount(streakMeterIncrementValue);
                IncreaseDificulty();
                StartNewRound();
            }else
            {
                print("You have selected the Wrong answer");
                EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("FlashAnimation");
                healthMeter.LoseHeart();
                streakMeter.Reset();
                StartNewRound();
            }
        }
    }

    public void DeactivateMenus()
    {
        gameCount += 1;
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        highScoreMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;//UnPause Game
    }

    public void ActivatePauseMenu()
    {
        print("Pause Menu Activated");
        Time.timeScale = 0;//Pause Game
        pauseMenu.SetActive(true);
        loseMenu.SetActive(false);
        highScoreMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void ActivateLoseMenu()
    {
        Time.timeScale = 0;//Pause Game
        pauseMenu.SetActive(false);
        loseMenu.SetActive(true);
        highScoreMenu.SetActive(false);
        settingsMenu.SetActive(false);
        finalScoreText.text = pointsValue.ToString();
    }

    public void ActivateHighScorePanel()
    {
        Time.timeScale = 0;//Pause Game
        highScoreMenu.SetActive(true);
        leaderBoard.CreateNewLeaderBoard();
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void ActivateSettingsMenu()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        highScoreMenu.SetActive(false);
        Time.timeScale = 0;//Pause Game
    }

    public void Reset()
    {
        Time.timeScale = 0;//Pause Game
        //Reset Speed
        index = 0;
        this.speed = speedArray[index];

        //Save and Get ready for new Score
        leaderBoard.SaveScore(pointsValue);//save score
        UpdateScore(0, true);

        //Reset Timer
        loadCircle.SetLoadingScript(timerFillAmount, speedArray[index]);
        ActivatePauseMenu();

        //Reset Heart Meter
        healthMeter.Reset();
    }

    public void SetUpNewEquation(RandomOperator.Operators operatorAction)
    {
        switch (operatorAction)
        {
            case RandomOperator.Operators.ADDITION:
                randomEquation.CreateRandomAddition();
                break;
            case RandomOperator.Operators.SUBTRACTION:
                randomEquation.CreateRandomSubtraction();
                break;
            case RandomOperator.Operators.DIVISION:
                randomEquation.CreateRandomDivision();
                break;
            default:
                randomEquation.CreateRandomMultiplication();
                break;
        }
    }

    private void IncreaseDificulty()
    {
        if(index < 4 && questionCounter % 10 ==0)
        {
            this.speed = speedArray[index++];
        }
    }

    private void UpdateScore(int value, bool reset)
    {

        if (reset)
        {
            pointsValue = value;
        }else
        {
            pointsValue += value;
        }
        points.text = pointsValue.ToString();
    }

}
