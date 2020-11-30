using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public float interval = 1;

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
        File.WriteAllText("money.txt", res.ToString());
        Upd();
    }

    public int GetMoney()
    {
        return count;
    }

    private void Upd()
    {
        text.text = File.ReadAllText("money.txt");
        count = int.Parse(text.text);
    }
}
