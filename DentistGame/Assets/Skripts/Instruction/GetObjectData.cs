using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetObjectData : MonoBehaviour
{
    public string nameInf;
    public string information;
    public GameObject windows;
    public Canvas canvas;
    public string fingTag;
    public string key;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.text = nameInf;
    }

    public void Click()
    {
        var x = GameObject.FindGameObjectsWithTag(fingTag)[0].GetComponentInChildren<Text>();
        var inf = windows.GetComponentInChildren<Text>();
        inf.text = x.text == "" ? information : "Вы не купили этот совет";
        var createWindows = Instantiate(windows, new Vector3(0, 0), new Quaternion());
        createWindows.transform.SetParent(canvas.transform, false);
        ReadInstruction(x);
    }

    private void ReadInstruction(Text x)
    {
        if (x.text == "")
        {
            var countRead = 1;
            if (PlayerPrefs.HasKey(key))
                countRead += PlayerPrefs.GetInt(key);
            PlayerPrefs.SetInt(key, countRead);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
