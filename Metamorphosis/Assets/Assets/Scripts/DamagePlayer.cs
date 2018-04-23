using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    
    public int damage;
    public string targetTag = "Player";
    

  

  


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {     
               collision.gameObject.SendMessage("TakeDamage", damage);     
        }
    }


    // Update is called once per frame
 
}
