using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ManagerTools : MonoBehaviour
{
    private List<Transform> items;
    private List<GameObject> tools;
    public GameObject data;

    private void Start()
    {
        var toolsInterface = data.GetComponentsInChildren<Transform>().Where(x => x.tag == "toolsInterface");
        tools = toolsInterface.Where(x => x.name.Contains("Instrument")).Select(x => x.gameObject).ToList();
        items = toolsInterface.Where(x => x.name.Contains("Cost")).ToList();
    }

    public bool Check(GameObject gameObject)
    {
        var index = tools.FindIndex((x) => x.name == gameObject.name);
        if (items[index].GetComponentInChildren<OpenInstruments>() == null)
        {
            return true;
        }
        return false;
    }
}
