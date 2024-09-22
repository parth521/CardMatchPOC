using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/AudioData", order = 1)]
public class AudioData : ScriptableObject
{
    public AudioClip cardFlip;
    public AudioClip cardMatch;
    public AudioClip cardMismatch;
    public AudioClip levelComplete;

}
