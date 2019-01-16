using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float speed;
    private Rigidbody RigidBullet;
    private UIManager uiManager;

    [Header("Bullet Speeds")]
    public int heavySpeed;
    public int normalSpeed;

    [Header("Particle on collision")]
    public GameObject hitParticle;

    [HideInInspector] public bool heavy;
    [HideInInspector] public bool p1Owner, enemyOwner;
    // Use this for initialization
    void Start ()
    {
        if (heavy)
        {
            speed = heavySpeed;
        }
        else
        {
            speed = normalSpeed;
        }
        RigidBullet = GetComponent<Rigidbody>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (p1Owner || enemyOwner)
        {
            RigidBullet.velocity = transform.up * speed;
        }
        else
        {
            RigidBullet.velocity = transform.up * -speed;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player-1")
        {
            if (uiManager.scoreP1 >= uiManager.scoreP2)
            {
                other.GetComponent<Player>().playerHealth -= 10;
            }
            Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Player-2")
        {
            if (uiManager.scoreP2 >= uiManager.scoreP1)
            {
                other.GetComponent<Player>().playerHealth -= 10;
            }
            Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Enemy" && enemyOwner == false)
         {
            if (p1Owner)
            {
                uiManager.scoreP1 += 10;
            }
            else
            {
                uiManager.scoreP2 += 10;
            }

            other.GetComponentInParent<Enemy>().enemyHp -= 10;

            if (!heavy)
            {
                Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }              
        }

        if (other.tag == "Boss" && enemyOwner == false)
        {
            if (p1Owner)
            {
                uiManager.scoreP1 += 10;
            }
            else
            {
                uiManager.scoreP2 += 10;
            }
            other.GetComponentInParent<Boss>().bossHp -= 1;
            Instantiate(hitParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Walls" || other.tag == "WallDeath" /*|| other.tag == "Bullet"*/)
        {
            Destroy(gameObject);
        }
    }
}
