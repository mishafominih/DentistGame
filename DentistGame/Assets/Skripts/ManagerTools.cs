using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTools : MonoBehaviour
{
    public List<GameObject> items;
    public List<GameObject> tools;


    public bool Check(GameObject gameObject)
    {
        var index = tools.FindIndex((x) => x == gameObject);
        if(items[index].GetComponentInChildren<OpenInstruments>() == null)
        {
            return true;
        }
        return false;
    }
}
