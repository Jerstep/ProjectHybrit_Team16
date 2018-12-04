using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private GameObject middleObject;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        middleObject = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        OrbitAround();
	}

    void OrbitAround()
    {
        transform.RotateAround(middleObject.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}
