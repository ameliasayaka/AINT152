using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingProjectileHit : MonoBehaviour {


    public int damage = 1;
    public string damageTag = "";
    public float slowAmount = 5;
    public GameObject slowVictim;

    private float maxSpeed;
    private void Start()
    {
        maxSpeed = slowVictim.GetComponent<TopDownCharacterController2D>().speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == damageTag)
        {
            SendMessage("BecomeOnTrigger");
        }
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(damageTag))
        {

            other.SendMessage("TakeDamage", damage);
            other.GetComponent<TopDownCharacterController2D>().speed /= slowAmount;
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(damageTag))
        {
            other.GetComponent<TopDownCharacterController2D>().speed = maxSpeed; 
        }
    }
}
