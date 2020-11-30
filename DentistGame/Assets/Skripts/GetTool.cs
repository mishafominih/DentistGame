using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetTool : MonoBehaviour
{
    public GameObject Tool;

    private Camera camera;
    private GameObject btnTool;
    private GameObject realTool;
    private bool touch;
    private BoxCollider2D btn;
    void Start()
    {
        btnTool = GetComponentInChildren<LinkTool>() == null ? null : GetComponentInChildren<LinkTool>().gameObject;
        btn = GetComponentInChildren<BoxCollider2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchCount > 0 &&
            btn.bounds.Contains(Input.GetTouch(0).position) && !touch)
        {
            btnTool = GetComponentInChildren<LinkTool>() == null ? null : GetComponentInChildren<LinkTool>().gameObject;
            if (btnTool == null) return;
            btnTool.SetActive(false);
            touch = true;
            realTool = Instantiate(Tool);
        }
        if (touch && Input.touchCount > 0)
        {
            realTool.transform.position = camera.ScreenToWorldPoint(Input.GetTouch(0).position);
            realTool.transform.position += new Vector3(0, 1, -realTool.transform.position.z);
        }
        else if (touch)
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
