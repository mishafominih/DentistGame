using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTool : MonoBehaviour
{
    public GameObject Tool;

    private GameObject btnTool;
    private GameObject canvas;
    private GameObject realTool;
    private bool touch;
    private BoxCollider2D btn;
    void Start()
    {
        btnTool = GameObject.FindGameObjectWithTag("Tool");
        btn = GetComponentInChildren<BoxCollider2D>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    void Update()
    {
        if (Input.touchCount > 0 && btn.bounds.Contains(Input.GetTouch(0).position) && !touch)
        {
            touch = true;
            realTool = Instantiate(Tool, canvas.transform);
            btnTool = GameObject.FindGameObjectWithTag("btnTool");
            btnTool.SetActive(false);
        }
        if (touch && Input.touchCount > 0)
        {
            realTool.transform.position = Input.GetTouch(0).position;
            realTool.transform.position += new Vector3(0, +200);
        }
        else if(touch)
        {
            Destroy(realTool);
            touch = false;
            btnTool.gameObject.SetActive(true);
        }
    }

    public GameObject GetToolNow()
    {
        return realTool;
    }

    public void SetTool(GameObject tool, GameObject btnTool)
    {
        Tool = tool;
        Destroy(this.btnTool);
        this.btnTool = Instantiate(btnTool, transform);
    }
}
