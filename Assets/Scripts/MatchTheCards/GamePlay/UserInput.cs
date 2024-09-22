using UnityEngine;
using UnityEngine.EventSystems;
public class UserInput : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private UserInputAction userInputAction;
    [SerializeField]private GameData gameData;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(gameData.isInSelection) return;  
        Card card=eventData.pointerCurrentRaycast.gameObject?.GetComponent<Card>();
        if(card!=null)
        {
            userInputAction.OnCardClick(card);
        }
    }
}
