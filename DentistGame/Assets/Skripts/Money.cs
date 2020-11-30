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
        File.WriteAllText("money.txt", (count + d).ToString());
        Upd();
    }

    private void Upd()
    {
        text.text = File.ReadAllText("money.txt");
        count = int.Parse(text.text);
    }
}
