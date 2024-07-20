using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private VoidPublisherSO winGameSO;

    [SerializeField] private RectTransform cardField;
    [SerializeField] private GridLayoutGroup cardLayout;
    

    [SerializeField] private Vector2 spacing;

    private int numOfCard;

    [SerializeField] private SizeConfigSO SizeConfig;
    [SerializeField] private ThemeConfigSO ThemeConfig;
  
    //SẮP XẾP THẺ LẬT
    public void CreateTable(int w, int h)
    {
        

        //Set số cột của cardLayout để sắp xếp thẻ
        cardLayout.constraintCount = w;
        //Set lại kích thước mỗi thẻ cho cân đối với kích thước màn hình
        cardLayout.cellSize = new Vector2((cardField.rect.width - spacing.x * w) / w, (cardField.rect.height - spacing.y * h) / h);
        cardLayout.spacing = new Vector2((cardField.rect.width - w * cardLayout.cellSize.x) / w, (cardField.rect.height - h * cardLayout.cellSize.y) / h);

        //Tổng số card
        numOfCard = w * h;

        Debug.Log("NumofPair" + numOfCard);

        //Lấy list thẻ
        List<Card> listCard = CardManager.Instance.CreateCardList(w, h);

        while (listCard.Count != 0)
        {
            int index = Random.Range(0, listCard.Count);
            listCard[index].transform.SetParent(cardField);
            listCard.Remove(listCard[index]);
        }
        CardManager.Instance.StartCoroutineFLipBack();
    }

    [SerializeField] private GameInitPublisherSO loadedEventSO;

    private void Start()
    {
        //Bắt sự kiện khi nhấn nút
        StartGame();
        
    }

    public void StartGame()
    {
        loadedEventSO.RaiseThemeEvent(ThemeConfig.GetCurrentTheme());
        loadedEventSO.RaiseSizeEvent(SizeConfig.crnW, SizeConfig.crnH);
    }    

    private void Update()
    {
        if ( CheckWin())
        {
            winGameSO.RaiseEvent();
        }
    }

    private static GameInitializer instance;
    public static GameInitializer Instance { get => instance; }
    private void Awake()
    {
        // Singleton init
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;

        }
        
    }
    public bool CheckWin()
    {
        return (numOfCard == 0);
    }

    public void CheckMatch()
    {
        numOfCard--;
    }
}