using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private RectTransform cardField;
    [SerializeField] private GridLayoutGroup cardLayout;
    [SerializeField] private Vector2 spacing;

    private int numOfPair;

    [SerializeField] private static int w;
    [SerializeField] private static int h;
  
    //SẮP XẾP THẺ LẬT
    public void CreateTable(int w, int h)
    {
        //Lấy list thẻ
        List<Card> listCard = CardManager.Instance.CreateCardList(w, h);

        //Set số cột của cardLayout để sắp xếp thẻ
        cardLayout.constraintCount = w;
        //Set lại kích thước mỗi thẻ cho cân đối với kích thước màn hình
        cardLayout.cellSize = new Vector2((cardField.rect.width - spacing.x * w) / w, (cardField.rect.height - spacing.y * h) / h);
        cardLayout.spacing = new Vector2((cardField.rect.width - w * cardLayout.cellSize.x) / w, (cardField.rect.height - h * cardLayout.cellSize.y) / h);

        //Tổng số cặp thẻ
        numOfPair = w * h / 2;


        while (listCard.Count != 0)
        {
            int index = Random.Range(0, listCard.Count);
            listCard[index].transform.SetParent(cardField);
            listCard.Remove(listCard[index]);
        }
        CardManager.Instance.StartCoroutineFLipBack();
    }

    private void Start()
    {
        //CreateTable(4, 4);
    }
    
    public GameInitializer Instance;  
    private void Awake()
    {
        // Singleton init
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }
}