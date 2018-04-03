using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

    private int health;
    private int score;
    private string gameInfo = "";

    private Rect boxRect = new Rect(10, 10, 300, 50);

    private void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
        AddScore.OnSendScore += HandleonSendScore;
    }

    private void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
        AddScore.OnSendScore -= HandleonSendScore;
    }

    // Use this for initialization
    void Start () {
        UpdateUI();
	}

    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }

    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }
	
	// Update is called once per frame
	void UpdateUI () {
        gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString();
		
	}

    private void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
    }
}
