using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static Points Instance;

    private Text text;
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void AddPoint()
    {
        var strs = text.text.Split(' ');
        var points = int.Parse(strs[1]);
        points++;
        text.text = strs[0] + ' ' + points.ToString();
    }
}
