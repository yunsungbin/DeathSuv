using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab;
    public Weapon[] weapon; //타워 정보

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; //이미지
        public float damage;
        public float rate; //속도
        public float range; //범위
        public int cost; //필요골드
    }
}
