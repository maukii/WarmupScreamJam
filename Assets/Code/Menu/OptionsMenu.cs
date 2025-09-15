using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer master;
    [SerializeField] AudioMixerGroup sfxMixer;
    [SerializeField] AudioMixerGroup musicMixer;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;

    void Start()
    {
        LoadVolume();
    }
    public void LoadVolume()
    {
        masterSlider.value = (float)Math.Pow(10f, PlayerPrefs.GetFloat("masterVolume") / 20f);
        sfxSlider.value = (float)Math.Pow(10f, PlayerPrefs.GetFloat("SFX") / 20f); 
        musicSlider.value = (float)Math.Pow(10f, PlayerPrefs.GetFloat("Music") / 20f);
    }
    public void SetVolume()
    {
        master.SetFloat("MasterVolume", Mathf.Log10(masterSlider.value) * 20);
        sfxMixer.audioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
        musicMixer.audioMixer.SetFloat("Music", Mathf.Log10(musicSlider.value) * 20);
    }
}
