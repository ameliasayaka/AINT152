using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    float timer;
    public float damageTime = 3.0f;  
    public Slider playerHealthSlider;
    public int health = 100; 

    private Animator moveAnim;
    SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        moveAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        timer = 0;
        GameObject.Find("Game System").GetComponent<GameManager>().SaveLevel();
    }

    public void TakeDamage(int damage)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            health -= damage;
            //sets gameObject colour to red
            sr.color = new Color(2, 0, 0);
            timer = damageTime;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Game Over");
    }



    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("isMoving", true);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false);
            GetComponent<AudioSource>().Pause();
        }

        //gradually returns gameObject to original colour
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime);
        playerHealthSlider.value = health;
    }
}
