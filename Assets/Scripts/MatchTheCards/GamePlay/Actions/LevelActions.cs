using UnityEngine;
using System; 
[CreateAssetMenu(fileName = "Actions", menuName = "Actions/LevelActions", order = 1)]
public class LevelActions : ScriptableObject
{
public Action<int> generateLevel;
}
