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
    [SerializeField] private Image timeSlider;

    //Totaltime của game được set để chạy trong update 
    private float totalTime;
    private float time;

    private void Start()
    {
        pausePanel.SetActive(false);
        resultPanel.SetActive(false);
    }

    private void Update()
    {
        UpdateTimerDisplay();
    }

    private void OnEnable()
    {
        resumeGameSO.OnEventRaised += ClosePausePanel;
        pauseGameSO.OnEventRaised += ShowPausePanel;
    }

    private void OnDisable()
    {
        resumeGameSO.OnEventRaised -= ClosePausePanel;
        pauseGameSO.OnEventRaised -= ShowPausePanel;
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

    private void CloseOptionMenu()
    {

    }

    private void ShowOptionMenu()
    {

    }

    //Set total time từ khi bắt đầu game để chạy timer
    private void SetTotalTime(float totalTime)
    {
        this.totalTime = totalTime;
        time = totalTime;
    }

    private void UpdateTimerDisplay()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            int minutes = (int)(time / 60);
            int seconds = (int)(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            timeSlider.fillAmount = time / totalTime;
        }
    }

    private void ShowResultMessage(string message)
    {

    }
}
