using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyInstruction : OpenInstruments
{
    public Sprite isBuy;
    public Image sprite;
    public string keyForHelp;

    // Start is called before the first frame update
    void Start()
    {
        WritePrice();
        text = GetComponentInChildren<Text>();
        price = PlayerPrefs.GetString(key);
        text.text = price == "0" ? null : price;
        if (price == "0")
            sprite.sprite = isBuy;
    }

    // Update is called once per frame
    void Update()
    {
        if (price == "0")
            sprite.sprite = isBuy;
    }

    public void HelpInGame()
    {
        if (price == "0")
        {
            PlayerPrefs.SetInt(keyForHelp, 1);
        }
    }
}
