using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherBlast : MonoBehaviour {
    public Light spotlight;
    public Texture spotlightCookie;
    public int spotAngle = 135;

    public float returnTime = 0.3f;
    public Color attackColour;
    MeleeAttack meleeAttackScript;
    float originalSize;
    Color originalColour;

    // Use this for initialization
    void Start()
    {
        meleeAttackScript = gameObject.GetComponent<MeleeAttack>();
        originalSize = spotlight.spotAngle;
        originalColour = spotlight.color;
    }

    void ChangeLight()
    {
        spotlight.spotAngle = spotAngle;
        spotlight.color = attackColour;
        spotlight.cookie = spotlightCookie;

        Debug.Log("ChangeLight");

        Invoke("ReturnToNormal", returnTime);
    }

    void ReturnToNormal()
    {
        spotlight.color = originalColour;
        spotlight.spotAngle = originalSize;
        spotlight.cookie = null;
    }
    // Update is called once per frame
    void Update () {
		
        if (meleeAttackScript.IsHitting)
        {
            ChangeLight();
        }
        
	}
}
