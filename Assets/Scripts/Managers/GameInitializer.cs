using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameInitializer : MonoBehaviour
{
    // SINGLETON
    public static GameInitializer Instance { get; private set; }

    public RectTransform cardField;
    public GridLayoutGroup cardLayout;

    private int numOfPair;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //SẮP XẾP THẺ LẬT
    public void CreateTable(int w , int h)
    {
        //Lấy list thẻ
        //List<Card> listCard = CardManager.Instance.CreateCardList(w, h);

        //Set số cột của cardLayout để sắp xếp thẻ
        cardLayout.constraintCount = w;
        //Set lại kích thước mỗi thẻ cho cân đối với kích thước màn hình
        cardLayout.cellSize = new Vector2((cardField.rect.width - 20 * w) / w, (cardField.rect.height - 30 * h) / h);

        //Tổng số cặp thẻ
        numOfPair = w * h / 2;

        //while (listCard.Count != 0)
        //{
        //    int index = Random.Range(0, listCard.Count);
        //    listCard[index].transform.SetParent(cardField);
        //    listCard.Remove(listCard[index]);
        //}
    }
}