using System;
using UnityEngine;
public class GamePlayScreen : UIElement
{
    [SerializeField]private LevelActions levelActions;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameData gameData;
    public override void Show(Action callback = null)
    {
        base.Show(callback);
        
        levelActions.generateLevel?.Invoke(playerData.GetCurrentLevelData());
        levelActions.onLevelComplete += OnLevelComplete;
        levelActions.onProgressToNextLevel +=ProgressToNextLevel;

    }
    public override void Hide(Action callback = null)
    {
        base.Hide(callback);
        levelActions.onLevelComplete -= OnLevelComplete;
        levelActions.onProgressToNextLevel +=ProgressToNextLevel;
    }
    private void OnLevelComplete()
    {
        Debug.Log("OnLevelComplete");
        playerData.SetNextLevelData();
        UIManager.Instance.ShowScreen(UIScreen.LoadingScreen);
    }
    private void ProgressToNextLevel()
    {
        UIManager.Instance.HideScreen(UIScreen.GamePlayScreen);
        UIManager.Instance.ShowScreen(UIScreen.LoadingScreen);
    }

}
