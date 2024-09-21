using System;
using UnityEngine;
public abstract class UIElement : MonoBehaviour
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private UIAnimator animator;
    public UIScreen screenName;

    private void Awake()
    {

        canvas = GetComponent<Canvas>();
        canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup not found in child");
        }
        animator = GetComponent<UIAnimator>();
        UIManager.Instance.RegisterUIElements(this);
    }
    public virtual void Show(Action callback = null)
    {
        canvas.enabled = true;
        if (animator != null)
        {
            canvasGroup.blocksRaycasts = false;
            animator.ShowUIAnimation(() =>
            {
                onShowComplete();
                callback?.Invoke();
            });
        }
        else
        {
            callback?.Invoke();
            canvasGroup.blocksRaycasts = true;
        }

    }
    public void HideDirectly()
    {
        canvasGroup.blocksRaycasts = false;
        canvas.enabled = false;
    }
    public virtual void Hide(Action callback = null)
    {
        if (animator != null)
        {
            animator.HideUIAnimation(() =>
            {
                onHideComplete();
                callback?.Invoke();
            });
        }
        else
        {
            canvasGroup.blocksRaycasts = false;
            canvas.enabled = false;
            callback?.Invoke();
        }

    }
    public void SetLayerOder(int order)
    {
        canvas.sortingOrder = order;
    }
    public virtual void onShowComplete()
    {
        canvasGroup.blocksRaycasts = true;
    }
    public virtual void onHideComplete()
    {
        canvasGroup.blocksRaycasts = false;
        canvas.enabled = false;
    }
}
