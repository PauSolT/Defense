using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerUpgrades : MonoBehaviour
{
    public Player player;
    public HealthComponent playerHealth;
    public FireBullets playerFire;

    public List<TextMeshProUGUI> buttonTexts;
    public List<TextMeshProUGUI> valueTexts;

    public GameObject adButton;
    public GameObject adText;
    public GameObject adResultText;

    [SerializeField]
    double money = 0;
    public double Money { get => money; set => money = value; }
    static double moneyGeneratedThisRound = 0;
    public static double MoneyGeneratedThisRound { get => moneyGeneratedThisRound; set => moneyGeneratedThisRound = value; }


    int upgradedDamage = 0;
    int upgradedHealth = 0;
    float upgradedFireRate = 0;
    float upgradedCritRate = 0;
    float upgradedCritDamage = 0;

    double costDamage = 0;
    double costHealth = 0;
    double costFireRate = 0;
    double costCritRate = 0;
    double costCritDamage = 0;

    readonly int damageMultiplier = 1;
    readonly int healthMultiplier = 1;
    readonly float fireRateMultiplier = 0.1f;
    readonly float critRateMultiplier = 0.25f;
    readonly float critDamageMultiplier = 0.5f;

    public bool adWatched = false;

    private void Start()
    {
        adWatched = false;
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
        valueTexts[0].text = "CURRENT: " + (playerFire.CurrentBulletDamage).ToString();
    }

    void RefreshHealthTexts()
    {
        buttonTexts[1].text = costHealth.ToString();
        valueTexts[1].text = "CURRENT: " + (playerHealth.MaxHealthPoints).ToString();
    }

    void RefreshFireRateTexts()
    {
        buttonTexts[2].text = costFireRate.ToString();
        valueTexts[2].text = "CURRENT: " + (playerFire.FireRate).ToString("0.0") + "/s";
    }

    void RefreshCritRateTexts()
    {
        buttonTexts[3].text = costCritRate.ToString();
        valueTexts[3].text = "CURRENT: " + (playerFire.CritRate).ToString("0.0") + "%";

        if(playerFire.CritRate >= 100)
        {
            buttonTexts[3].text = "MAX";
            buttonTexts[3].transform.parent.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
    }

    void RefreshCritDamageTexts()
    {
        buttonTexts[4].text = costCritDamage.ToString();
        valueTexts[4].text = "CURRENT: " + (playerFire.CritDamage).ToString() + "%";
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
        costDamage = Mathf.Round(10 * Mathf.Pow(1.03f, upgradedDamage) + upgradedDamage);
    }

    void CalculateCostHealth()
    {
        costHealth = Mathf.Round(10 * Mathf.Pow(1.05f, upgradedHealth) + upgradedHealth);
    }

    void CalculateCostFireRate()
    {
        costFireRate = Mathf.Round(10 * Mathf.Pow(1.05f, upgradedFireRate) + upgradedFireRate);
    }

    void CalculateCostCritRate()
    {
        costCritRate = Mathf.Round(15 * Mathf.Pow(1.07f, upgradedCritRate) + upgradedCritRate);
    }

    void CalculateCostCritDamage()
    {
        costCritDamage = Mathf.Round(20 * Mathf.Pow(1.1f, upgradedCritDamage) + upgradedCritDamage);
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
        money = Convert.ToDouble(PlayerPrefs.GetString("money", "0"));
        upgradedDamage = PlayerPrefs.GetInt("upgradedDamage", 0);
        upgradedHealth = PlayerPrefs.GetInt("upgradedHealth", 0);
        upgradedFireRate = PlayerPrefs.GetFloat("upgradedFireRate", 0);
        upgradedCritRate = PlayerPrefs.GetFloat("upgradedCritRate", 0);
        upgradedCritDamage = PlayerPrefs.GetFloat("upgradedCritDamage", 0);
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetString("money", money.ToString());
    }

    void SaveUpgrades()
    {
        PlayerPrefs.SetString("money", money.ToString()); ;
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

    public void AdWatched()
    {
        adButton.SetActive(false);
        adText.SetActive(false);
        adResultText.SetActive(true);
        adResultText.GetComponent<TMPro.TextMeshProUGUI>().text = "MONEY EARNED: " + MoneyGeneratedThisRound;
    }

}
