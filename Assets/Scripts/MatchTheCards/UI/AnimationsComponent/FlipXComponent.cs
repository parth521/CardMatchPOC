using System;
using UnityEngine;
using DG.Tweening;
using Unity.IO.LowLevel.Unsafe;
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
        Tween tween = null; // Initialize the 'tween' variable with a default value
        tween = rectTransform.DORotate(new Vector3(0, showRotation, 0), duration).SetEase(ease).
        OnUpdate(() => 
        {
            if(tween.ElapsedPercentage()>=.5f)
            {
                callback?.Invoke();
            }
        }).OnComplete(() => callback?.Invoke());
    }
    public override void Hide(Action callback = null)
    {
        Tween tween = null; // Initialize the 'tween' variable with a default value
        tween = rectTransform.DORotate(new Vector3(0, hideRotation, 0), duration).SetEase(ease).
        OnUpdate(() => 
        {
            if(tween.ElapsedPercentage()>=.5f)
            {
                callback?.Invoke();
            }
        }).OnComplete(() => callback?.Invoke());
    }
}
