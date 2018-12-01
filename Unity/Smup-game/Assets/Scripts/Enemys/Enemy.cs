using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody RigidEnemy;

    public float moveSpeedX, moveSpeedY;
    public bool pattern1, pattern2, pattern3;
    public bool right, targetP1;
    public int switchTime;

    // Use this for initialization
    void Start ()
    {
		RigidEnemy = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(pattern1 == true)
        {
            if(targetP1)
            {
                RigidEnemy.velocity = new Vector3(RigidEnemy.velocity.x, moveSpeedY * 3, 0);
            }
            else
            {
                RigidEnemy.velocity = new Vector3(RigidEnemy.velocity.x, -moveSpeedY * 3, 0);
            }

            if (right == true)
            {
                RigidEnemy.velocity = new Vector3(moveSpeedX, RigidEnemy.velocity.y, 0);
            }
            else
            {
                RigidEnemy.velocity = new Vector3(-moveSpeedX, RigidEnemy.velocity.y, 0);
            }

            StartCoroutine(PatternOne());
        }
        if (pattern2 == true)
        {
            StartCoroutine(PatternTwo());
        }
        if (pattern3 == true)
        {
            StartCoroutine(PatternThree());
        }
        

    }

    IEnumerator PatternOne()
    {
        yield return new WaitForSeconds(switchTime);
        right = right ? false : true;
    }

    IEnumerator PatternTwo()
    {
        if (targetP1)
        {
            RigidEnemy.velocity = new Vector3(RigidEnemy.velocity.x, moveSpeedY, 0);
        }
        else
        {
            RigidEnemy.velocity = new Vector3(RigidEnemy.velocity.x, -moveSpeedY, 0);
        }
        yield return new WaitForSeconds(switchTime);
        if(right)
        {
            RigidEnemy.velocity = new Vector3(moveSpeedX, 0, 0);
        }
        else
        {
            RigidEnemy.velocity = new Vector3(-moveSpeedX, 0, 0);
        }
        
        yield return new WaitForSeconds(switchTime);
        if (targetP1)
        {
            RigidEnemy.velocity = new Vector3(RigidEnemy.velocity.x, -moveSpeedY, 0);
        }
        else
        {
            RigidEnemy.velocity = new Vector3(RigidEnemy.velocity.x, moveSpeedY, 0);
        }
    }

    IEnumerator PatternThree()
    {
        RigidEnemy.velocity = new Vector3(RigidEnemy.velocity.x, moveSpeedY * 2, 0);
        yield return new WaitForSeconds(switchTime);
        if (right)
        {
            RigidEnemy.velocity = new Vector3(moveSpeedX * 2, 0, 0);
        }
        else
        {
            RigidEnemy.velocity = new Vector3(-moveSpeedX * 2, 0, 0);
        }
        yield return new WaitForSeconds(switchTime);
        RigidEnemy.velocity = new Vector3(0, -moveSpeedY * 2, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Walls")
        {
            right = right ? false : true;
        }
        if (other.tag == "WallDeath" || other.tag == "Hazard")
        {
            Destroy(gameObject);
        }
    }
}
