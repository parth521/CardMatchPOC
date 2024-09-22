using System;
using System.Collections;
using UnityEngine;
public class GamePlayScreen : UIElement
{
    [SerializeField]private LevelActions levelActions;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameData gameData;
    public override void Show(Action callback = null)
    {
        base.Show(callback);
        levelActions.dispalyTilesOnLevelStart += ShowTiles;
        levelActions.onLevelComplete += OnLevelComplete;
        levelActions.generateLevel?.Invoke(playerData.GetCurrentLevelData());
        ShowTiles(); 
    }
    public override void Hide(Action callback = null)
    {
        base.Hide(callback);
        levelActions.onLevelComplete -= OnLevelComplete;
         levelActions.dispalyTilesOnLevelStart -= ShowTiles;
    }
    private void OnLevelComplete()
    {
        playerData.SetNextLevelData();
        levelActions.CalculateScore?.Invoke();
      //  UIManager.Instance.ShowScreen(UIScreen.LoadingScreen);
    }
    private void ShowTiles()
   {
        gameData.isInSelection= true;
        gameData.cards.ForEach(card=>card.FlipToshow(OnFlipComplete));
   }
   private void OnFlipComplete()
   {
       Invoke("OnFlipHide",.65f);
   }
   private void OnFlipHide()
   {
       gameData.cards.ForEach(card=>card.FlipToHide(OnFlipHideComplete));
       CancelInvoke("OnFlipHide");
   }
   private void OnFlipHideComplete()
   {
       gameData.isInSelection = false;
   }
}
