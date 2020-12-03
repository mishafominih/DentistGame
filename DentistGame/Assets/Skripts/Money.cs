using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public float interval = 1;
    private string key = "money";
    private int count;
    private Text text;
    private Timer timer;
    void Start()
    {
        text = GetComponentInChildren<Text>();
        timer = new Timer(interval);
        Upd();
    }

    public void ChangeCount(int d)
    {
        var res = count + d;
        if (res < 0) res = 0;
        PlayerPrefs.SetInt(key, res);
        Upd();
    }

    public int GetMoney()
    {
        return count;
    }

    private void Upd()
    {
        if (PlayerPrefs.HasKey(key))
            count = PlayerPrefs.GetInt(key);
        text.text = count.ToString();
    }
}
