using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public int currentLevelData=0;
    public LevelActions levelActions;
    public int GetCurrentLevelData()
    {

        //currentLevelData = PlayerPrefs.GetInt("CurrentLevel");
        // return currentLevelData;
        return currentLevelData;
    }
    public void SetNextLevelData()
    {
        currentLevelData++;
       // PlayerPrefs.SetInt("CurrentLevel", currentLevelData); // this is poc so using playerprefs other wise we can use json. 
       // levelActions.generateLevel?.Invoke(currentLevelData);
    }
   
}
