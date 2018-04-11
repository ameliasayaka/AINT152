using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int health = 300;
    public GameObject powerOrbPrefab;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
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

