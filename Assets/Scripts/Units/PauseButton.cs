using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private VoidPublisherSO pauseGameSO;
    [SerializeField] private VoidPublisherSO resumeGameSO;

    //Hình ảnh để chuyển đổi giữa nút pause với resume
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite resumeSprite;

    private Image buttonImage;
    private bool isPaused = false;

    private void Awake()
    {
        //Bắt sự kiện khi nhấn nút
        gameObject.GetComponent<Button>().onClick.AddListener(OnPauseButtonClick);

        buttonImage = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        //Sprite mặc định của pauseButton là pauseSprite
        buttonImage.sprite = pauseSprite;
    }

    private void OnPauseButtonClick()
    {
        if (!isPaused)
        {
            //Nếu game chưa dừng thì dừng game và chuyển sprite thành nút resume
            Time.timeScale = 0;
            isPaused = true;
            pauseGameSO.RaiseEvent();
            buttonImage.sprite = resumeSprite;
        }
        else
        {
            //Nếu game đang dừng thì tiếp tục và chuyển thành nút pause
            Time.timeScale = 1;
            isPaused = false;
            resumeGameSO.RaiseEvent();
            buttonImage.sprite = pauseSprite;
        }
    }

    //PauseButton bắt sự kiện resume game để chuyển lại thành nút pause
    public void OnResumeGame()
    {
        isPaused = false;
        buttonImage.sprite = pauseSprite;
    }
}
