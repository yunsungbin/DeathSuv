using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPview : MonoBehaviour
{
    private EnemyHP enemyHP;
    private Slider hpSlider;

    public void SetUp(EnemyHP enemyHP)
    {
        this.enemyHP = enemyHP;
        hpSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = enemyHP.CurHP / enemyHP.MaxHP;
    }
}
