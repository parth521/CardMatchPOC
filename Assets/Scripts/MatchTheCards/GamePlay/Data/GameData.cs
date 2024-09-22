using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Gamedata", order = 1)]
public class GameData : ScriptableObject
{
    public List<Card> cards= new List<Card>();
    public bool isInSelection;
    public Queue<Card> selectedCards = new Queue<Card>(2);
    public void Initialize(){
        
        cards.Clear();
        selectedCards.Clear();
        isInSelection = false;
    }
}
