using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState {  SearchTarget = 0, AttackToTarget }

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private int towerBuildGold = 50; //�Ǽ� ���Ǵ� ���
    [SerializeField]
    private EnemySpawner enemySpawner; //�� ����Ʈ ����
    [SerializeField]
    private PlayerGold playerGold; //���Ҹ� ���� ��

    public void SpawnTower(Transform tileTransform)
    {
        if(towerBuildGold > playerGold.CurGold)
        {
            return;
        }
        Tile tile = tileTransform.GetComponent<Tile>();

        if(tile.IsBuildTower == true)
        {
            return;
        }

        tile.IsBuildTower = true;

        playerGold.CurGold -= towerBuildGold;

        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
    }
}
