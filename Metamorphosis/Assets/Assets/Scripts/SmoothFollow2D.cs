﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow2D : MonoBehaviour {
    public Transform target;
    public float xMinimum = -10f;
    public float xMaximum = 10f;
    public float yMinimum = 10f;
    public float yMaximum = 10f;
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos,10);
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, xMinimum, xMaximum),
        Mathf.Clamp(transform.position.y,yMinimum,yMaximum), transform.position.z);
    }
}
