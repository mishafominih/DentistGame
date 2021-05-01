using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyOrUseInstrument : MonoBehaviour
{
    public GameObject Instrument;
    public string key;
    public AudioClip music;
    void Start()
    {
        UpdateText();
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (transform.childCount > 0)
            {
                var money = Money.Instance;
                var text = GetComponentInChildren<Text>();
                var cost = int.Parse(text.text);
                if (money.GetMoney() >= cost)
                {
                    money.ChangeCount(-cost);
                    Music.PlayMusic(music);
                    //PlayerPrefs.SetString(key, price);
                    Destroy(transform.GetChild(0).gameObject);
                }
            }
            else
            {
                Instantiate(Instrument);
            }
        });
    }

    private void UpdateCast()
    {
        var price = GetComponentInChildren<Text>().text;
        if (!PlayerPrefs.HasKey(key) || price != "")
            PlayerPrefs.SetString(key, price);
    }

    private void UpdateText()
    {
        if (PlayerPrefs.HasKey(key))
        {
            var info = PlayerPrefs.GetString(key);
            if (info == "0")
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            else
            {
                GetComponentInChildren<Text>().text = info;
            }
        }
    }
}
