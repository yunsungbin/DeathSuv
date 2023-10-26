using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    [SerializeField]
    private int curGold = 100;
    
    public int CurGold
    {
        set => curGold = Mathf.Max(0, value);
        get => curGold;
    }
}
