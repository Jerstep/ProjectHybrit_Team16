using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpecialBullet : MonoBehaviour {

    public int toAddAmmoAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player-1") || other.CompareTag("Player-2"))
        {
            AddBullet(other);
        }
    }

    void AddBullet(Collider player)
    {
        // Special ammo moet nog toegevoegd worden aan player
        //player.specialAmmo += toAddAmmoAmount;
    }
}
