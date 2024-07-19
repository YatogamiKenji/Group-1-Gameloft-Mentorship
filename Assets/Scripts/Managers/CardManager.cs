using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    // Card stuff
    [SerializeField] private CardThemeSO cardTheme;
    [SerializeField] private Card cardPrefab;
    [HideInInspector] private List<Card> upCards;

    // Object pooling setup
    [SerializeField] private IObjectPool<Card> cardPool;
    [SerializeField] private bool collectionCheck = true; // Throw exception nếu thu về một object có sẵn trong pool
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxCapacity = 100;

    [SerializeField] private float showCardTime; // Thời gian show card nếu match sai, hết thời gian card sẽ úp lại
    private bool isInteractable = false;

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

        upCards = new List<Card>();
    }

    public void SetTheme(CardThemeSO theme)
    {
        Debug.Log("Setting theme..." + theme.Name);
        cardTheme = theme;
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
        Debug.Log(cardTheme.Name);
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
                card.isFlippedBack = false;
                cards.Add(card);
                upCards.Add(card);
            }
        }
        return cards;
    }

    public void LogCard(Card card)
    {
        Debug.Log(card.id);
    }

    public void FlipCard(Card card)
    {
        if (!isInteractable)
            return;

        card.Flip();

        if (card.isFlippedBack)
        {
            upCards.Remove(card);
        }
        else
        {
            upCards.Add(card);
        }

        if (upCards.Count == 2)
        {
            if (upCards[0].matchID == upCards[1].matchID)
            {
                upCards[0].CheckMatch();
                upCards[1].CheckMatch();
                upCards.Clear();
            }
            else
            {
                isInteractable = false;
                StartCoroutineFLipBack();
            }
        }
    }

    // đếm ngược thời gian show card trước khi úp
    public void StartCoroutineFLipBack()
    {
        StartCoroutine("CountFlipCardBack");
    }

    private IEnumerator CountFlipCardBack()
    {
        isInteractable = false;
        float elapsedTime = showCardTime;
        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            yield return null;
        }
        foreach (Card card in upCards)
        {
            card.Flip();
        }

        upCards.Clear();
        isInteractable = true;
    }
}
