using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OpenInstruments : MonoBehaviour
{
    public int i;

    private Image sprite;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.text = File.ReadAllLines("OpenInstrument.txt")[i];
        sprite = transform.parent.GetComponent<Image>();
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
            }
        }
    }

    private void Update()
    {
        if (text.text == "0") Destroy(gameObject);
    }
}
