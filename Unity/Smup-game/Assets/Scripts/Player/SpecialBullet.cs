using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{


    [SerializeField] private float speed;
    private Rigidbody RigidBullet;
    private UIManager uiManager;

    [Header("Particle on collision")]
    public GameObject hitParticle;

    public bool p1Owner;
    // Use this for initialization
    void Start()
    {
        RigidBullet = GetComponent<Rigidbody>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(p1Owner)
        {
            RigidBullet.velocity = transform.up * -speed;
        }
        else
        {
            RigidBullet.velocity = transform.up * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player-1" && !p1Owner)
        {
            if(uiManager.scoreP1 >= uiManager.scoreP2)
            {
                other.GetComponent<Player>().playerHealth -= 20;
            }
            Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if(other.tag == "Player-2" && p1Owner)
        {
            if(uiManager.scoreP2 >= uiManager.scoreP1)
            {
                other.GetComponent<Player>().playerHealth -= 20;
            }
            Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if(other.tag == "Enemy")
        {
            if(p1Owner)
            {
                uiManager.scoreP1 += 10;
            }
            else
            {
                uiManager.scoreP2 += 10;
            }
        }

        if(other.tag == "Walls" || other.tag == "WallDeath")
        {
            Destroy(gameObject);
        }
    }
}