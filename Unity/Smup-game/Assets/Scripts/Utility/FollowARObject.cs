﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowARObject : MonoBehaviour {

    public Transform ARTarget;

    public float xOffset;
    public float yOffset;

    public float xPosOffset;
    public float yPosOffset;

    [Header("Set to exactly follow targets (increse values)")]
    public float xPos;
    public float yPos;


	// Use this for initialization
	void Start () {
        if(ARTarget == null)
        {
            //ARTarget = GameObject.FindGameObjectWithTag("ARTarget").transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        xOffset = Remap(ARTarget.position.x + xPosOffset, -41f, 41f, -xPos, xPos);
        yOffset = Remap(ARTarget.position.y + yPosOffset, -23f, 23f, -yPos, yPos);

        if(ARTarget != null)
        {
            transform.position = new Vector3(xOffset, yOffset, this.transform.position.z);
            //transform.rotation = ARTarget.transform.rotation;  /*ARTarget.transform.rotation;*/
        }
        else
        {
            transform.position = this.transform.position;
        }
	}

    public static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
