using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    //public Transform bulletSpawn2;
    public float fireTime = 0.5f;
    public Image cooldownIcon;

    private bool isFiring = false;
  
    private void Start()
    {
        cooldownIcon.GetComponent<SkillCooldownIcon>().cooldownTime = fireTime;
    }

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
        //Instantiate(bulletPrefab, bulletSpawn2.position, bulletSpawn2.rotation);

        //if (GetComponent<AudioSource>() != null)
        //{
        //    GetComponent<AudioSource>().Play();
        //}

        Invoke("SetFiring", fireTime);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!isFiring)
            {
                Fire();
                
            }
        }
	}
}
