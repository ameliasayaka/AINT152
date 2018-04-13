﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int health = 300;
    private int maxHealth;
    public GameObject powerOrbPrefab;
    public RectTransform healthBar;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        maxHealth = health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        sr.color = new Color(2, 0, 0);
        healthBar.sizeDelta = new Vector2(health/(maxHealth/100), healthBar.sizeDelta.y);
        sr.color = new Color(2, 0, 0);

        if (health <= 0)
        {
            Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

            Destroy(gameObject);

            Instantiate(powerOrbPrefab, transform.position, newRot);
        }
    }

    private void FixedUpdate()
    {
        sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime);
    }
}

