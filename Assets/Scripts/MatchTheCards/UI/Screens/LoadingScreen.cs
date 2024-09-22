using UnityEngine;

public class LoadingScreen : UIElement
{
    [SerializeField] private LevelActions levelActions;
    [SerializeField] private GameData gameData;
    [SerializeField]private PlayerData playerData;

    public override void Show(System.Action callback = null)
    {
        base.Show(callback);
        levelActions.onLevelGenerated += OnLevelGenerated;
    }
    public override void Hide(System.Action callback = null)
    {
        base.Hide(callback);
        levelActions.onLevelGenerated -= OnLevelGenerated;
    }
    public override void onShowComplete()
    {
        base.onShowComplete();
        levelActions.generateLevel?.Invoke(playerData.currentLevelData);
        gameData.cards.ForEach(card => card.Reset());
    }
    public override void onHideComplete()
    {
        base.onHideComplete();
        levelActions.dispalyTilesOnLevelStart?.Invoke();
    }
    private void OnLevelGenerated()
    {
        Hide();
    }


}

