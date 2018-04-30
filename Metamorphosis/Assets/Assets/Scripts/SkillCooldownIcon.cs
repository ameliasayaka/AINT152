using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldownIcon : MonoBehaviour
{

    public Image cooldownImage;
    public bool coolingDown;

    public float cooldownTime;

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (coolingDown == true)
        {
            //Increase fill amount
            cooldownImage.fillAmount += 1.0f / cooldownTime * Time.deltaTime;
        }
        else
        {
            cooldownImage.fillAmount = 0;
        }
    }
}
