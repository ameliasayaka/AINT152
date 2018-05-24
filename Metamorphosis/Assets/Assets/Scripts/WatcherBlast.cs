using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherBlast : MonoBehaviour {
    public Light spotlight;
    public Texture spotlightCookie;
    public int spotAngle = 135;

    //time before spotlight turned back to normal
    public float returnTime = 0.3f;
    public Color attackColour;

    //script for melee attack
    MeleeAttack meleeAttackScript;

    //spotlight original settings
    float originalSize;
    Color originalColour;

    // Use this for initialization
    void Start()
    {
        meleeAttackScript = gameObject.GetComponent<MeleeAttack>();
        originalSize = spotlight.spotAngle;
        originalColour = spotlight.color;
    }

    //method to change light colour, size and cookie
    void ChangeLight()
    {
        spotlight.spotAngle = spotAngle;
        spotlight.color = attackColour;
        spotlight.cookie = spotlightCookie;

        Invoke("ReturnToNormal", returnTime);
    }

    //method to return light to normal
    void ReturnToNormal()
    {
        spotlight.color = originalColour;
        spotlight.spotAngle = originalSize;
        spotlight.cookie = null;
    }
    // Update is called once per frame
    void Update () {
		
        //change light on melee attack
        if (meleeAttackScript.IsHitting)
        {
            ChangeLight();
        }
        
	}
}
