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
    public static void PlayAudio(string name)
    {
        AudioData audio = instance.FindAudio(name);

        if (audio != null)
        {
            // Set attributes
            instance.sfxSource.volume = audio.volume;
            float pitch = Mathf.Pow(2f, audio.pitch / 12f);
            instance.sfxSource.pitch = Mathf.Clamp(pitch, 0.1f, 3f);

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
    public static void PlayMusic(string title)
    {
        MusicData music = instance.FindMusic(title);

        if (music != null)
        {
            // Set attributes
            instance.musicSource.volume = music.volume;
            instance.musicSource.resource = music.clip;

            instance.musicSource.Play();
        }
    }
    public static void StopMusic()
    {
        instance.musicSource.resource = null;
    }
    private MusicData FindMusic(string title)
    {
        foreach (MusicData music in musicList)
        {
            if (title == music.title)
            {
                return music;
            }
        }
        return null;
    }

    // Fade Out
    public static void FadeOutMusic(float interval)
    {
        instance.fadeMusic = instance.StartCoroutine(instance.FadeOut(interval));
    }
    IEnumerator FadeOut(float interval)
    {
        float volume = instance.musicSource.volume;

        while (volume > 0)
        {
            instance.musicSource.volume -= 0.1f;
            yield return new WaitForSeconds(interval);
        }
    }
    // Fade In
    public static void FadeInMusic(string name, float interval)
    {
        PlayMusic(name);
        instance.fadeMusic = instance.StartCoroutine(instance.FadeIn(interval));
    }
    IEnumerator FadeIn(float interval)
    {
        float volume = 0.0f;
        float targetVolume = instance.musicSource.volume;
        instance.musicSource.volume = 0f;

        while (volume < targetVolume)
        {
            volume += 0.1f;
            instance.musicSource.volume = volume;
            yield return new WaitForSeconds(interval);
        }
    }
}
