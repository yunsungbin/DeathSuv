using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState {  SearchTarget = 0, AttackToTarget }

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private TowerTemplate towerTemplate;
    //[SerializeField]
    //private GameObject towerPrefab;
    //[SerializeField]
    //private int towerBuildGold = 50; //건설 사용되는 골드
    [SerializeField]
    private EnemySpawner enemySpawner; //적 리스트 정보
    [SerializeField]
    private PlayerGold playerGold; //감소를 위한 것

    public void SpawnTower(Transform tileTransform)
    {
        if(towerTemplate.weapon[0].cost > playerGold.CurGold)
        {
            return;
        }
        Tile tile = tileTransform.GetComponent<Tile>();

        if(tile.IsBuildTower == true)
        {
            return;
        }

        tile.IsBuildTower = true;

        playerGold.CurGold -= towerTemplate.weapon[0].cost;

        Vector3 pos = tileTransform.position + Vector3.back;

        GameObject clone = Instantiate(towerTemplate.towerPrefab, pos, Quaternion.identity);

        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner, playerGold);
    }
}
