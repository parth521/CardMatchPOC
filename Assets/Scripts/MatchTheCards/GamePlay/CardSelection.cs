using UnityEngine;

public class CardSelection : MonoBehaviour
{
    [SerializeField] private UserInputAction userInput;

    private void OnEnable() {
        userInput.OnCardClick += OnCardClick;    
    }
    private void OnDisable() {
        userInput.OnCardClick -= OnCardClick;    
    }
    private void OnCardClick(Card card) {
        card.FlipToshow();
    }
}
