using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIGame : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI waveResult;
    public TextMeshProUGUI resultOption;
    public TextMeshProUGUI moneyGeneratedThisRoundText;
    public GameObject waveFinishedMenu;
    public GameObject skillsMenu;
    public GameObject closeSkillMenu;


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
        livesText.text = "LIVES: " + lives.ToString();
    }


    public void FinishWave()
    {
        waveFinishedMenu.SetActive(true);
        Time.timeScale = 0.0f;
        moneyGeneratedThisRoundText.text = "MONEY EARNED: " + PlayerUpgrades.moneyGeneratedThisRound.ToString();
    }

    public void WaveWon()
    {
        FinishWave();
        waveResult.text = "WAVE WON";
        resultOption.text = "NEXT";
    }

    public void WaveLost()
    {
        FinishWave();
        waveResult.text = "WAVE LOST";
        resultOption.text = "RESTART";
    }

    public void OpenSkillsMenu()
    {
        waveFinishedMenu.SetActive(false);
        skillsMenu.SetActive(true);
        closeSkillMenu.SetActive(true);
    }

    public void CloseSkillsMenu()
    {
        waveFinishedMenu.SetActive(true);
        skillsMenu.SetActive(false);
        closeSkillMenu.SetActive(false);
    }

}