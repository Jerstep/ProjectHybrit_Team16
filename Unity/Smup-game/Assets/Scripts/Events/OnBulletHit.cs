using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBulletHit : MonoBehaviour {

    public delegate void BulletHit(GameObject other, int hitDamage);
    public static event BulletHit SendHit;

    public string bulletOwner;
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag(bulletOwner))
        {
            if(SendHit != null)
            {
                SendHit(other.gameObject, damage);
            }
        }
    }
}
