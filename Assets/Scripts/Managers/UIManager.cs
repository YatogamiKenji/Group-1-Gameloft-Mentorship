using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

    //Show panel kết quả
    public void ShowResultPanel()
    {
        resultPanel?.SetActive(true);
    }

    //Đóng panel kết quả
    public void CloseResultPanel()
    {
        resultPanel.SetActive(false);
    }

    //Hiện tại chưa có menu hay settings
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
    }

    //Hiện kết quả thắng thua
    private void ShowResultMessage(string message)
    {

    }
}
