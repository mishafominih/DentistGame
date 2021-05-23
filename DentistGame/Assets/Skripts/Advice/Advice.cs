using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Advice : MonoBehaviour
{
    public GameObject tooth;
    public List<string> advices;

    private Text text;
    private SpriteRenderer renderer;
    private int index;
    private GameObject[] dirts;
    private GameObject[] hardDirts;
    private GameObject[] smell;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        dirts = GetDirt("Dirt");
        hardDirts = GetDirt("HardDirt");
        smell = GetDirt("Smell");
    }

    private GameObject[] GetDirt(string tag) => GameObject.FindGameObjectsWithTag(tag);
 

    // Update is called once per frame
    void Update()
    {
        //if (NextAdvice(dirts))
        //    index = 1;
        //else if (NextAdvice(hardDirts))
        //    index = 2;
        
        //text.text = advices[index];
    }

    private bool NextAdvice(GameObject[] dirts)
    {
        foreach(var e in dirts)
        {
            if (e.activeSelf)
                return false;
        }
        return true;
    }
}
