﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //rigidbody
    private Rigidbody RigidPlayer;
    private static bool playerExists;
    private UIManager uiMan;

    public float moveSpeed;
    public GameObject bulletPrefab, heavyBulletPrefab;
    public Transform firePoint;
    public int playerHealth;
    public bool imActive;
    public bool player1;
    public bool canShoot;

    public GameObject specialShotParticle;
    public GameObject specialBullet;
    private bool canSpecialShoot;
    public float waitTime;


    [HideInInspector] public bool fire;
    private float cooldown = 0;

    [Header("Time in sec")]
    public float setCooldown;

    private void Awake()
    {
        cooldown = setCooldown;
    }

    // Use this for initialization
    void Start()
    {
        RigidPlayer = GetComponent<Rigidbody>();
        uiMan = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
        {
            Shoot();
        }

        if(canSpecialShoot)
        {
            SpecialShoot();
        }
        

        //left right
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            RigidPlayer.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, RigidPlayer.velocity.y, 0);
        }
        //up down
        if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical")* moveSpeed * Time.deltaTime , 0));
            RigidPlayer.velocity = new Vector3(RigidPlayer.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed, 0);
        }

        //stp moving
        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            RigidPlayer.velocity = new Vector3(0f, RigidPlayer.velocity.y, 0);
        }
        if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            RigidPlayer.velocity = new Vector3(RigidPlayer.velocity.x, 0f, 0);
        }
        
        

        if(playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    void Shoot()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            cooldown = setCooldown;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }        
    }

    IEnumerator SpecialShoot()
    {
        GameObject tempParticleHolder = specialShotParticle;
        Instantiate(tempParticleHolder, firePoint.position, firePoint.rotation);
        tempParticleHolder.transform.parent = firePoint.transform;

        yield return new WaitForSeconds(waitTime);
        GameObject specialB = specialBullet;
        Instantiate(specialB, firePoint.position, firePoint.rotation);

    }

    void PlayerDeath()
    {
        if(player1)
        {
            uiMan.scoreP1 -= 100;
        }
        else
        {
            uiMan.scoreP2 -= 100;
        }
        imActive = false;
        gameObject.SetActive(false);
    }
}
