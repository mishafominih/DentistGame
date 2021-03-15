using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTools : MonoBehaviour
{
    private bool hide = true;
    public ManagerTools managerTools;
    public GameObject tool;
    // Start is called before the first frame update
    void Start()
    {
        //managerTools = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ManagerTools>();
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
        if (managerTools.Check(g))
        {
            var createWindows = Instantiate(tool, managerTools.transform.parent);
            var link = transform.GetChild(0).GetComponent<LinkTool>();
            createWindows.GetComponent<GetTool>().SetTool(link.Tool, link.BtnTool);
            Destroy(managerTools.gameObject);
        }
    }
}
