using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    
}

[System.Serializable]
public struct Wave
{
    //���̺�
    public float spawnTime;
    public int maxEnemyCount;
    public GameObject[] enemyPrefabs;
}
