using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpecialBullet : MonoBehaviour {

    public GameObject pickupEffect;
    public float powerUpMoveSpeed = 10;
    public bool killer;

    private void Start()
    {
        killer = Random.value > 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player-1") || other.CompareTag("Player-2"))
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            var player = other.GetComponent<Player>();
            AddBullet(player);
        }
    }

    private void Update()
    {

        if(killer)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * powerUpMoveSpeed;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = transform.forward * -powerUpMoveSpeed;
        }

    }

    void AddBullet(Player player)
    {
        // Special ammo moet nog toegevoegd worden aan player
        player.canSpecialShoot = true;
    }
}
