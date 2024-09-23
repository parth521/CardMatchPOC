using System;
using UnityEngine;
using DG.Tweening;
public class FadeComponent : UIAnimations
{
    private CanvasGroup canvasGroup;
    private LevelActions levelActions;
    public override void Awake() {
        base.Awake();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public override void Show(Action callback = null)
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = true;
        PlayTween(
        canvasGroup.DOFade(1, duration).SetDelay(showdelay).SetEase(ease),callback);
    }
    public override void Hide(Action callback = null)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = false;
        PlayTween(canvasGroup.DOFade(0,duration).SetDelay(hidedelay).SetEase(ease),callback);
    }
}
