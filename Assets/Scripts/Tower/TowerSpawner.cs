using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private TowerTemplate[] towerTemplate;
    [SerializeField]
    private EnemySpawner enemySpawner; //적 리스트 정보
    [SerializeField]
    private PlayerGold playerGold; //감소를 위한 것
    [SerializeField]
    private SystemTextView SystemTextView;
    private bool isOnTowerButton = false;
    private GameObject followTowerClone = null;
    private int towerType;

    public void ReadyToSpawneTower(int type)
    {
        towerType = type;
        if(isOnTowerButton == true)
        {
            return;
        }
        if(towerTemplate[towerType].weapon[0].cost > playerGold.CurGold)
        {
            SystemTextView.PrintText(SystemType.Money);
            return;
        }

        isOnTowerButton = true;

        followTowerClone = Instantiate(towerTemplate[towerType].followTowerPrefab);

        StartCoroutine("OnTowerCancelSystem");
    }

    public void SpawnTower(Transform tileTransform)
    {
        if(isOnTowerButton == false)
        {
            return;
        }
        Tile tile = tileTransform.GetComponent<Tile>();

        if(tile.IsBuildTower == true)
        {
            SystemTextView.PrintText(SystemType.Build);
            return;
        }

        isOnTowerButton = false;

        tile.IsBuildTower = true;

        playerGold.CurGold -= towerTemplate[towerType].weapon[0].cost;

        Vector3 pos = tileTransform.position + Vector3.back;

        GameObject clone = Instantiate(towerTemplate[towerType].towerPrefab, pos, Quaternion.identity);

        clone.GetComponent<TowerWeapon>().SetUp(enemySpawner, playerGold, tile);

        Destroy(followTowerClone);

        StopCoroutine("OnTowerCancelSystem");
    }

    IEnumerator OnTowerCancelSystem()
    {
        while (true)
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButton(1))
            {
                isOnTowerButton = false;
                Destroy(followTowerClone);
                break;
            }

            yield return null;
        }
    }
}
