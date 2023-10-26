using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDir = Vector3.zero;

    public float MoveSpeed => moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 dir)
    {
        moveDir = dir;
    }
}
