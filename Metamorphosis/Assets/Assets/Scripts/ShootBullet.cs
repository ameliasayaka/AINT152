using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public Image cooldownIcon;

    private bool isFiring = false;
  
    private void Start()
    {
        cooldownIcon.GetComponent<SkillCooldownIcon>().cooldownTime = fireTime;
    }

    //sets firing and cooling down to false
    void SetFiring()
    {
        isFiring = false;
        cooldownIcon.GetComponent<SkillCooldownIcon>().coolingDown = false;
    }

	void Fire()
    {
        isFiring = true;
        cooldownIcon.GetComponent<SkillCooldownIcon>().coolingDown = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        Invoke("SetFiring", fireTime);
    }
	
	// Update is called once per frame
	void Update () {
        //if left mouse clicked and not already firing/cooling down fire
		if(Input.GetMouseButtonDown(0))
        {
            if (!isFiring)
            {
                Fire();
                
            }
        }
	}
}
