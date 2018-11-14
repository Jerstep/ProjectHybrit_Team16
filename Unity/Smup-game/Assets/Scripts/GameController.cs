using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy, enemy2, enemy3, boulder,tree;
    public Transform rotation;
    public Vector3 spawnValues, spawnValuesTree;
    public int enemyCount, boulderCount, treeCount;
    public float startWaitTime,spawnWaitTime, waveWaitTime;
    public int patternCount;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnWavesBulders());
        StartCoroutine(SpawnWavesTree());
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

    IEnumerator SpawnWavesBulders()
    {
        yield return new WaitForSeconds(startWaitTime + 1);
        while (true)
        {
            for (int i = 0; i < boulderCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(boulder, spawnPosition, SpawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime);
        }
    }

    IEnumerator SpawnWavesTree()
    {
        yield return new WaitForSeconds(startWaitTime - 0.5f);
        while (true)
        {
            for (int i = 0; i < treeCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValuesTree.x, spawnValues.y, spawnValues.z);
                Vector3 spawnPosition2 = new Vector3(-spawnValuesTree.x, spawnValues.y, spawnValues.z);
                Quaternion SpawnRotation = rotation.rotation;
                Instantiate(tree, spawnPosition, SpawnRotation);
                Instantiate(tree, spawnPosition2, SpawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime); 
        }
    }
}
