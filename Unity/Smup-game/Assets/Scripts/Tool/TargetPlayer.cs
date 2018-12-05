using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{

    public GameObject playerOne;
    public GameObject playerTwo;

    private Vector3 target;

    private float dis1;
    private float dis2;
    [SerializeField] private float speed;

	// Use this for initialization
	void Start ()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player-1");
        playerTwo = GameObject.FindGameObjectWithTag("Player-2");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        dis1 = Vector3.Distance(playerOne.transform.position, transform.position);
        dis2 = Vector3.Distance(playerTwo.transform.position, transform.position);

        if(dis1 < dis2)
        {
            target = playerOne.transform.position;
        }

        if(dis1 > dis2)
        {
            target = playerTwo.transform.position;
        }

        RotateToTarget();
	}

    void RotateToTarget()
    {
        Vector3 targetDir = target - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
