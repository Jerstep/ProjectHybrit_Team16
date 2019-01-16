using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreseFireRate : MonoBehaviour {

    public GameObject pickupEffect;
    public float fireRateMod = 1.4f;
    public float duration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player-1") || other.CompareTag("Player-2"))
        {
           StartCoroutine(ReduceFireRate(other) );
        }
    }

    IEnumerator ReduceFireRate(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Special ammo moet nog toegevoegd worden aan player
        Player p = player.GetComponent<Player>();
        p.setCooldown /= fireRateMod;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        p.setCooldown *= fireRateMod;
        Destroy(gameObject);
    }
}
