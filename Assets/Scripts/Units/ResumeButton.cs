using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private VoidPublisherSO resumeGameSO;

    private void Awake()
    {
        //Bắt sự kiện khi nhấn nút
        gameObject.GetComponent<Button>().onClick.AddListener(OnResumeButtonClick);
    }

    private void OnResumeButtonClick()
    {
        Time.timeScale = 1;
        resumeGameSO.RaiseEvent();
    }
}
