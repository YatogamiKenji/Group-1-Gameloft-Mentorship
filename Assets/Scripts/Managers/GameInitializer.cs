using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitializer : MonoBehaviour
{
    public RectTransform cardField;
    public GridLayoutGroup cardLayout;

    private int numOfPair;

    //SẮP XẾP THẺ LẬT
    public void CreateTable(int w = 4, int h = 4)
    {
        //Lấy list thẻ
        List<Card> listCard = CardManager.Instance.CreateCardList(w, h);

        //Set số cột của cardLayout để sắp xếp thẻ
        cardLayout.constraintCount = w;
        //Set lại kích thước mỗi thẻ cho cân đối với kích thước màn hình
        cardLayout.cellSize = new Vector2((cardField.rect.width - 20 * w) / w, (cardField.rect.height - 30 * h) / h);
        cardLayout.spacing = new Vector2((cardField.rect.width - w * cardLayout.cellSize.x) / w, (cardField.rect.height - h * cardLayout.cellSize.y) / h);

        //Tổng số cặp thẻ
        numOfPair = w * h / 2;


        while (listCard.Count != 0)
        {
            int index = Random.Range(0, listCard.Count);
            listCard[index].transform.SetParent(cardField);
            listCard.Remove(listCard[index]);
        }
    }

    private void Start()
    {
        CreateTable(4, 4);
    }
}