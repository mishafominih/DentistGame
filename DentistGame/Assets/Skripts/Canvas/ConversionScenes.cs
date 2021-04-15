using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ConversionScenes : MonoBehaviour
{
    public string NameScene;
    public AudioClip music;

    private void PlayEffect()
    {
        var audio = GameObject.FindWithTag("AudioEffects").GetComponent<AudioSource>();
        Music.PlayMusic(audio, music);
    }

    public void CreateSecene()
    {
        if (!(music is null)) PlayEffect();
        SceneManager.LoadScene(NameScene, LoadSceneMode.Single);
    }
}

