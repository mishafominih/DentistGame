using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTools : MonoBehaviour
{
    private bool hide = true;
    // Start is called before the first frame update
    void Start()
    {
        HideBtnTool();
        Touch();
    }

    public void Touch()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.tag == "Interface")
                child.gameObject.SetActive(hide);
            if(child.tag == "toolsInterface")
                child.gameObject.SetActive(!hide);
        }
        hide = !hide;
        HideBtnTool();
    }

    private void HideBtnTool()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.tag == "btnInterface")
                child.gameObject.SetActive(false);
        }
    }

    public void ViewBtnTool(GameObject g)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.tag == "btnInterface")
            {
                child.gameObject.SetActive(true);

                var link = g.GetComponentInChildren<LinkTool>();
                child.gameObject.GetComponent<GetTool>().SetTool(link.Tool, link.BtnTool);
            }
            else
                child.gameObject.SetActive(false);
        }
    }
}
