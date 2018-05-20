using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public int damage;
    public string targetTag = "";
    public float meleeCooldown = 2.0f;
    AudioSource hitAudio;
    

    private bool isHitting;
    float timer;
    // Use this for initialization
    void Start () {
        timer = 0;
        hitAudio = GetComponent<AudioSource>();
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
           
            if (timer == 0)
            {
                GetComponent<Animator>().SetBool("isHitting", true);
                collision.gameObject.SendMessage("TakeDamage", damage);
                isHitting = true;
                timer = meleeCooldown;
                if (hitAudio!= null)
                {
                    hitAudio.Play();
                }

            }
        }
    }

    public bool IsHitting
    {
        get { return isHitting; }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            GetComponent<Animator>().SetBool("isHitting", false);
            isHitting = false;
        }
        else if (timer < 0)
        {
            timer = 0;
        }
    }
}
