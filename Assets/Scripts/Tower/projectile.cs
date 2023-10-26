using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private MoveMent moveMent;
    private Transform target;
    private int damage;

    public void SetUp(Transform target, int damage)
    {
        moveMent = GetComponent<MoveMent>();
        this.target = target;
        this.damage = damage;
    }

    void Update()
    {
        if(target != null)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            moveMent.MoveTo(dir);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        if (collision.transform != target) return;

        collision.GetComponent<EnemyHP>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
