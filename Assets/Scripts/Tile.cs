using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsBuildTower;

    private void Awake()
    {
        IsBuildTower = false;
    }
}
