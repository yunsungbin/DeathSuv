using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTMP : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textplayerHP;
    [SerializeField]
    private TextMeshProUGUI textplayerHGold;
    [SerializeField]
    private PlayerHP playerHP;
    [SerializeField]
    private PlayerGold playerGold;

    void Update()
    {
        textplayerHP.text = playerHP.CurHP + "/" + playerHP.MaxHP;
        textplayerHGold.text = playerGold.CurGold.ToString();
    }
}
