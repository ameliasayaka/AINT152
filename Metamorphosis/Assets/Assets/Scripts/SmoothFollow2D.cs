using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour {

    public Transform target;
    public float x = 10f;
    public float y = 10f;
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos,10);
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, -x, x), Mathf.Clamp(transform.position.y,-y,y), transform.position.z); //clamps camera to screen bounds
    }
}
