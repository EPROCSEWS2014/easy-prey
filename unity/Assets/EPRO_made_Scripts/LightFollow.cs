﻿using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {
	private float lightPositionX = -2.3f;

	private Transform player;

    private Transform light;
    
	private Quaternion leftPos = new Quaternion (0,0.58f,0,1);
	private Quaternion rightPos = new Quaternion (0,-0.58f,0,1);

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		light = gameObject.transform;
	}
	
	void Update() {
		Track();
	}

	void Track() {
		Quaternion to;

		float targetX = player.position.x;
		float targetY = player.position.y;

        if (player.localScale.x >= 0)
        {
			to = leftPos;
			targetX += lightPositionX;
        }
        else
        {
			to = rightPos;
			targetX -= lightPositionX;
        }

		light.rotation = Quaternion.Lerp (light.rotation, to, Time.deltaTime * 5);
		light.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
