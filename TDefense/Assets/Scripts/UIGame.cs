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
    }

    public void WaveWon()
    {
        waveFinishedMenu.SetActive(true);
        waveResult.text = "WAVE WON";
        resultOption.text = "NEXT";
    }

    public void WaveLost()
    {
        waveFinishedMenu.SetActive(true);
        waveResult.text = "WAVE LOST";
        resultOption.text = "RESTART";
    }

}
