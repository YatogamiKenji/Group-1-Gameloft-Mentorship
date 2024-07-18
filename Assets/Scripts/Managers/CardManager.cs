using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    [SerializeField] private CardThemeSO cardTheme;
    [SerializeField] private Card cardPrefab;

    // Object pooling setup
    [SerializeField] private IObjectPool<Card> cardPool;
    [SerializeField] private bool collectionCheck = true; // Throw exception nếu thu về một object có sẵn trong pool
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxCapacity = 100;

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
        //DontDestroyOnLoad(this);

        // Card pool init
        cardPool = new ObjectPool<Card>(CreateCard, OnGetCard, OnReleaseCard, OnDestroyCard,
            collectionCheck, defaultCapacity, maxCapacity);
    }

    private Card CreateCard()
    {
        Card card = Instantiate(cardPrefab);
        return card;
    }

    private void OnGetCard(Card card)
    {
        card.gameObject.SetActive(true);
    }

    private void OnReleaseCard(Card card)
    {
        card.gameObject.SetActive(false);
    }

    private void OnDestroyCard(Card card)
    {
        Destroy(card);
    }

    public List<Card> CreateCardList(int w, int h)
    {
        // Chọn index ngẫu nhiên từ phần tử đầu đến cuối của 1 Theme SO
        List<int> randomSprites = new List<int>();

        int pairCount =  w * h / 2;
        while (randomSprites.Count < pairCount)
        {
            int random = Random.Range(0, cardTheme.matchImages.Count);
            if (!randomSprites.Contains(random))
            {
                randomSprites.Add(random);
            }
        }

        List<Card> cards = new List<Card>();
        int id = 0;
        for (int i = 0; i < pairCount; ++i)
        {
            for (int j = 0; j < 2; ++j)
            {
                Card card = cardPool.Get();
                card.gameObject.SetActive(true);
                card.id = id++;
                card.matchID = i; //Cặp thẻ giống nhau có cùng matchID
                card.bgImage = cardTheme.bgImage;
                card.bgImg.sprite = cardTheme.bgImage[1]; //Ban đầu thẻ lật
                card.matchImg.sprite = cardTheme.matchImages[randomSprites[i]]; //gán một pattern trong list đã chọn cho cặp thẻ
                card.isEnabled = true;
                card.isFlipped = true;
                cards.Add(card);
            }
        }

        return cards;
    }
}
