using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public float enemyHp;
    public GameObject deathParticle;
    public GameObject explotionCollider;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp <= 0)
        {
            Kill();
        }

    }

    void Kill()
    {
        Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(explotionCollider, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallDeath" || other.tag == "Hazard" || other.tag == "Boss")
        {
            Kill();
        }
    }
}
