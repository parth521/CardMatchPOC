using System;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    public int index;
    public int pairIndex;
    public Image secondaryImage;
    [SerializeField]private UIAnimations flipAnimation;
    [SerializeField]private UIAnimations matchAnimation;
    public Action  OnCardShowFlipComplete;
    public Action   OnCardHideFlipComplete;
    public bool isMatched = false;

    private int flipAnimationCount = 0;
    
    public void Reset() {
        ResetAnimation();
        isMatched = false;
        pairIndex = 0;
    }
    public void SetCard(int index,Sprite sprite,int _pairIndex)
    {
        this.index = index;
        this.secondaryImage.enabled = false;
        this.secondaryImage.sprite = sprite;
        this.pairIndex = _pairIndex;
    }
    public void FlipToshow(Action onShowComplete)
    {
        OnCardShowFlipComplete = onShowComplete;
        flipAnimation.Show(OnShowComplete);
    }
    public void FlipToHide(Action onHideComplete)
    {
        OnCardHideFlipComplete = onHideComplete;
        flipAnimation.Hide(OnHideComplete);
    }
    public void ResetAnimation()
    {
        matchAnimation.Hide();
        flipAnimation.Hide();
    }
    public void Match(Action onMatchComplete)
    {
        matchAnimation.Show(()=>
        {
            onMatchComplete?.Invoke();
        });
    }
    private void OnShowComplete()
    {
        if(flipAnimationCount==0) //Half flip Complete
        {
            this.secondaryImage.enabled = true;
            flipAnimationCount++;
        }
        if(flipAnimationCount==1) //Full flip Complete
        {
            flipAnimationCount = 0;
            OnCardShowFlipComplete?.Invoke();
        }
    }
    private void OnHideComplete()
    {
        if(flipAnimationCount==0) //Half flip Complete
        {
            this.secondaryImage.enabled = false;
            flipAnimationCount++;
        }
        if(flipAnimationCount==1) //Full flip Complete
        {
            flipAnimationCount = 0;
            OnCardHideFlipComplete?.Invoke();
        }

    }
}
