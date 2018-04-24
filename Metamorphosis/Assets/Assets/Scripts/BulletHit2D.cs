using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit2D : MonoBehaviour {


    public int damage = 1;
    public string damageTag = "";
    public float slowAmount = 10;

    private Vector2 slowForce;

    private void Start()
    {
        slowForce = new Vector2(slowAmount, slowAmount);
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
            other.GetComponent<Rigidbody2D>().AddForce(slowForce);
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(damageTag))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(-slowForce);
        }
    }
}
