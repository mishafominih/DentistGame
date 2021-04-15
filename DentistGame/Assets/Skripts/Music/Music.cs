using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static void PlayMusic(AudioSource audio, AudioClip music)
    {
        DontDestroyOnLoad(audio);
        if (audio.isPlaying)
            audio.Stop();
        audio.PlayOneShot(music);
    }
}
