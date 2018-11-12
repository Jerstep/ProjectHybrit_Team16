using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float speed;
    private Rigidbody RigidBullet;

    // Use this for initialization
    void Start ()
    {
        speed = 10;
        RigidBullet = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        RigidBullet.velocity = transform.up * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
