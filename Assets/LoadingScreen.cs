using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class LoadingScreen : UIElement
{
    [SerializeField] private LevelActions levelActions;
    [SerializeField]private UIAnimations uIAnimations;
    [SerializeField]private GameData gameData;
    public override void Show(System.Action callback = null)
    {
        base.Show(callback);
        uIAnimations.Show();
        levelActions.onLevelGenerated+=OnLevelGenerated;
    }
    public override void Hide(System.Action callback = null)
    {
        base.Hide(callback);
        levelActions.onLevelGenerated-=OnLevelGenerated;
    }
    public override void onShowComplete()
    {
        base.onShowComplete();
        gameData.cards.ForEach(card => card.Reset());
        //levelActions.onProgressToNextLevel?.Invoke();
    }
    private void OnLevelGenerated()
    {
        Invoke("HideLoadingScree", 1f);
    }
    private void HideLoadingScree()
    {
        UIManager.Instance.HideScreen(UIScreen.LoadingScreen);
    }

}

