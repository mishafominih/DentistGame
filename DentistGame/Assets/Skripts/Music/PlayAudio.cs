using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
        DontDestroyOnLoad(this);
    }

    private void PlayMusic()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            var audio = GameObject.FindGameObjectWithTag(tag).GetComponent<AudioSource>();
            var volume = PlayerPrefs.GetFloat("MusicVolume");
            audio.volume = volume;
        }
    }
}
