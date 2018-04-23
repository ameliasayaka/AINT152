using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int health = 300;
    private int maxHealth;
    public GameObject powerOrbPrefab;
    public GameObject deathExplosionPrefab;
    public RectTransform healthBar;
    SpriteRenderer sr;

    float _timeColliding;
    public float damageTime = 3.0f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        maxHealth = health;
        _timeColliding = 0;
    }
    public void TakeDamage(int damage)
    {
        if (_timeColliding > 0)
        {
            _timeColliding -= Time.deltaTime;
        }
        else
        {
            health -= damage;
            sr.color = new Color(2, 0, 0);
            healthBar.sizeDelta = new Vector2(health / (maxHealth / 100), healthBar.sizeDelta.y);
            _timeColliding = damageTime;
        }

        if (health <= 0)
        {
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

            Destroy(gameObject);

            Instantiate(deathExplosionPrefab, transform.position, newRot);
            Instantiate(powerOrbPrefab, transform.position, newRot);
        }
    }

    private void FixedUpdate()
    {
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime);
    }
}

