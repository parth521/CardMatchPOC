using System;
using UnityEngine;
using TMPro;
public class GamePlayScreen : UIElement
{
    [SerializeField]private LevelActions levelActions;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameData gameData;
    [SerializeField] private TextMeshProUGUI scoretxt;
    public override void Show(Action callback = null)
    {
        base.Show(callback);
        levelActions.dispalyTilesOnLevelStart += ShowTiles;
        levelActions.onLevelComplete += OnLevelComplete;
        levelActions.displayScore+=OnDisplayScore;
        levelActions.generateLevel?.Invoke(playerData.GetCurrentLevelData());
        ShowTiles(); 
    }
    public override void Hide(Action callback = null)
    {
        base.Hide(callback);
        levelActions.onLevelComplete -= OnLevelComplete;
        levelActions.dispalyTilesOnLevelStart -= ShowTiles;
         levelActions.displayScore-=OnDisplayScore;
    }
    private void OnLevelComplete()
    {
        playerData.SetNextLevelData();
        UIManager.Instance.ShowScreen(UIScreen.ScoreCalculatorScreen);
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
   private void OnDisplayScore(int score)
   {
        scoretxt.text= score.ToString();
   }

}
