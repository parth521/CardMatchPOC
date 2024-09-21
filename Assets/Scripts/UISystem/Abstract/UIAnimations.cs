using System;
using UnityEngine;
public abstract class UIAnimations : MonoBehaviour
{
    [SerializeField]protected float duration;
    [SerializeField]protected float delay;
    public abstract void Show(Action callback=null);
    public abstract void Hide(Action callback=null);
}
