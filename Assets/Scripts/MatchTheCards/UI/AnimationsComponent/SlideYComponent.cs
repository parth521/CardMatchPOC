using System;
using UnityEngine;
using DG.Tweening;
public class SlideYComponent : UIAnimations
{
    private RectTransform rectTransform;
    [SerializeField]private float showSlideY;
    [SerializeField]private float hideSlideY;
    public override void Awake() {
        base.Awake();
        rectTransform = GetComponent<RectTransform>();
    }
    public override void Hide(Action callback = null)
    {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x,showSlideY);
        PlayTween(rectTransform.DOAnchorPosY(hideSlideY, duration).SetDelay(hidedelay).SetEase(ease), callback);
    }

    public override void Show(Action callback = null)
    {
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x,hideSlideY);
        PlayTween( rectTransform.DOAnchorPosY(showSlideY,duration).SetDelay(showdelay).SetEase(ease), callback);
    }
}
