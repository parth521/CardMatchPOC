using System;
using UnityEngine;
using DG.Tweening;
public class FadeComponent : UIAnimations
{
    private CanvasGroup canvasGroup;
    public override void Awake() {
        base.Awake();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public override void Show(Action callback = null)
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1,duration).SetDelay(delay).SetEase(ease).OnComplete(() => {
            callback?.Invoke();
        });
    }
    public override void Hide(Action callback = null)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.DOFade(0,duration).SetDelay(delay).SetEase(ease).OnComplete(() => {
            callback?.Invoke();
        });
    }
}
