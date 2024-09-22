using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Gamedata", order = 1)]
public class GameData : ScriptableObject
{
    public List<Card> cards= new List<Card>();
}
