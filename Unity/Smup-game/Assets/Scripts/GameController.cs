using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player1, player2;

    public GameObject enemy, enemy2, enemy3,enemyP2,enemy2P2,enemy3P2, boulder;
    public Transform rotation;
    public Vector3 spawnValues;
    public int enemyCount, boulderCount;
    public float startWaitTime,spawnWaitTime, waveWaitTime;
    public int patternCount;


	// Use this for initialization
	void Start ()
    {
        
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnWavesBulders());
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(player1.GetComponent<Player>().imActive == false)
        {
            StartCoroutine(TurnOnP1());
        }

        if (player2.GetComponent<Player>().imActive == false)
        {
            StartCoroutine(TurnOnP2());
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWaitTime);
        while(patternCount == 1)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Vector3 spawnPosition2 = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion SpawnRotation = enemy.transform.rotation;
                Instantiate(enemy, spawnPosition, SpawnRotation);
                Instantiate(enemyP2, spawnPosition2, SpawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime);
            patternCount++;
        }

        while (patternCount == 2)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Vector3 spawnPosition2 = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z); ;
                Quaternion SpawnRotation = enemy.transform.rotation;
                Instantiate(enemy2, spawnPosition, SpawnRotation);
                Instantiate(enemy2P2, spawnPosition2, SpawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime);
            patternCount++;
        }

        while (patternCount == 3)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Vector3 spawnPosition2 = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion SpawnRotation = enemy.transform.rotation;
                Instantiate(enemy3, spawnPosition, SpawnRotation);
                Instantiate(enemy3P2, spawnPosition2, SpawnRotation);
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


    IEnumerator TurnOnP1()
    {
        yield return new WaitForSeconds(3);
        player1.SetActive(true);
        player1.GetComponent<Player>().imActive = true;
        player1.GetComponent<Player>().hp = 100;

    }

    IEnumerator TurnOnP2()
    {
        yield return new WaitForSeconds(3);
        player2.SetActive(true);
        player2.GetComponent<Player>().imActive = true;
        player2.GetComponent<Player>().hp = 100;
    }
}
