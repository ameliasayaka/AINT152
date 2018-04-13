using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    SpriteRenderer sr;
 

    public int health = 100;
  
    public RectTransform healthBar;

    private Animator moveAnim;

	// Use this for initialization
	void Start () {
        moveAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
           
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            //GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("isMoving", true);
        }

        if (Input.anyKey == false)
        {
            GetComponent<Animator>().SetBool("isMoving", false);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + adjustExplosionAngle);
        //Instantiate(explosionPrefab, transform.position, newRot);

        sr.color = new Color(2, 0, 0);
        healthBar.sizeDelta = new Vector2(health,healthBar.sizeDelta.y);
        SendHealthData();

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
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime);
    }
}
