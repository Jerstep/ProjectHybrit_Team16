using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowARObject : MonoBehaviour {

    private Transform ARTarget;

	// Use this for initialization
	void Start () {
        if(ARTarget == null)
        {
            ARTarget = GameObject.FindGameObjectWithTag("ARTarget").transform;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(ARTarget != null)
        {
            transform.position = new Vector3(ARTarget.position.x, ARTarget.position.y, ARTarget.position.z);
            transform.rotation = ARTarget.transform.rotation;
        }
        else
        {
            transform.position = this.transform.position;
        }
	}
}
