using UnityEngine;
using UnityEngine.EventSystems;
public class UserInput : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private UserInputAction userInputAction;
    public void OnPointerClick(PointerEventData eventData)
    {
        Card card=eventData.pointerCurrentRaycast.gameObject?.GetComponent<Card>();
        if(card!=null)
        {
            userInputAction.OnCardClick(card);
        }
    }
}
