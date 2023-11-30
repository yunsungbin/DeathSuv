using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab;
    public GameObject followTowerPrefab; //임시 타워
    public Weapon[] weapon; //타워 정보

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; //이미지
        public float damage;  //데미지
        public float slow;    //감속 퍼센트
        public float buff;    //공격력 증가율
        public float rate;    //속도
        public float range;   //범위
        public int cost;      //필요골드
        public int sell;      //판매골드
    }
}
