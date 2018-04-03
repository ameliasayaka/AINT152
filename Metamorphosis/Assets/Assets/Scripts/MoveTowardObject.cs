﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardObject : MonoBehaviour {

    public Transform target;
    public float speed = 5.0f;


	// Update is called once per frame
	void FixedUpdate () {
		if(target != null)
        {
            if (GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
        }
	}
}
