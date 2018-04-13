using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public static int currentLevelBuildNumber;
    
	// Use this for initialization
	void Awake () {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
       else if (control != this)
        {
            Destroy(gameObject);
        }

    
	}
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            currentLevelBuildNumber = SceneManager.GetActiveScene().buildIndex;
        }
    }

}
