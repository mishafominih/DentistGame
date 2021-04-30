using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OpenInstruments : MonoBehaviour
{
    public AudioClip music;
    public string price;
    public string key;
    protected Text text;
    private Image sprite;
    // Start is called before the first frame update
    void Start()
    {
        WritePrice();
        text = GetComponentInChildren<Text>();
        price = PlayerPrefs.GetString(key);
        text.text = price;
        sprite = transform.parent.GetComponent<Image>();
    }

    protected void WritePrice()
    {
        if (!PlayerPrefs.HasKey(key) || price != "0")
            PlayerPrefs.SetString(key, price);
    }

    // Update is called once per frame
    protected void Buy()
    {
        if(text.text != "")
        {
            var money = GameObject.FindGameObjectWithTag("State").GetComponentInChildren<Money>();
            if(money.GetMoney() > int.Parse(text.text))
            {
                PlayMusic();
                money.ChangeCount(-int.Parse(text.text));
                text.text = "";
                price = "0";
                //PlayerPrefs.SetString(key, price);
            }
        }
    }

    private void PlayMusic()
    {
        var audio = GameObject.FindWithTag("AudioEffects").GetComponent<AudioSource>();
        Music.PlayMusic(audio, music);
    }

    private void Update()
    {
        if (price == "0") Destroy(gameObject);
    }
}
