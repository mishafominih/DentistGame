using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OpenInstruments : MonoBehaviour
{
    public string price;
    public string key;
    private Image sprite;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        WritePriceInstrument();
        text = GetComponentInChildren<Text>();
        price = PlayerPrefs.GetString(key);
        text.text = price;
        sprite = transform.parent.GetComponent<Image>();
    }

    private void WritePriceInstrument()
    {
        if (!PlayerPrefs.HasKey(key) || price != "0")
            PlayerPrefs.SetString(key, price);
    }

    // Update is called once per frame
    public void Buy()
    {
        if(text.text != null)
        {
            var money = GameObject.FindGameObjectWithTag("State").GetComponentInChildren<Money>();
            if(money.GetMoney() > int.Parse(text.text))
            {
                money.ChangeCount(-int.Parse(text.text));
                text.text = "0";
                price = "0";
                //PlayerPrefs.SetString(key, price);
            }
        }
    }

    private void Update()
    {
        if (text.text == "0") Destroy(gameObject);
    }
}
