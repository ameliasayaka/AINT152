using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void StartGame()
    {
      SceneManager.LoadScene("Level1");
    }
	
    public void EndGame()
    {
      SceneManager.LoadScene("Game Over");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(GameControl.currentLevelBuildNumber);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(GameControl.currentLevelBuildNumber+1);
    }
}
