using UnityEngine;

[System.Serializable]
public class AudioData
{
    public string name;
    [Range(0f, 1.0f)]
    public float volume;
    [Range(-12, 12)]
    public int pitch;
    public AudioClip clip;

    public AudioData()
    {
        this.volume = 1.0f;
        this.pitch = 0;

    }
}