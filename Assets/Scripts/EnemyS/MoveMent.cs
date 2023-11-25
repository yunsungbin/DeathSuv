using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDir = Vector3.zero;
    private float baseMoveSpeed;

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }

    private void Awake()
    {
        baseMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 dir)
    {
        moveDir = dir;
    }

    public void ResetMoveSpeed()
    {
        moveSpeed = baseMoveSpeed;
    }
}
