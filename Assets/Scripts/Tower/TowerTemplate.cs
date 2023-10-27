using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab;
    public Weapon[] weapon; //Ÿ�� ����

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; //�̹���
        public float damage;
        public float rate; //�ӵ�
        public float range; //����
        public int cost; //�ʿ���
    }
}
