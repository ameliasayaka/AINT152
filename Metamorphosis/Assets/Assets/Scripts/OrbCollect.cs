using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbCollect : MonoBehaviour {

    public GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //sets saved level to next level
            gameManager.GetComponent<GameManager>().SaveLevel((SceneManager.GetActiveScene().buildIndex + 1));
            SceneManager.LoadScene("Victory");
        }
    }
}
