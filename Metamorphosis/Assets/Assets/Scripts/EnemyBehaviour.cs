using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour {

    public int health = 300;
    private int maxHealth;
    public GameObject powerOrbPrefab;
    public GameObject deathExplosionPrefab;
    public Slider healthBar;
    public GameObject soundObject;
    public float damageTime = 3.0f;

    SpriteRenderer sr;
    float timeColliding;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        maxHealth = health;
        timeColliding = 0;

      
    }

    public void TakeDamage(int damage)
    {
       if(timeColliding == 0)
        {
            health -= damage;
            //sets colour to red
            sr.color = new Color(2, 0, 0);
            timeColliding = damageTime;

            if (soundObject != null)
            {
                soundObject.GetComponent<AudioSource>().Play();
            }
        }

        if (health <= 0)
        {
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

            Destroy(gameObject);

            //spawn explosion and power orb
            Instantiate(deathExplosionPrefab, transform.position, newRot);
            Instantiate(powerOrbPrefab, transform.position, newRot);
        }
    }

    private void FixedUpdate()
    {
        //sets colour back to  original
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime);

        if (timeColliding > 0)
        {
            timeColliding -= Time.deltaTime;
        }
        else if(timeColliding < 0)
        {
            timeColliding = 0;
        }

        //update health bar
        healthBar.value = health / (maxHealth / 100);
    }
}

