using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public float damageTime = 3.0f;
    public int damage;
    public string targetTag = "Player";
    float _timeColliding;

  

  
    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        _timeColliding = 0;
    //        other.gameObject.SendMessage("TakeDamage", damage);

    //    }

    //}

    private void OnCollisionStay2D(Collision2D collision)
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


    // Update is called once per frame
 
}
