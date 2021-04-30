using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource Effects;

    void Start()
    {
        var slider = GetComponentInChildren<Slider>();
        var toggle = GetComponentInChildren<Toggle>();
        Effects = GameObject.FindWithTag("AudioEffects").GetComponent<AudioSource>();
        Music = GameObject.FindWithTag("AudioMusic").GetComponent<AudioSource>();
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
        toggle.isOn = PlayerPrefs.GetInt("Effects") == 1;
    }

    public void ToggleMusic(bool enabled)
    {
        Effects.enabled = enabled;
        PlayerPrefs.SetInt("Effects", enabled ? 1 : 0);
    }

    public void MasterVolume(float volume)
    {
        Music.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
