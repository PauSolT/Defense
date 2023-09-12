using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUpgrades : MonoBehaviour
{
    public Player player;
    public HealthComponent playerHealth;
    public FireBullets playerFire;

    public List<TextMeshProUGUI> buttonTexts;
    public List<TextMeshProUGUI> valueTexts;

    [SerializeField]
    int money = 0;
    public int Money { get => money; set => money = value; }


    int upgradedDamage = 0;
    int upgradedHealth = 0;
    int upgradedFireRate = 0;
    int upgradedCritRate = 0;
    int upgradedCritDamage = 0;

    int costDamage = 0;
    int costHealth = 0;
    int costFireRate = 0;
    int costCritRate = 0;
    int costCritDamage = 0;

    private void Start()
    {
        ApplyUpgrades();
        CalculateAllCosts();
        RefreshDamageTexts();
    }

    void RefreshDamageTexts()
    {
        buttonTexts[0].text = costDamage.ToString();
        valueTexts[0].text = "Current Damage: " + (upgradedDamage + playerFire.BaseBulletDamage).ToString();
    }

    public void UpgradeDamage()
    {
        if (money >= costDamage)
        {
            CalculateCostDamage();
            upgradedDamage++;
            RefreshDamageTexts();
        ApplyUpgrades();

        }
    }
    void UpgradeHealth()
    {
        CalculateCostDamage();
        if (money >= costHealth)
        {
            upgradedHealth++;
        }
    }
    void UpgradeFireRate()
    {
        CalculateCostDamage();
        if (money >= costFireRate)
        {
            upgradedFireRate++;
        }
    }
    void UpgradeCritRate()
    {
        CalculateCostDamage();
        if (money >= costCritRate)
        {
            upgradedCritRate++;
        }
    }
    void UpgradeCritDamage()
    {
        CalculateCostCritDamage();
        if (money >= costCritDamage)
        {
            upgradedCritDamage++;
        }
    }

    void CalculateCostDamage()
    {
        costDamage = Mathf.FloorToInt(5 * Mathf.Pow(1.05f, upgradedDamage));
    }

    void CalculateCostHealth()
    {
        costHealth = Mathf.FloorToInt(5 * Mathf.Pow(1.05f, upgradedHealth));
    }

    void CalculateCostFireRate()
    {
        costFireRate = Mathf.FloorToInt(10 * Mathf.Pow(1.07f, upgradedFireRate));
    }

    void CalculateCostCritRate()
    {
        costCritRate = Mathf.FloorToInt(15 * Mathf.Pow(1.10f, upgradedCritRate));
    }

    void CalculateCostCritDamage()
    {
        costCritDamage = Mathf.FloorToInt(20 * Mathf.Pow(1.15f, upgradedCritDamage));
    }

    void CalculateAllCosts()
    {
        CalculateCostDamage();
        CalculateCostHealth();
        CalculateCostFireRate();
        CalculateCostCritRate();
        CalculateCostCritDamage();
    }



    void LoadUpgrades()
    {
        upgradedDamage = PlayerPrefs.GetInt("upgradedDamage", 0);
        upgradedHealth = PlayerPrefs.GetInt("upgradedHealth", 0);
        upgradedFireRate = PlayerPrefs.GetInt("upgradedFireRate", 0);
        upgradedCritRate = PlayerPrefs.GetInt("upgradedCritRate", 0);
        upgradedCritDamage = PlayerPrefs.GetInt("upgradedCritDamage", 0);
    }

    void SaveUpgrades()
    {
        PlayerPrefs.SetInt("upgradedDamage", upgradedDamage);
        PlayerPrefs.SetInt("upgradedHealth", upgradedHealth);
        PlayerPrefs.SetInt("upgradedFireRate", upgradedFireRate);
        PlayerPrefs.SetInt("upgradedCritRate", upgradedCritRate);
        PlayerPrefs.SetInt("upgradedCritDamage", upgradedCritDamage);
    }

    void ApplyUpgrades()
    {
        playerFire.CurrentBulletDamage = upgradedDamage + playerFire.BaseBulletDamage;
    }

}
