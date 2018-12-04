using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {


    private bool dir;
    private float random;

    //private Rigidbody
	// Use this for initialization
	void Awake () {
        if(random > 0.5)
        {
            dir = true;
        }
        else
        {
            dir = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
