using System;
using UnityEngine;
using DG.Tweening;
public abstract class UIAnimations : MonoBehaviour
{
    [SerializeField]protected float duration;
    [SerializeField]protected float delay;
    [SerializeField]protected Ease ease;
    [SerializeField]protected AnimationType animationType;

    public virtual void Awake() {
        if(animationType!=AnimationType.Custom)
        transform.root.GetComponent<UIAnimator>().RegisterAnimation(this);
    }
    public abstract void Show(Action callback=null);
    public abstract void Hide(Action callback=null);
}
