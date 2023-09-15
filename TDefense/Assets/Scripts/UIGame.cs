using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIGame : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI waveResult;
    public TextMeshProUGUI resultOption;
    public GameObject waveFinishedMenu;
    public GameObject skillsMenu;
    public GameObject closeSkillMenu;


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Gameplay");
    }


    public void FinishWave()
    {
        waveFinishedMenu.SetActive(true);
        Time.timeScale = 0.0f;
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
