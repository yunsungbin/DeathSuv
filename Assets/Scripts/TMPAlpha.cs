using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPAlpha : MonoBehaviour
{
    [SerializeField]
    private float lerpTime = 0.5f;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void FadeOut()
    {
        StartCoroutine(AlphaLerp(1, 0));
    }

    IEnumerator AlphaLerp(float start, float end)
    {
        float curTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            curTime += Time.deltaTime;
            percent = curTime / lerpTime;

            Color color = text.color;
            color.a = Mathf.Lerp(start, end, percent);
            text.color = color;

            yield return null;
        }
    }
}
