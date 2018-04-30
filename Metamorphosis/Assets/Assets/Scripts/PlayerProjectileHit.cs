using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileHit : MonoBehaviour {

    public int damage = 1;
    public string damageTag = "";

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == damageTag)
        {
            collision.gameObject.SendMessage("TakeDamage", damage);
            SendMessage("Die");
        }
    }

}
