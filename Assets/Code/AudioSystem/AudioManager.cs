using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("SFX")]
    public List<AudioData> sfxList = new List<AudioData>();
    public List<MusicData> musicList = new List<MusicData>();

    Coroutine fadeMusic;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Audio Manager
    public void PlayAudio(string name)
    {
        AudioData audio = FindAudio(name);

        if (audio != null)
        {
            // Set attributes
            instance.sfxSource.volume = audio.volume;
            instance.sfxSource.pitch = audio.pitch;

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
    // Music Manager
    public void PlayMusic(string title)
    {
        MusicData music = FindMusic(title);

        if (music != null)
        {
            // Set attributes
            instance.musicSource.volume = music.volume;
            instance.musicSource.resource = music.clip;

            instance.musicSource.Play(1);
        }
    }
    private MusicData FindMusic(string title)
    {
        foreach (MusicData music in musicList)
        {
            if (name == music.title)
            {
                return music;
            }
        }
        return null;
    }

    // Fade Out
    public void FadeOutMusic(float interval)
    {
        fadeMusic = StartCoroutine(FadeOut(interval));
    }
    IEnumerator FadeOut(float interval)
    {
        float volume = instance.musicSource.volume;

        while (volume > 0)
        {
            volume -= 0.1f;
            yield return new WaitForSeconds(interval);
        }
    }
    // Fade In
    public void FadeInMusic(string name, float interval)
    {
        PlayMusic(name);
        instance.musicSource.volume = 0f;
        fadeMusic = StartCoroutine(FadeIn(interval));
    }
    IEnumerator FadeIn(float interval)
    {
        float volume = 0.0f;
        float targetVolume = instance.musicSource.volume;

        while (volume < targetVolume)
        {
            volume += 0.1f;
            yield return new WaitForSeconds(interval);
        }
    }
}
