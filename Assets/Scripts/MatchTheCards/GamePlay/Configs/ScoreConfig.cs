using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Config/ScorConfig", order = 1)]
public class ScoreConfig : ScriptableObject
{
    [SerializeField]private GameData gameData;
    [SerializeField]private float multiplier = 1.5f;
    [SerializeField]private int fullPoints = 100;
    [SerializeField]private int reducedPoints = 50;
    public int CalculateThreshold()
    {
        return Mathf.FloorToInt((gameData.cards.Count / 2) * multiplier);
    }
    public int CalculatePoints(int moves)
    {
        int threshold = CalculateThreshold();
        return moves <= threshold ? fullPoints : reducedPoints;
    }
}
