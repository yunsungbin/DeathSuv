using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Image imageScreen;
    [SerializeField]
    private float maxHP = 20;
    private float curHP;

    public float MaxHP => maxHP;
    public float CurHP => curHP;
    private void Awake()
    {
        curHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        curHP -= damage;

        StopCoroutine("HitAlphaAnimation");
        StartCoroutine("HitAlphaAnimation");

        if(curHP <= 0)
        {

        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        Color color = imageScreen.color;
        color.a = 0.4f;
        imageScreen.color = color;

        while(color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            imageScreen.color = color;

            yield return null;
        }
    }
}
