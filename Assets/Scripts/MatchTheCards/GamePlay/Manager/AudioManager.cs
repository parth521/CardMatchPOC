using UnityEngine;

public class AudioManager :Singleton<AudioManager>
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgSource;
    [SerializeField] private AudioSource fxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip defaultBGClip;


    private bool isBGMuted = false;
    private bool isFXMuted = false;

    private void Start()
    {
        PlayBG(defaultBGClip); // Optionally play default BG at the start
    }
    // Play background music
    public void PlayBG(AudioClip bgClip)
    {
        if (isBGMuted || bgClip == null) return;

        bgSource.clip = bgClip;
        bgSource.loop = true;
        bgSource.Play();
    }

    // Stop background music
    public void StopBG()
    {
        bgSource.Stop();
    }

    // Play sound effect
    public void PlayFX(AudioClip fxClip)
    {
        if (isFXMuted || fxClip == null) return;

        fxSource.PlayOneShot(fxClip);
    }

    // Toggle background music on/off
    public void ToggleBG()
    {
        isBGMuted = !isBGMuted;

        if (isBGMuted)
        {
            bgSource.Pause();
        }
        else
        {
            bgSource.UnPause();
        }
    }

    // Toggle sound effects on/off
    public void ToggleFX()
    {
        isFXMuted = !isFXMuted;
    }

    // Check if BG is muted
    public bool IsBGMuted()
    {
        return isBGMuted;
    }

    // Check if FX is muted
    public bool IsFXMuted()
    {
        return isFXMuted;
    }
}
