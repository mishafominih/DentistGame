using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public string tag;
    void Start()
    {
        Play();
        DontDestroyOnLoad(this);
    }

    private void Play()
    {
        if (PlayerPrefs.HasKey("Effects"))
        {
            var effects = GameObject.FindGameObjectWithTag(tag).GetComponent<AudioSource>();
            effects.enabled = PlayerPrefs.GetInt("Effects") == 1;
        }
    }
}
