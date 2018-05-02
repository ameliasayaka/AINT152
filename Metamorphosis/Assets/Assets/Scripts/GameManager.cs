using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public MyScriptableObjectClass scriptableObject;
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
        SceneManager.LoadScene(scriptableObject.currentLevelBuildNumber);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(scriptableObject.currentLevelBuildNumber + 1);
    }

    public void SaveLevel()
    {
        scriptableObject.currentLevelBuildNumber = SceneManager.GetActiveScene().buildIndex;
    }
}
