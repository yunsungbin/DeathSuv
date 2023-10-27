using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    //���̺� ����
    [SerializeField]
    private Wave[] waves;
    [SerializeField]
    private EnemySpawner enemySpawner;
    private int curWaveIndex = -1;

    public int CurWave => curWaveIndex + 1;
    public int MaxWave => waves.Length;

    public void StartWave()
    {
        if(enemySpawner.EnemyList.Count == 0 && curWaveIndex < waves.Length - 1)
        {
            curWaveIndex++;

            enemySpawner.StartWave(waves[curWaveIndex]);
        }
    }
}

[System.Serializable]
public struct Wave
{
    //���̺�
    public float spawnTime;
    public int maxEnemyCount;
    public GameObject[] enemyPrefabs;
}
