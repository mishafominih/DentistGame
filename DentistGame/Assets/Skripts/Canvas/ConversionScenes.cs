using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ConversionScenes : MonoBehaviour
{
    public string NameScene;
    public AudioClip music;

    public void CreateSecene()
    {
        if (!(music is null)) Music.PlayMusic(music); ;
        SceneManager.LoadScene(NameScene, LoadSceneMode.Single);
    }
}

