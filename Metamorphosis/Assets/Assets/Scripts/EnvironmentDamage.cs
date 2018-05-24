using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDamage : MonoBehaviour {

    public int damage = 5;
    public float damageTime = 3.0f;
    public string targetTag = "Enemy";

    float timeColliding;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            if (timeColliding < damageTime)
            {
                timeColliding += Time.deltaTime;
            }
            else
            {
                collision.gameObject.SendMessage("TakeDamage", damage);
                // Reset timer
                timeColliding = 0f;
            }
        }
    }
}
