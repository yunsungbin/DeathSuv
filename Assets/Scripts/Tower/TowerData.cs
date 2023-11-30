using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerData : MonoBehaviour
{
    [SerializeField]
    private Image imageTower;
    [SerializeField]
    private TextMeshProUGUI textDamage;
    [SerializeField]
    private TextMeshProUGUI textRate;
    [SerializeField]
    private TextMeshProUGUI textRange;
    [SerializeField]
    private TextMeshProUGUI textLevel;
    [SerializeField]
    private TextMeshProUGUI textUpgradeCost;
    [SerializeField]
    private TextMeshProUGUI textSellCost;
    [SerializeField]
    private TowerAttackRange towerAttackRange;
    [SerializeField]
    private Button buttonUpgrade;
    [SerializeField]
    private SystemTextView systemTextView;

    private TowerWeapon curTower;
    public void Awake()
    {
        OffPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffPanel();
        }
    }

    public void OnPanel(Transform towerWeapon)
    {
        curTower = towerWeapon.GetComponent<TowerWeapon>();

        gameObject.SetActive(true);

        UpdateTowerData();

        towerAttackRange.OnAttackRange(curTower.transform.position, curTower.Range);
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);

        towerAttackRange.OffAttackRange();
    }

    private void UpdateTowerData()
    {
        if(curTower.WeaponType == WeaponType.Cannon || curTower.WeaponType == WeaponType.Laser)
        {
            imageTower.rectTransform.sizeDelta = new Vector2(88, 59);
            textDamage.text = "Damage : " + curTower.Damage + "+" + "<color=red>" + curTower.AddedDamage.ToString("F1") + "</color>";
        }
        else
        {
            imageTower.rectTransform.sizeDelta = new Vector2(59, 59);
            if (curTower.WeaponType == WeaponType.Slow)
            {
                textDamage.text = "Slow : " + curTower.Slow * 100 + "%";
            }
            else if (curTower.WeaponType == WeaponType.Buff)
            {
                textDamage.text = "Buff : " + curTower.Buff * 100 + "%";
            }
        }

        imageTower.sprite = curTower.TowerSprite;
        textRate.text = "Rate : " + curTower.Rate;
        textRange.text = "Range : " + curTower.Range;
        textLevel.text = "Level : " + curTower.Level;
        textUpgradeCost.text = curTower.UpgradeCost.ToString();
        textSellCost.text = curTower.SellCost.ToString();

        buttonUpgrade.interactable = curTower.Level < curTower.MaxLevel ? true : false;
    }

    public void OnClickEventTowerUpgrade()
    {
        bool isSucces = curTower.Upgrade();

        if(isSucces == true)
        {
            UpdateTowerData();

            towerAttackRange.OnAttackRange(curTower.transform.position, curTower.Range);
        }
        else
        {
            systemTextView.PrintText(SystemType.Money);
        }
    }

    public void OnClickEventTowerSell()
    {
        curTower.Sell();
        OffPanel();
    }
}
