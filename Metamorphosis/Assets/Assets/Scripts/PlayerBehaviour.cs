using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    float timer;
    public float damageTime = 3.0f;

    SpriteRenderer sr;
 

    public int health = 100;
  
    public RectTransform healthBar;

    private Animator moveAnim;

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
            sr.color = new Color(2, 0, 0);
            //healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
            timer = damageTime;
        }
        //Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + adjustExplosionAngle);
        //Instantiate(explosionPrefab, transform.position, newRot);
        //SendHealthData();

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Game Over");
    }

    void SendHealthData()
    {
        if(OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("isMoving", true);
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false);
            GetComponent<AudioSource>().Pause();
        }
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime);
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}
