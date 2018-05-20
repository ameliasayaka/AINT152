using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public MyScriptableObjectClass scriptableObject;
    public GameObject pauseCanvas;
    public GameObject startCanvas;
    public GameObject gameCanvas;

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
      SceneManager.LoadScene("Level1");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        startCanvas.SetActive(false);
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
        SceneManager.LoadScene(scriptableObject.currentLevelBuildNumber);
    }

    public void SaveLevel()
    {
        scriptableObject.currentLevelBuildNumber = SceneManager.GetActiveScene().buildIndex;
    }

    public void SaveLevel(int i)
    {
        scriptableObject.currentLevelBuildNumber = i;
    }
}
