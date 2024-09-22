
using System.Linq;
using UnityEngine;

public class CardSelection : MonoBehaviour
{
    [SerializeField] private UserInputAction userInput;
    [SerializeField] private GameData gameData;
    [SerializeField] private LevelActions levelActions;
    private void OnEnable()
    {
        userInput.OnCardClick += OnCardClick;
    }
    private void OnDisable()
    {
        userInput.OnCardClick -= OnCardClick;
    }
    private void OnCardClick(Card card)
    {

        card.FlipToshow(OnFlpComplete);
        gameData.selectedCards.Enqueue(card);
    }
    private void OnFlpComplete()
    {
        checkSelectedCards();
    }
    private void checkSelectedCards()
    {

        if (gameData.selectedCards.Count == 2)
        {
            gameData.isInSelection = true;
            Card card1 = gameData.selectedCards.Dequeue();
            Card card2 = gameData.selectedCards.Dequeue();
            if (card1.pairIndex == card2.pairIndex)
            {
                card1.Match(OnMatchComplete);
                card2.Match(OnMatchComplete);
                card1.isMatched = true;
                card2.isMatched = true;
            }
            else
            {
                //  Debug.LogError("Not Matched");
                card1.FlipToHide(OnFlipHideComplete);
                card2.FlipToHide(OnFlipHideComplete);
            }
        }
    }
    private void OnFlipHideComplete()
    {
        if (gameData.selectedCards.Count == 0)
        {
            gameData.isInSelection = false;
        }
    }
    private void OnMatchComplete()
    {
        if (gameData.selectedCards.Count == 0)
        {
            gameData.isInSelection = false;
            CheckRules();
        }

    }
    public bool levelComplete;
    private void CheckRules()
    {
        if (levelComplete) return;

         bool isLevelComplete = gameData.cards.All(card=>card.isMatched);

        if (isLevelComplete)
        {
            levelComplete = true;
            levelActions.onLevelComplete();
        }
       
    }
}
