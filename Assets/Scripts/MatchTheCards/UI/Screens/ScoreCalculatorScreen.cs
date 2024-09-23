using UnityEngine;
using TMPro;
using DG.Tweening;
public class ScoreCalculatorScreen : UIElement
{
    [SerializeField]private GameData gameData;
    [SerializeField]private ScoreConfig scoreConfig;
    [SerializeField]private TextMeshProUGUI scoreText;
    [SerializeField] private LevelActions levelActions;
    [SerializeField] private PlayerData playerData;
    private int score;
    public override void Show(System.Action callback = null)
    {
        base.Show(callback);
        score=scoreConfig.CalculatePoints(gameData.moves);
    }
    public override void Hide(System.Action callback = null)
    {
        base.Hide(callback);
    }
    public override void onShowComplete()
    {
        base.onShowComplete();
        AnimateTextIncrement(0, score, 1.5f);
    }
    void AnimateTextIncrement(int startValue, int endValue, float duration)
    {
        DOTween.To(() => startValue, x => startValue = x, endValue, duration)
            .OnUpdate(() =>
            {
                scoreText.text = startValue.ToString();
            })
            .SetEase(Ease.OutQuad).OnComplete(OnCalculationComplete);
    }
    private void OnCalculationComplete()
    {
        Hide();
    }
    public override void onHideComplete()
    {
        base.onHideComplete();
        playerData.SerPlayerData(score);
        levelActions.displayScore?.Invoke(playerData.playerScore);
        Debug.LogError("Score Calculated");
        UIManager.Instance.ShowScreen(UIScreen.LoadingScreen);
    }  
}
