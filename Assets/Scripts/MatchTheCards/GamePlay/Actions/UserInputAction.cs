using UnityEngine;

[CreateAssetMenu(fileName = "Actions", menuName = "Actions/UserInputAction", order = 1)]
public class UserInputAction : ScriptableObject
{
  public System.Action<Card> OnCardClick;
}
