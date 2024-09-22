using System;
using UnityEngine;
public class GamePlayScreen : UIElement
{
    [SerializeField]private LevelActions levelActions;
    public override void Show(Action callback = null)
    {
        base.Show(callback);
        levelActions.generateLevel?.Invoke(2);

    }
    public override void Hide(Action callback = null)
    {
        base.Hide(callback);
    }
}
