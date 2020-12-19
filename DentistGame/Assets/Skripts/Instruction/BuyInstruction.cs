using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyInstruction : MonoBehaviour
{
    public string price;
    public string key;
    public Sprite isBuy;
    public Image sprite;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        WritePriceInstruction();
        text = GetComponentInChildren<Text>();
        price = PlayerPrefs.GetString(key);
        text.text = price == "0" ? null : price;
        if (price == "0")
            sprite.sprite = isBuy;
    }
    private void WritePriceInstruction()
    {
        if (!PlayerPrefs.HasKey(key))
            PlayerPrefs.SetString(key, price);
    }

    public void Buy()
    {
        if (text.text != null)
        {
            var money = GameObject.FindGameObjectWithTag("State").GetComponentInChildren<Money>();
            if (money.GetMoney() > int.Parse(text.text))
            {
                money.ChangeCount(-int.Parse(text.text));
                text.text = null;
                price = "0";
                sprite.sprite = isBuy;
                PlayerPrefs.SetString(key, price);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (price == "0") Destroy(gameObject);
    }
}
