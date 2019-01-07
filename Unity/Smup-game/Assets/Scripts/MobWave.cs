using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public struct MobWave
{
    public enum WaveType
    {
        Formations
    }
    public WaveType Type;

    public GameObject enemyFormation;

    public int formationEnemyCount;

    public float spawnValueYPos;
}