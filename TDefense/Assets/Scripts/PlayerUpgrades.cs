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
    static int moneyGeneratedThisRound = 0;
    public static int MoneyGeneratedThisRound { get => moneyGeneratedThisRound; set => moneyGeneratedThisRound = value; }


    int upgradedDamage = 0;
    int upgradedHealth = 0;
    float upgradedFireRate = 0;
    float upgradedCritRate = 0;
    float upgradedCritDamage = 0;

    int costDamage = 0;
    int costHealth = 0;
    int costFireRate = 0;
    int costCritRate = 0;
    int costCritDamage = 0;

    readonly int damageMultiplier = 2;
    readonly int healthMultiplier = 5;
    readonly float fireRateMultiplier = 0.5f;
    readonly float critRateMultiplier = 0.5f;
    readonly float critDamageMultiplier = 1f;

    private void Start()
    {
        LoadUpgrades();
        moneyGeneratedThisRound = 0;
        ApplyUpgrades();
        CalculateAllCosts();
        RefreshAllTexts();
    }

    void RefreshAllTexts()
    {
        RefreshDamageTexts();
        RefreshHealthTexts();
        RefreshFireRateTexts();
        RefreshCritRateTexts();
        RefreshCritDamageTexts();
    }

    void RefreshDamageTexts()
    {
        buttonTexts[0].text = costDamage.ToString();
        valueTexts[0].text = "CURRENT DAMAGE: " + (playerFire.CurrentBulletDamage).ToString();
    }

    void RefreshHealthTexts()
    {
        buttonTexts[1].text = costHealth.ToString();
        valueTexts[1].text = "CURRENT HEALTH: " + (playerHealth.MaxHealthPoints).ToString();
    }

    void RefreshFireRateTexts()
    {
        buttonTexts[2].text = costFireRate.ToString();
        valueTexts[2].text = "CURRENT FIRE RATE: " + (playerFire.FireRate).ToString("#.0") + "/s";
    }

    void RefreshCritRateTexts()
    {
        buttonTexts[3].text = costCritRate.ToString();
        valueTexts[3].text = "CURRENT CRIT RATE: " + (playerFire.CritRate).ToString("#.0") + "%";
    }

    void RefreshCritDamageTexts()
    {
        buttonTexts[4].text = costCritDamage.ToString();
        valueTexts[4].text = "CURRENT CRIT DAMAGE: " + (playerFire.CritDamage).ToString() + "%";
    }

    public void UpgradeDamage()
    {
        if (money >= costDamage)
        {
            money -= costDamage;
            upgradedDamage++;
            CalculateCostDamage();
            ApplyUpgrades();
            RefreshDamageTexts();
        }
    }
    public void UpgradeHealth()
    {
        if (money >= costHealth)
        {
            money -= costHealth;
            upgradedHealth++;
            CalculateCostHealth();
            ApplyUpgrades();
            RefreshHealthTexts();
        }
    }
    public void UpgradeFireRate()
    {
        if (money >= costFireRate)
        {
            money -= costFireRate;
            upgradedFireRate++;
            CalculateCostFireRate();
            ApplyUpgrades();
            RefreshFireRateTexts();
        }
    }
    public void UpgradeCritRate()
    {
        if (money >= costCritRate)
        {
            money -= costCritRate;
            upgradedCritRate++;
            CalculateCostCritRate();
            ApplyUpgrades();
            RefreshCritRateTexts();
        }
    }
    public void UpgradeCritDamage()
    {
        if (money >= costCritDamage)
        {
            money -= costCritDamage;
            upgradedCritDamage++;
            CalculateCostCritDamage();
            ApplyUpgrades();
            RefreshCritDamageTexts();
        }
    }

    void CalculateCostDamage()
    {
        costDamage = Mathf.FloorToInt(10 * Mathf.Pow(1.07f, upgradedDamage) + upgradedDamage);
    }

    void CalculateCostHealth()
    {
        costHealth = Mathf.FloorToInt(10 * Mathf.Pow(1.1f, upgradedHealth) + upgradedHealth);
    }

    void CalculateCostFireRate()
    {
        costFireRate = Mathf.FloorToInt(10 * Mathf.Pow(1.1f, upgradedFireRate) + upgradedFireRate);
    }

    void CalculateCostCritRate()
    {
        costCritRate = Mathf.FloorToInt(15 * Mathf.Pow(1.15f, upgradedCritRate) + upgradedCritRate);
    }

    void CalculateCostCritDamage()
    {
        costCritDamage = Mathf.FloorToInt(20 * Mathf.Pow(1.15f, upgradedCritDamage) + upgradedCritDamage);
    }

    void CalculateAllCosts()
    {
        CalculateCostDamage();
        CalculateCostHealth();
        CalculateCostFireRate();
        CalculateCostCritRate();
        CalculateCostCritDamage();
    }

    public void AddMoneyFromWave()
    {
        money += moneyGeneratedThisRound;
    }

    void LoadUpgrades()
    {
        money = PlayerPrefs.GetInt("money", 0);
        upgradedDamage = PlayerPrefs.GetInt("upgradedDamage", 0);
        upgradedHealth = PlayerPrefs.GetInt("upgradedHealth", 0);
        upgradedFireRate = PlayerPrefs.GetFloat("upgradedFireRate", 0);
        upgradedCritRate = PlayerPrefs.GetFloat("upgradedCritRate", 0);
        upgradedCritDamage = PlayerPrefs.GetFloat("upgradedCritDamage", 0);
    }

    void SaveUpgrades()
    {
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("upgradedDamage", upgradedDamage);
        PlayerPrefs.SetInt("upgradedHealth", upgradedHealth);
        PlayerPrefs.SetFloat("upgradedFireRate", upgradedFireRate);
        PlayerPrefs.SetFloat("upgradedCritRate", upgradedCritRate);
        PlayerPrefs.SetFloat("upgradedCritDamage", upgradedCritDamage);
    }

    void ApplyUpgrades()
    {
        playerFire.CurrentBulletDamage = upgradedDamage * damageMultiplier + playerFire.BaseBulletDamage;
        playerHealth.MaxHealthPoints = upgradedHealth * healthMultiplier + playerHealth.BaseMaxHealthPoints;
        playerFire.FireRate = upgradedFireRate * fireRateMultiplier + playerFire.BaseFireRate;
        playerFire.CritRate = upgradedCritRate * critRateMultiplier + playerFire.BaseCritRate;
        playerFire.CritDamage = upgradedCritDamage * critDamageMultiplier + playerFire.BaseCritDamage;
        SaveUpgrades();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveUpgrades();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveUpgrades();
        }
    }

    private void OnApplicationQuit()
    {
        SaveUpgrades();
    }

}
