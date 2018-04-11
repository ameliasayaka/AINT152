using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDamage : MonoBehaviour {

    public int damage = 5;
    public float damageTime = 3.0f;
    public string targetTag = "Enemy";

    float _timeColliding;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            if (_timeColliding < damageTime)
            {
                _timeColliding += Time.deltaTime;
            }
            else
            {
                collision.gameObject.SendMessage("TakeDamage", damage);
                // Reset timer
                _timeColliding = 0f;
            }
        }
    }
}
