using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTool : MonoBehaviour
{
    public GameObject Brush;

    private GameObject canvas;
    private GameObject realBrush;
    private bool click;
    private BoxCollider2D btn;
    void Start()
    {
        btn = GetComponentInChildren<BoxCollider2D>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    void Update()
    {
        if (Input.touchCount > 0 && btn.bounds.Contains(Input.GetTouch(0).position))
        {
            click = true;
            realBrush = Instantiate(Brush, canvas.transform);
            btn.gameObject.GetComponent<Image>().enabled = false;
            btn.enabled = false;
        }
        if (click && Input.touchCount > 0)
        {
            realBrush.transform.position = Input.GetTouch(0).position;
            realBrush.transform.position += new Vector3(0, +200);
        }
        else
        {
            Destroy(realBrush);
            click = false;
            btn.gameObject.GetComponent<Image>().enabled = true;
            btn.enabled = true;
        }
    }
}
