using UnityEngine;

public class CardPooler : Singleton<CardPooler>
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private int poolSize;
    private ObjectPooler<Card> cardPool;

    private void Awake()
    {
        Application.targetFrameRate = 90;
    }
    public void Initialize(Transform parent)
    {
        if(cardPool!=null) return;
        cardPool = new ObjectPooler<Card>(cardPrefab, poolSize, parent);
    }
    public void UnInitialize()
    {
        cardPool = null;
    }
    public Card GetCard()
    {
        return cardPool.GetObject();
    }
    public void ReturnCard(Card card)
    {
        cardPool.ReturnObject(card);
    }
}