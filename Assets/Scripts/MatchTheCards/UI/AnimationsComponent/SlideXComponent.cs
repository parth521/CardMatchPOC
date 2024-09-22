using UnityEngine;
using System;
using DG.Tweening;
public class SlideXComponent : UIAnimations
{
    private RectTransform rectTransform;
    [SerializeField]private float showSlideX;
    [SerializeField]private float hideSlideX;

    public override void Awake() {
        base.Awake();
        rectTransform = GetComponent<RectTransform>();
        showSlideX = 0;
        hideSlideX = -rectTransform.rect.width;
    }
    public override void Hide(Action callback = null)
    {
        rectTransform.anchoredPosition = new Vector2(hideSlideX,rectTransform.anchoredPosition.y);
        PlayTween( rectTransform.DOAnchorPosX(showSlideX,duration).SetDelay(hidedelay).SetEase(ease), callback);
    }

    public override void Show(Action callback = null)
    {
        rectTransform.anchoredPosition = new Vector2(showSlideX,rectTransform.anchoredPosition.y);
        PlayTween( rectTransform.DOAnchorPosX(hideSlideX,duration).SetDelay(showSlideX).SetEase(ease),callback);
    }
}
