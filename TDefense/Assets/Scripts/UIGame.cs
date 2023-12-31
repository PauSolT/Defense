using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIGame : MonoBehaviour
{
    public PlayerUpgrades money;
    public SoundManager soundManager;

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
    public GameObject settingsImage;
    public GameObject pauseText;

    public GameObject mainMenu;
    public GameObject resetMenu;
    public GameObject resetButton;


    public void GoToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
        BgMusic.instance.GetComponent<AudioSource>().Stop();
    }

    public void RestartScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToGameplay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Gameplay");
        if (BgMusic.instance)
        {
            BgMusic.instance.GetComponent<AudioSource>().Play();
        }
    }


    public void RefreshLivesText(int lives)
    {
        if (livesText != null && !livesText.Equals(null))
        {
            livesText.text = lives.ToString();
        }
    }


    public void FinishWave()
    {
        money.AddMoneyFromWave();
        money.SaveMoney();
        settingsMenu.SetActive(false);
        settingsImage.SetActive(false);
        waveFinishedMenu.SetActive(true);
        Time.timeScale = 0.0f;
        moneyGeneratedThisRoundText.text = PlayerUpgrades.MoneyGeneratedThisRound.ToString();
    }

    public void WaveWon()
    {
        FinishWave();
        waveResult.text = "WAVE WON";
        resultOption.sprite = waveWonSprite;
        soundManager.audios[1].Play();
    }

    public void WaveLost()
    {
        FinishWave();
        waveResult.text = "WAVE LOST";
        resultOption.sprite = waveLostSprite;
        soundManager.audios[2].Play();
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
        pauseText.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
        pauseText.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OpenResetProgressMenu()
    {
        mainMenu.SetActive(false);
        resetButton.SetActive(false);
        resetMenu.SetActive(true);
    }

    public void CloseResetProgressMenu()
    {
        mainMenu.SetActive(true);
        resetButton.SetActive(true);
        resetMenu.SetActive(false);
    }


    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }
}
