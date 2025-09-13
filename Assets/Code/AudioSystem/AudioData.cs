using UnityEngine;

[System.Serializable]
public class AudioData
{
    public string name;
    [Range(0f, 2.0f)]
    public float volume;
    [Range(-12f, 12f)]
    public float pitch;
    public AudioClip clip;

    public AudioData()
    {
        this.volume = 1.0f;
        this.pitch = 0f;

    }
}