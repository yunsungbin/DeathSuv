using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowPos : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        transform.position = mainCamera.ScreenToWorldPoint(pos);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
