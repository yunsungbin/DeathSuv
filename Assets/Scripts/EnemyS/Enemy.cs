using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDestroyType { kill = 0, Arrive }

public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int curIndex = 0;
    private MoveMent moveMent;
    private EnemySpawner enemySpawner;
    [SerializeField]
    private int gold = 10;

    public void SetUp(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        moveMent = GetComponent<MoveMent>();
        this.enemySpawner = enemySpawner;

        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[curIndex].position;

        StartCoroutine(OnMove());
    }

    IEnumerator OnMove()
    {
        NextMove();

        while (true)
        {
            transform.Rotate(Vector3.forward * 10);

            if(Vector3.Distance(transform.position, wayPoints[curIndex].position) < 0.02f * moveMent.MoveSpeed)
            {
                NextMove();
            }

            yield return null;
        }
    }

    void NextMove()
    {
        if(curIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[curIndex].position;

            curIndex++;
            Vector3 dir = (wayPoints[curIndex].position - transform.position).normalized;
            moveMent.MoveTo(dir);
        }
        else
        {
            gold = 0;
            OnDie(EnemyDestroyType.Arrive);
        }
    }

    public void OnDie(EnemyDestroyType type)
    {
        enemySpawner.DestroyEnemy(type, this, gold);
    }
}
