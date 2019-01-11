﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [Header("Projectile Settings")]
    public int numberOfProjectiles, waitTime;
    public float speed;
    public GameObject bulletPrefab;
    public Transform[] firePoint;

    [Header("Private Variables")]
    private Vector3 startPoint;
    private const float radius = 1f;
	
	// Update is called once per frame
	void Start ()
    {
        StartCoroutine(ShootNow());
    }






   /* private void SpawnProjectile(int _numberofProjectiles)
    {
        float angleStep = 360f / _numberofProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberofProjectiles - 1; i++)
        {
            //directions calculations
            float projectileDirXPos = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPos = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPos, projectileDirYPos, 0);
            Vector3 projectileMoveDir = (projectileVector - startPoint).normalized * speed;

            GameObject tmpObj = Instantiate(bulletPrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDir.x, 0, 0);

            angle += angleStep;
        }
    }*/

    IEnumerator ShootNow()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            for (int i = 0; i < firePoint.Length; i++)
            { 
                Instantiate(bulletPrefab, firePoint[i].position, firePoint[i].rotation);
            }
           
        }
            

        /* while(waitTime == 1)
         {
             yield return new WaitForSeconds(waitTime);
             startPoint = transform.position;
             SpawnProjectile(numberOfProjectiles);
         }*/

    }
}
