using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    public float destroyTime;
	// Use this for initialization
	void Start () {
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

}
