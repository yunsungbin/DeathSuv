using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField]
    //private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    //[SerializeField]
    //private float spawnTime;
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private PlayerHP playerHP;
    [SerializeField]
    private PlayerGold playerGold;
    private Wave curWave;
    private int curEnemyCount;
    private List<Enemy> enmyList;

    public List<Enemy> EnemyList => enmyList;

    public int CurEnemyCount => curEnemyCount;
    public int MaxEnemyCount => curWave.maxEnemyCount;

    private void Awake()
    {
        enmyList = new List<Enemy>();

        //StartCoroutine(SpawnEnemy());
    }

    public void StartWave(Wave wave)
    {
        curWave = wave;

        curEnemyCount = curWave.maxEnemyCount;

        StartCoroutine(SpawnEnemy());
    }
    
    IEnumerator SpawnEnemy()
    {
        int SpawnEnemyCount = 0;

        while (SpawnEnemyCount < curWave.maxEnemyCount)
        {
            int enemyIndex = Random.Range(0, curWave.enemyPrefabs.Length);
            GameObject clone = Instantiate(curWave.enemyPrefabs[enemyIndex]);
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.SetUp(this, wayPoints);
            enmyList.Add(enemy);

            SpawnEnemyHPSlider(clone);

            SpawnEnemyCount++;

            yield return new WaitForSeconds(curWave.spawnTime);
        }
    }

    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy, int gold)
    {
        if(type == EnemyDestroyType.Arrive)
        {
            playerHP.TakeDamage(1);
        }
        else if(type == EnemyDestroyType.kill)
        {
            playerGold.CurGold += gold;
        }
        curEnemyCount--;
        enmyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);

        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localPosition = Vector3.one;

        sliderClone.GetComponent<SliderPosition>().SetUp(enemy.transform);
        sliderClone.GetComponent<EnemyHPview>().SetUp(enemy.GetComponent<EnemyHP>());
    }
}
