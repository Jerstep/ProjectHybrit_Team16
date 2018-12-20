using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletController : MonoBehaviour {

    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float speed;
    public GameObject bulletPrefab;

    [Header("Private Variables")]
    private Vector3 startPoint;
    private const float radius = 1f;


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startPoint = transform.position;
            SpawnProjectile(numberOfProjectiles);
        }

    }

    private void SpawnProjectile(int _numberofProjectiles)
    {
        float angleStep = 360f / _numberofProjectiles;
        float angle = 0f;

        for(int i = 0; i <= _numberofProjectiles -1; i++)
        {
            //directions calculations
            float projectileDirXPos = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPos = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPos, projectileDirYPos, 0);
            Vector3 projectileMoveDir = (projectileVector - startPoint).normalized * speed;

            GameObject tmpObj = Instantiate(bulletPrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDir.x, 0, projectileMoveDir.y);

            angle += angleStep;
        }
    }
}
