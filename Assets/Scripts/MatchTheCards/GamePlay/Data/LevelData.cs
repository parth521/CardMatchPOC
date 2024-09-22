using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
   public LevelDataInfo[] levelData;
}
[Serializable]
public class LevelDataInfo
{
    public int level;
    public int rows;
    public int columns;
} 