using System;
using DG.Tweening;
using UnityEngine;

public class CardHideAnimationComponent : UIAnimations
{

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public override void Awake()
    {
        base.Awake();
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }
    public override void Hide(Action callback = null)
    {
        rectTransform.localScale = Vector3.one;
        callback?.Invoke();
    }
    public override void Show(Action callback = null)
    {

        // Create a new sequence
        Sequence sequence = DOTween.Sequence();

        // Create a scale tween
        Tween scaleTween = rectTransform.DOScale(Vector3.one, 0.7f)
            .From(Vector3.one) // Start from zero scale and grow to full size
            .SetEase(Ease.OutElastic)
            .SetDelay(showdelay)
            .OnComplete(() =>
            {
                rectTransform.DOScale(Vector2.zero, 0.3f).SetEase(Ease.InBack);
            });

        // Add the scale tween to the sequence
        sequence.Join(scaleTween);

        // Pass the sequence to the PlaySequence method with the callbacks
        PlaySequence(sequence, callback, () =>
        {
            Debug.Log("Halfway point reached");
            // You can trigger additional logic when halfway is reached here
        });
    }

}
