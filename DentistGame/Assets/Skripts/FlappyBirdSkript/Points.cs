using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static Points Instance;

    public int points { get; private set; }
    private Text text;
    private const string MAX_POINTS = "MaxPoints";
    private string startText;
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        text = GetComponent<Text>(); 
        startText = text.text.Split(' ')[0];
        SetText();
    }

    public void AddPoint()
    {
        points++;
        SetText();
    }

    private void SetText()
    {
        text.text = startText + ' ' + points.ToString() + " | " + PlayerPrefs.GetInt(MAX_POINTS);
    }

    public void CheckResult()
    {
        if (points > PlayerPrefs.GetInt(MAX_POINTS))
        {
            PlayerPrefs.SetInt(MAX_POINTS, points);
        }
    }
}
