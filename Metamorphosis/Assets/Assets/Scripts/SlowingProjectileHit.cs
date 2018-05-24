using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingProjectileHit : MonoBehaviour {


    public int damage = 1;
    public string damageTag = "";
    public float slowAmount = 5;
    public GameObject slowVictim;
    public float damageTime = 3.0f;

    float timer;
    private float maxSpeed;

    private void Start()
    {
        maxSpeed = slowVictim.GetComponent<TopDownCharacterController2D>().speed;
        timer = 0;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == damageTag)
        {
            SendMessage("BecomeOnTrigger"); //sends message to game object to become on trigger 
        }
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(damageTag))
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                other.SendMessage("TakeDamage", damage);
                other.GetComponent<TopDownCharacterController2D>().speed /= slowAmount; //reduce target speed

                timer = 0;
            }
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(damageTag))
        {
            other.GetComponent<TopDownCharacterController2D>().speed = maxSpeed; //set target speed back to normal
        }
    }
}
