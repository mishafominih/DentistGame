using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskDispetcher : MonoBehaviour
{
    public GameObject Tool;

    private Text text;
    private List<string> tasks;
    void Start()
    {
        text = GetComponentInChildren<Text>();
        tasks = new List<string>()
        {
            "Возьмите щетку",
            "Очистите зуб"
        };
        text.text = tasks[0];
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GetTaskBrush(Tool.GetComponent<GetTool>().GetToolNow());
    }

    private string GetTaskBrush(GameObject getTool)
    {
        if (getTool != null && getTool.tag == "Brash")
        {
            if (getTool.GetComponent<UseBrash>().IsClean())
            {
                return "";
            }
            else
            {
                return "Очистите зуб";
            }
        }
        return "Возьмите щетку";
    }
}
