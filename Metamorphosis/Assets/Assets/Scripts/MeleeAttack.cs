using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public int damage;
    public string targetTag = "Player";
    public float meleeCooldown = 2.0f;

    float timer;
    // Use this for initialization
    void Start () {
        timer = 0;
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                collision.gameObject.SendMessage("TakeDamage", damage);
                timer = meleeCooldown;
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
