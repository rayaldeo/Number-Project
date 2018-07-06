using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LeaderBoardManager : MonoBehaviour {

    public Text[] highScoreTextArray;
    public int[] scores;
    public GameManager gameManager;

    //private ArrayList sortedScoresArray;
    private ArrayList newSessionArray = new ArrayList();
    private int amountOfHighScoresNeeded = 4;
    
    // Use this for initialization
    void Start () {
        //CreateNewLeaderBoard();
        //newSessionArray = new ArrayList(scores);
        //newSessionArray.Sort();
        //print(newSessionArray[0]);//Testing
        //sortedScoresArray = new ArrayList(scores);
        //sortedScoresArray.Sort();
        //print("LeaderBoardManager: "+ sortedScoresArray[0]);
        //print("LeaderBoardManager: " + sortedScoresArray[1]);
        //print("LeaderBoardManager: " + sortedScoresArray[2]);
        //print("LeaderBoardManager: " + sortedScoresArray[3]);
        //PlayerPrefs.SetInt("Score", scores[3]);
        //print("PlayerPref Saved Score:" + PlayerPrefs.GetInt("Score"));
    }

    public void SaveScore(int score)
    {
        newSessionArray.Add(score);
        if (gameManager.GameCount < 1) {
            print("GameManager GameCount =0");
            newSessionArray.Add(PlayerPrefs.GetInt("HighScore00", 0));
            newSessionArray.Add(PlayerPrefs.GetInt("HighScore01", 0));
            newSessionArray.Add(PlayerPrefs.GetInt("HighScore02", 0));
            newSessionArray.Add(PlayerPrefs.GetInt("HighScore03", 0));
        }
        //print("Count: " + newSessionArray.Count);//Testing
        newSessionArray.Sort();
        //CreateNewLeaderBoard();
    }

    public void CreateNewLeaderBoard()
    {
        if (newSessionArray.Count < 1) {
            SaveScore(0);
        }
        print("New Session Array Size: " + newSessionArray.Count);
        try
        {
            for (int i = newSessionArray.Count; i > newSessionArray.Count - amountOfHighScoresNeeded; i--)
            {
                print("LeaderBoardManager: " /*+ newSessionArray[i]*/ + "Index: " + i);
                highScoreTextArray[newSessionArray.Count - i].text = newSessionArray[i - 1].ToString();
                //print(newSessionArray[i]);
                PlayerPrefs.SetInt("HighScore0" + (newSessionArray.Count - i).ToString(), (int)newSessionArray[i - 1]);
                //print("HighScore0" + (newSessionArray.Count - (i + 1)).ToString());
                //print("High Score 00:"+PlayerPrefs.GetInt("HighScore00", 0));
                //print("High Score 01:" + PlayerPrefs.GetInt("HighScore01", 0));
                //print("High Score 02:" + PlayerPrefs.GetInt("HighScore02", 0));
                //print("High Score 03:" + PlayerPrefs.GetInt("HighScore03", 0));
            }
        }
        catch (System.ArgumentOutOfRangeException)
        {
            print("LeaderBoard Array not finished yet");
        } 
    }

    //Testing
    public void ScoreReset()
    {
        PlayerPrefs.DeleteAll();
        newSessionArray.Clear();
        print("Score Reset Button Pressed");
    }
	
}
