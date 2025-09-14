using System.Runtime.CompilerServices;
using UnityEngine;
[System.Serializable]
public class MusicData
{
    public string title;
    [Range(0f, 1.0f)]
    public float volume;
    public AudioClip clip;

    public MusicData()
    {
        this.volume = 1.0f;
    }
}