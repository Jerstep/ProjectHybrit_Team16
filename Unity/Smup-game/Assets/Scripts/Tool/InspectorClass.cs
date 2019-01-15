using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorClass : MonoBehaviour
{
    public EnemyContainer[] formationContainer;
}

public class EnemyContainer : MonoBehaviour
{
    public GameObject[] enemyContainer = new GameObject[0];
}


