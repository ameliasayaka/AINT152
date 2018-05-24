using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 5.0f;
    public float destroyTime = 0.7f;
    public float speedReduction = 0.5f;
    public bool isSlowing = false;

    private Collider2D objectCollider;

    // Use this for initialization
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        Invoke("Die", destroyTime);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        CancelInvoke("Die");
    }

    //changes projectile collision to Trigger
    void BecomeOnTrigger()
    {
        speed = 0;
        GetComponent<Rigidbody2D>().isKinematic = true;
        objectCollider.isTrigger = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed > 0)
        {
            speed -= speedReduction; //reduces projectile speed
        }
        else
        {
            if (isSlowing)
            {
                BecomeOnTrigger(); //only becomes on trigger if slowing projectile
            }
        }
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
