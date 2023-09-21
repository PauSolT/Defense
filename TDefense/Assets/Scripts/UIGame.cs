using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIGame : MonoBehaviour
{
    public PlayerUpgrades money;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI waveResult;
    public TextMeshProUGUI moneyGeneratedThisRoundText;

    public Image resultOption;
    public Sprite waveWonSprite;
    public Sprite waveLostSprite;

    public GameObject waveFinishedMenu;
    public GameObject skillsMenu;
    public GameObject closeSkillMenu;
    public GameObject settingsMenu;


    public void GoToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Gameplay");
    }

    public void RefreshLivesText(int lives)
    {
        livesText.text = lives.ToString();
    }


    public void FinishWave()
    {
        money.AddMoneyFromWave();
        waveFinishedMenu.SetActive(true);
        Time.timeScale = 0.0f;
        moneyGeneratedThisRoundText.text = PlayerUpgrades.MoneyGeneratedThisRound.ToString();
    }

    public void WaveWon()
    {
        FinishWave();
        waveResult.text = "WAVE WON";
        resultOption.sprite = waveWonSprite;
    }

    public void WaveLost()
    {
        FinishWave();
        waveResult.text = "WAVE LOST";
        resultOption.sprite = waveLostSprite;
    }

    public void OpenSkillsMenu()
    {
        RefreshMoneyText();
        waveFinishedMenu.SetActive(false);
        skillsMenu.SetActive(true);
        closeSkillMenu.SetActive(true);
    }

    public void RefreshMoneyText()
    {
        moneyText.text = money.Money.ToString();
    }

    public void CloseSkillsMenu()
    {
        waveFinishedMenu.SetActive(true);
        skillsMenu.SetActive(false);
        closeSkillMenu.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        Time.timeScale = 0.0f;
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
