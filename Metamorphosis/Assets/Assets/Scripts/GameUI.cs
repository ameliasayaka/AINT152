using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

    private int health;
    private string gameInfo = "";

    private Rect boxRect = new Rect(10, 10, 300, 50);

    private void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
       
    }

    private void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
      
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

 
	
	// Update is called once per frame
	void UpdateUI () {
        gameInfo = "\nHealth: " + health.ToString();
		
	}

    private void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
    }
}
