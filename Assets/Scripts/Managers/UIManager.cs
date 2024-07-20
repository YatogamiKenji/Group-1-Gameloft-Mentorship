using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private VoidPublisherSO gameOverSO;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI resultMessageText;
    [SerializeField] private TextMeshProUGUI timeRemainText;

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

        SetTotalTime(60f);
    }

    private void Update()
    {
        UpdateTimerDisplay();
    }

    //Show panel dừng màn hình
    public void ShowPausePanel()
    {
        pausePanel?.SetActive(true);
    }

    //Close panel dừng màn hình
    public void ClosePausePanel()
    {
        pausePanel?.SetActive(false);
    }

    //Show panel GameOver
    public void ShowGameOverResultPanel()
    {
        resultMessageText.text = "Game Over";
        timeRemainText.text = time.ToString();
        resultPanel?.SetActive(true);
    }

    //Show panel kết quả You win
    public void ShowYouWinResultPanel()
    {
        resultMessageText.text = "You win";
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        timeRemainText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        resultPanel?.SetActive(true);
    }

    //Đóng panel kết quả
    public void CloseResultPanel()
    {
        resultPanel.SetActive(false);
    }

    public void CloseOptionMenu()
    {
        
    }

    public void ShowOptionMenu()
    {

    }

    //Set total time từ khi bắt đầu game để chạy timer
    private void SetTotalTime(float totalTime)
    {
        this.totalTime = totalTime;
        time = totalTime;
    }

    //Đếm ngược thời gian sau khi set total time
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
        else
        {
            time = 0;
            gameOverSO.RaiseEvent();
        }
    }

}
