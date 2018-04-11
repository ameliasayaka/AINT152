using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public int damageTime = 3;
    public int damage;
    public string targetTag;
    public int timer = 0;


    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (timer <= 0)
            other.gameObject.SendMessage("TakeDamage", damage);
            timer = damageTime; 
        }
        
    }


    // Update is called once per frame
    void UpdateFixed () {
        
	}
}
