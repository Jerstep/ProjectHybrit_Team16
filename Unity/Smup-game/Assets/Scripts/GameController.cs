using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy, enemy2, enemy3;
    public Vector3 spawnValues;
    public int enemyCount;
    public float startWaitTime,spawnWaitTime, waveWaitTime;
    public int patternCount;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnWaves());

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWaitTime);
        while(patternCount == 1)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, SpawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime);
            patternCount++;
        }
        while (patternCount == 2)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(enemy2, spawnPosition, SpawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime);
            patternCount++;
        }
        while (patternCount == 3)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(enemy3, spawnPosition, SpawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime);
            patternCount = 1;
            StartCoroutine(SpawnWaves());
        }

    }
}
