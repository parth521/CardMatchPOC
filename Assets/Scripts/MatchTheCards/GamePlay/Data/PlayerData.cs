using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Data", menuName = "Data/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public int currentLevelData=0;
    public int playerScore;
     private string dataFileName = "playerdata.json";
    private PlayerDatainfo playerDatainfo;
    public LevelActions levelActions;
    public int GetCurrentLevelData()
    {
        playerDatainfo = new PlayerDatainfo(); 
        LoadGameData();
        if(playerDatainfo==null)
        {
            playerDatainfo.currentLevelData = 0;
            playerDatainfo.playerScore = 0;
        }
        playerScore= playerDatainfo.playerScore;
        currentLevelData = playerDatainfo.currentLevelData;
        levelActions.displayScore?.Invoke(playerScore);
        return currentLevelData;
    }
    public void SetNextLevelData()
    {
        currentLevelData++;
        playerDatainfo = new PlayerDatainfo();
        playerDatainfo.currentLevelData = currentLevelData;
    }
    public void SerPlayerData(int score)
    {
        playerScore += score;
        playerDatainfo.playerScore = playerScore;
        SavePlayerData();
    }
    private void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerDatainfo);
        string filePath = Path.Combine(Application.persistentDataPath, dataFileName);
        File.WriteAllText(filePath, json);
    }
    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, dataFileName);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerDatainfo = JsonUtility.FromJson<PlayerDatainfo>(json);
        }
        else
        {
            Debug.LogWarning("Save file not found: " + filePath);
        }
    }
   
}
[System.Serializable]
public class PlayerDatainfo
{
    public int currentLevelData;
    public int playerScore;
}