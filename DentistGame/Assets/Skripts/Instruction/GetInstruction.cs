using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInstruction : MonoBehaviour
{
    public string nameInf;
    public string information;
    public GameObject windows;
    public Canvas canvas;
    public string fingTag;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
