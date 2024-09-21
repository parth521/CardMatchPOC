using UnityEngine;
using DG.Tweening;
public class SettingPanel : MonoBehaviour
{
    [SerializeField]private UIAnimations uIAnimations;
    private bool isShow = false;
    public void OnSettingToggle()
    {
        if(isShow)
        {
            Debug.LogError("==> Hide");
            isShow = false;
            uIAnimations.Hide();
        }
        else
        {
            isShow = true;
            uIAnimations.Show();
        }
    }
   
}
