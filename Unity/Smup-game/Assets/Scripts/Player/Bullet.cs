using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float speed;
    private Rigidbody RigidBullet;
    private UIManager uiManager;
    private Player player1, player2;

    public bool heavy;
    public bool p1Owner, enemyOwner;
    // Use this for initialization
    void Start ()
    {
        if (!heavy)
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }
        RigidBullet = GetComponent<Rigidbody>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(p1Owner || enemyOwner)
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

        if (other.tag == "Player-1" || other.tag == "Player-2")
        {
            other.GetComponent<Player>().hp -= 10;
            Destroy(gameObject);
        }

         if (other.tag == "Enemy" && enemyOwner == false)
         {
            if(p1Owner)
            {
                uiManager.scoreP1 += 10;
            }
            else
            {
                uiManager.scoreP2 += 10;
            }

            Destroy(other.gameObject);
            if (!heavy)
            {
                Destroy(gameObject);
            }              
        }
        if (other.tag == "Walls" || other.tag == "WallDeath" || other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
