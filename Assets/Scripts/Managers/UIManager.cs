using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private VoidPublisherSO resumeGameSO;
    [SerializeField] private VoidPublisherSO pauseGameSO;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI resultMessageText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject resultPanel;

    private void Start()
    {
        //Deactivate pausePanel và resultPanel
        pausePanel.SetActive(false);
        resultPanel.SetActive(false);
    }

    private void OnEnable()
    {
        resumeGameSO.OnEventRaised += ClosePausePanel;
        pauseGameSO.OnEventRaised += ShowPausePanel;
    }

    private void ShowPausePanel()
    {
        pausePanel?.SetActive(true);
    }    

    private void ClosePausePanel()
    {
        pausePanel?.SetActive(false);
    }

    private void ShowResultPanel()
    {

    }

    private void CloseResultPanel()
    {

    }

    private void UpdateTimerDisplay(float time)
    {

    }

    private void ShowResultMessage(string message)
    {

    }

    private void CloseOptionMenu()
    {

    }

    private void ShowOptionMenu()
    {

    }
}
