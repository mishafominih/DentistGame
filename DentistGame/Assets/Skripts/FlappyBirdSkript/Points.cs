using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static Points Instance;

    public int points { get; private set; }
    public AudioClip music;
    private Text text;
    private const string MAX_POINTS = "MaxPoints";
    private string startText;
    private bool newRecord = false;
    private int record;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        record = PlayerPrefs.GetInt(MAX_POINTS);
        text = GetComponent<Text>(); 
        startText = text.text.Split(' ')[0];
        SetText();
    }

    public void AddPoint()
    {
        points++;
        SetText();
    }

    private void SetText()
    {
        if (points > record && !newRecord)
        {
            newRecord = true;
            PlayMusic();
        }
        text.text = startText + ' ' + points.ToString() + " | " + record.ToString();
    }

    private void PlayMusic()
    {
        var audio = GameObject.FindWithTag("AudioEffects").GetComponent<AudioSource>();
        Music.PlayMusic(music);
    }

    public void CheckResult()
    {
        if (points > record)
        {
            PlayerPrefs.SetInt(MAX_POINTS, points);
        }
    }
}
