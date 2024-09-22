using System;
using UnityEngine;
using DG.Tweening;
public class FlipXComponent : UIAnimations
{
    [SerializeField] private float showRotation;
    [SerializeField] private float hideRotation;
    private RectTransform rectTransform;
    public override void Awake() {
        base.Awake();
        rectTransform = GetComponent<RectTransform>();
    }

    public override void Show(Action callback = null)
    {
        PlayTween(rectTransform.DORotate(new Vector3(0, showRotation, 0), duration).SetDelay(showdelay).SetEase(ease), callback,
        () => {
            callback?.Invoke();
        });
    }
    public override void Hide(Action callback = null)
    {
        PlayTween(rectTransform.DORotate(new Vector3(0, hideRotation, 0), duration).SetDelay(hidedelay).SetEase(ease), callback,
        () => {
            callback?.Invoke();
        });
    }
}
