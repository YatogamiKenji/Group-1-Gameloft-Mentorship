using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : VoidEventListener
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI resultMessageText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject resultPanel;

    private void Start()
    {
        //Deactivate pausePanel và resultPanel
        pausePanel.SetActive(false);
        resultPanel.SetActive(false);

        //chạy ClosePausePanel khi bắt được event từ ResumeGameSO
        EventResponse.AddListener(ClosePausePanel);
    }

    private void ShowPausePanel()
    {

    }    

    private void ClosePausePanel()
    {
        pausePanel.SetActive(false);
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
