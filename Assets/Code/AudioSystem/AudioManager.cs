using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("SFX")]
    public List<AudioData> sfxList = new List<AudioData>();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void PlayAudio(string name)
    {
        AudioData audio = FindAudio(name);

        if (audio != null)
        {
            instance.sfxSource.PlayOneShot(audio.clip);
        }
    }
    private AudioData FindAudio(string name)
    {
        foreach (AudioData audio in sfxList)
        {
            if (name == audio.name)
            {
                return audio;
            }
        }
        return null;
    }
}
