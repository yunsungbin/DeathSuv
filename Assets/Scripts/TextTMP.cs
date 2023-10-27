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
    private TextMeshProUGUI textWave;
    [SerializeField]
    private TextMeshProUGUI textEnemyCount;
    [SerializeField]
    private PlayerHP playerHP;
    [SerializeField]
    private PlayerGold playerGold;
    [SerializeField]
    private WaveSystem waveSystem;
    [SerializeField]
    private EnemySpawner enemySpawner;

    void Update()
    {
        textplayerHP.text = playerHP.CurHP + "/" + playerHP.MaxHP;
        textplayerHGold.text = playerGold.CurGold.ToString();
        textWave.text = waveSystem.CurWave + "/" + waveSystem.MaxWave;
        textEnemyCount.text = enemySpawner.CurEnemyCount + "/" + enemySpawner.MaxEnemyCount;
    }
}
