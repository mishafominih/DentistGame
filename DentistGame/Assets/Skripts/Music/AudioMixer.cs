using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    private AudioSource Music;
    private AudioSource Effects;

    void Start()
    {
        var slider = GetComponentInChildren<Slider>();
        var toggle = GetComponentInChildren<Toggle>();
        Effects = GameObject.FindWithTag("AudioEffects").GetComponent<AudioSource>();
        Music = GameObject.FindWithTag("AudioMusic").GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("MusicVolume"))
            slider.value = PlayerPrefs.GetFloat("MusicVolume");
        else
            slider.value = Music.volume;
        if (PlayerPrefs.HasKey("Effects"))
            toggle.isOn = PlayerPrefs.GetInt("Effects") == 1;
        else
            toggle.isOn = Effects.enabled;
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
