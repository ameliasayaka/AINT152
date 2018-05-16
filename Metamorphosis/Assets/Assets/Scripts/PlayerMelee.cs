using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMelee : MonoBehaviour {

    public int damage;
    public string targetTag = "";
    public float meleeCooldown = 2.0f;

    private bool isHitting = false;
    private bool hitAlready = false;

    public Image cooldownIcon;
    SkillCooldownIcon iconScript;

    // Use this for initialization
    private void Start()
    {
        iconScript = cooldownIcon.GetComponent<SkillCooldownIcon>();
        iconScript.cooldownTime = meleeCooldown;
    }

    void SetHit()
    {
        isHitting = false;
        iconScript.coolingDown = false;
        hitAlready = false;
        GetComponent<Animator>().SetBool("isHitting", false);
    }

    void Melee()
    {
        isHitting = true;
        iconScript.coolingDown = true;
        Invoke("SetHit", meleeCooldown);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isHitting && !hitAlready)
        {
            if (collision.tag == targetTag)
            {
                collision.gameObject.SendMessage("TakeDamage", damage);
                hitAlready = true;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (isHitting == false)
                {
                    Melee();
                    GetComponent<Animator>().SetBool("isHitting", true);
            }
            }
    }
}
