using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveData
{

    //public GameController gameController;
    public int waveSize;

    public int [] enumTypes;

    public string[] waveTypes;

    public int [] formationEnemyCount;
    public float [] spawnValueYPos;
    public float [] spawnWaitTime;


    public WaveData(GameController controller)
    {
        // Turns all seporate variables into lists of variables (the vars you use in the game controller)
        waveSize = controller.Waves.Count;

        waveTypes = new string [waveSize];
        formationEnemyCount = new int [waveSize];
        spawnValueYPos = new float [waveSize];
        spawnWaitTime = new float [waveSize];

        for(int i = 0; i < waveSize; i++)
        {
            //enumType[i] = controller.Waves.wave
            waveTypes[i] = controller.Waves[i].enemyFormation.ToString();
            formationEnemyCount[i] = controller.Waves[i].formationEnemyCount;
            spawnValueYPos[i] = controller.Waves[i].spawnValueYPos;
            spawnWaitTime[i] = controller.Waves[i].spawnWaitTime;
        }
    }
}
