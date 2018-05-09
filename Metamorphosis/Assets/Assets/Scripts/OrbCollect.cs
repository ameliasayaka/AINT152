using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbCollect : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<GameManager>().SaveLevel(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("Victory");
        }
    }
}
