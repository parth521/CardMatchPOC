using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    public int index;
   
    public Image secondaryImage;
    [SerializeField]private UIAnimations flipAnimation;
    [SerializeField]private UIAnimations matchAnimation;
    private int flipAnimationCount = 0;
    
    public void SetCard(int index,Sprite sprite)
    {
        this.index = index;
        this.secondaryImage.enabled = false;
        this.secondaryImage.sprite = sprite;
    }
    public void FlipToshow()
    {
        flipAnimation.Show(OnShowComplete);
    }
    public void FlipToHide()
    {
        flipAnimation.Hide(OnHideComplete);
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
        }

    }
}
