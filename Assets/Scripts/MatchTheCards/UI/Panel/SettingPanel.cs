using UnityEngine;
using UnityEngine.UI;
public class SettingPanel : MonoBehaviour
{
    [SerializeField]private GameObject content;
    [SerializeField]private Image musicToggleImage;
    [SerializeField]private Image soundToggleImage;
    [SerializeField]private Sprite musicOnSprite;
    [SerializeField]private Sprite musicOffSprite;
    [SerializeField]private Sprite soundOnSprite;
    [SerializeField]private Sprite soundOffSprite;

    private bool isMusicOn = true;
    private bool isSoundOn = true;
    public void ShowSetting()
    {
        content.SetActive(true);
    }
    public void HideSetting()
    {
       content.SetActive(false);
    }
    public void MusicToggle()
    {
        isMusicOn = !isMusicOn;
        AudioManager.Instance.ToggleBG();
        if (isMusicOn)
        {
           musicToggleImage.sprite = musicOffSprite;
        }
        else
        {
            musicToggleImage.sprite = musicOnSprite;
        }
    }
    public void SoundToggle()
    {
        isSoundOn = !isSoundOn;
        AudioManager.Instance.ToggleFX();
        if (isSoundOn)
        {
            soundToggleImage.sprite = soundOffSprite;
        }
        else
        {
            soundToggleImage.sprite = soundOnSprite;
        }
    }
}
