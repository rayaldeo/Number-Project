using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneNavigator : MonoBehaviour {

	public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        print("Button was pressed");
    }
}
