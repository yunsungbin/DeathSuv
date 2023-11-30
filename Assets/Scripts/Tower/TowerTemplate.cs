using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab;
    public GameObject followTowerPrefab; //�ӽ� Ÿ��
    public Weapon[] weapon; //Ÿ�� ����

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; //�̹���
        public float damage;  //������
        public float slow;    //���� �ۼ�Ʈ
        public float buff;    //���ݷ� ������
        public float rate;    //�ӵ�
        public float range;   //����
        public int cost;      //�ʿ���
        public int sell;      //�ǸŰ��
    }
}
