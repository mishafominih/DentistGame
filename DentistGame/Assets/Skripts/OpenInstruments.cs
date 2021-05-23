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
    // Start is called before the first frame update
    void Start()
    {
        WritePrice();
        text = GetComponentInChildren<Text>();
        price = PlayerPrefs.GetString(key);
        text.text = price;
    }

    protected void WritePrice()
    {
        if (!PlayerPrefs.HasKey(key))
            PlayerPrefs.SetString(key, price);
    }

    // Update is called once per frame
    protected void Buy()
    {
        if(text.text != "")
        {
            var money = GameObject.FindGameObjectWithTag("State").GetComponentInChildren<Money>();
            if(money.GetMoney() >= int.Parse(text.text))
            {
                Music.PlayMusic(music);
                money.ChangeCount(-int.Parse(text.text));
                text.text = "";
                price = "0";
                PlayerPrefs.SetString(key, price);
                UpdateCoefficient();
            }
        }
    }

    public static void UpdateCoefficient()
    {
        var coefficient = 1;
        if (PlayerPrefs.HasKey("moneyCoefficient"))
        {
            coefficient = PlayerPrefs.GetInt("moneyCoefficient") + 1;
            coefficient = coefficient > 6 ? 1 : coefficient;
        }
        PlayerPrefs.SetInt("moneyCoefficient", coefficient);
    }

    private void Update()
    {
        if (price == "0") Destroy(gameObject);
    }
}
