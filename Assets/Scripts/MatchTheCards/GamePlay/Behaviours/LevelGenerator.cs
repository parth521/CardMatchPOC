using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class LevelGenerator : MonoBehaviour
{
   [SerializeField]private LevelActions levelActions;
   [SerializeField]private LevelData levelData;
   [SerializeField]private GameData gameData;
   [SerializeField]private CardData cardData;
   [SerializeField]private CardPooler cardPooler;
   [SerializeField]private Transform currentcontainer;
   [SerializeField]private GridLayoutGroup gridLayout;
   private LevelDataInfo currentLevelData;
   private void OnEnable() {
    levelActions.generateLevel += GenerateLevel;
   }
   private void OnDisable() {
    levelActions.generateLevel -= GenerateLevel;
   }
   private void GenerateLevel(int level) {
      currentLevelData = levelData.levelData[level];
      int grid = currentLevelData.rows * currentLevelData.columns;
      List<SpriteData> currentSprites= cardData.GetSprites(grid);
      gridLayout.constraintCount = currentLevelData.columns;
      CardPooler.Instance.Initialize(currentcontainer);
      ResetLevel();
      AdjustCellSize();
      for (int cardIndex = 0; cardIndex < grid; cardIndex++)
      {
         Card card = CardPooler.Instance.GetCard();
         card.SetCard(cardIndex, currentSprites[cardIndex].sprite, currentSprites[cardIndex].pairId);
         gameData.cards.Add(card);
      }
      levelActions.onLevelGenerated?.Invoke();
   }
   private void ResetLevel()
   {
      foreach (Card card in gameData.cards)
      {
         CardPooler.Instance.ReturnCard(card);
         card.ResetAnimation();
      }
      gameData.Initialize();
   }
   private void AdjustCellSize()
   {
      float availableWidth = currentcontainer.GetComponent<RectTransform>().rect.width;
      int columnCount = currentLevelData.columns;
      float cellWidth = (availableWidth - ((columnCount - 1) * gridLayout.spacing.x) - gridLayout.padding.left - gridLayout.padding.right) / columnCount;
      float cellHeight = cellWidth;
      gridLayout.cellSize = new Vector2(Mathf.RoundToInt(cellWidth), Mathf.RoundToInt(cellHeight));
   }
   private void OnDestroy()
   {
      gameData.Initialize();
   }
}
