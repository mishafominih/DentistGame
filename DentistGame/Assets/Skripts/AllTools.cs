using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllTools : MonoBehaviour
{
    public List<GameObject> Tools;

    private List<GameObject> OtherDesign;
    private List<GameObject> createdTools;
    private GameObject canvas;
    private void Start()
    {
        OtherDesign = new List<GameObject>();
        createdTools = new List<GameObject>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
    public void GetTools()
    {
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            var g = canvas.transform.GetChild(i).gameObject;
            if (g.layer != 8)
            {
                OtherDesign.Add(g);
                g.SetActive(false);
            }
        }
        for(int i = 0; i < Tools.Count; i++)
        {
            var item = Instantiate(Tools[i], canvas.transform);
            createdTools.Add(item);
            item.transform.position = new Vector3(525, 1600 - 250 * i);
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            bool flag = false;
            foreach (var tool in createdTools)
            {
                if (tool.GetComponent<BoxCollider2D>().bounds.Contains(Input.GetTouch(0).position))
                {
                    OtherDesign
                        .Where(x => x.GetComponent<GetTool>() != null)
                        .First()
                        .GetComponent<GetTool>()
                        .SetTool(tool.GetComponent<LinkTool>().Tool,
                            tool.GetComponent<LinkTool>().BtnTool);
                    GetDesign();
                    flag = true;
                }
            }
            if (flag)
            {
                createdTools.Clear();
                OtherDesign.Clear();
            }
        }
    }

    public void GetDesign()
    {
        foreach (var g in OtherDesign)
        {
            g.SetActive(true);
        }
        foreach (var g in createdTools)
        {
            Destroy(g);
        }
    }
}
