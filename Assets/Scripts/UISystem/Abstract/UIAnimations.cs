using System;
using UnityEngine;
using DG.Tweening;
public abstract class UIAnimations : MonoBehaviour
{
    [SerializeField] protected float duration;
    [SerializeField] protected float showdelay;
    [SerializeField] protected float hidedelay;
    [SerializeField] protected Ease ease;
    [SerializeField] protected AnimationType animationType;
    public bool isPlaying { get; protected set; }
    public virtual void Awake()
    {
        if (animationType != AnimationType.Custom)
            transform.root.GetComponent<UIAnimator>().RegisterAnimation(this);
    }
    public abstract void Show(Action callback = null);
    public abstract void Hide(Action callback = null);
    protected Tween PlayTween(Tween tween, Action callback = null,Action reacherdHalfCallback=null)
    {
        isPlaying = true;

        return tween
            .OnStart(() => isPlaying = true)
            .OnUpdate(() =>
            {
                if (reacherdHalfCallback != null && tween.Elapsed() >= tween.Duration() / 2)
                {
                    reacherdHalfCallback?.Invoke();
                    reacherdHalfCallback = null;
                }
            })
            .OnComplete(() =>
            {
                isPlaying = false;
                callback?.Invoke(); // Call the callback if provided
            });
    }

    protected Sequence PlaySequence(Sequence sequence, Action callback = null,Action reacherdHalfCallback=null)
    {
        isPlaying = true;

        return sequence
            .OnStart(() => isPlaying = true)
            .OnComplete(() =>
            {
                isPlaying = false;
                callback?.Invoke(); // Call the callback if provided
            });
    }
}
