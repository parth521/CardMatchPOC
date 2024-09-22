using System;
using UnityEngine;
public class GameTitleScreen : UIElement
{
    public override void Show(Action callback = null)
    {
        base.Show(callback);
    }
    public override void Hide(Action callback = null)
    {
        base.Hide(callback);
    }
    public override void onShowComplete()
    {
        base.onShowComplete();
    }
    public void OnPlay()
    {
        UIManager.Instance.ChangeScreen(UIScreen.GamePlayScreen);
    }
}
