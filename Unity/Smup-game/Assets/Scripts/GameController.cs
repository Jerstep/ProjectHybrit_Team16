using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player1, player2;

    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemyFormations;
        private string[] names;
        public Vector3 spawnValues;
        [Range(1, 10)]
        public int formationEnemyCount;

        public enum directions {left,right,up,down}
        public directions[] Directions;
    }
    public Wave[] waves;
    public int waveNumber;

    public float startWaitTime,spawnWaitTime, waveWaitTime;
    


	// Use this for initialization
	void Start ()
    {
        player1 = GameObject.FindGameObjectWithTag("Player-1");
        player2 = GameObject.FindGameObjectWithTag("Player-2");
        StartCoroutine(SpawnWaves(waves[waveNumber]));
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

    IEnumerator SpawnWaves(Wave _wave)
    {
        yield return new WaitForSeconds(startWaitTime);
        for (int i = 0; i < _wave.enemyFormations.Length; i++)
            {
                Vector3 spawnPosition = new Vector3(_wave.spawnValues.x, Random.Range(-_wave.spawnValues.y, _wave.spawnValues.y), _wave.spawnValues.z);
                Quaternion SpawnRotation = _wave.enemyFormations[i].transform.rotation;
                Instantiate(_wave.enemyFormations[i], spawnPosition, SpawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime);
            waveNumber++;
            WaveCompleted();
    }

    void WaveCompleted()
    {
        if(waveNumber < waves.Length)
        {
            Debug.Log("we get to wavecomp");
            StartCoroutine(SpawnWaves(waves[waveNumber]));
        }
        else
        {
            Debug.Log("we done here");
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
