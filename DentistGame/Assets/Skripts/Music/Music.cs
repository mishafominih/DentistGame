using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static void PlayMusic(AudioClip music)
    {
        try
        {
            var audio = GameObject.FindWithTag("AudioEffects").GetComponent<AudioSource>();
            if (audio.enabled)
            {
                if (audio.isPlaying)
                    audio.Stop();
                audio.PlayOneShot(music);
            }
        }
        catch { }
    }

    public static void PlayCleaningMusic(AudioClip music)
    {
        try
        {
            var audio = GameObject.FindWithTag("AudioEffects").GetComponent<AudioSource>();
            if (audio.enabled)
            {
                if (!audio.isPlaying)
                    audio.PlayOneShot(music);
            }
        }
        catch { }
    }
}
