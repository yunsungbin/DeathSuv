using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 20.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;

    public void SetUp(Transform target)
    {
        targetTransform = target;
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if(targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(targetTransform.position);

        rectTransform.position = screenPos + distance;
    }
}
