using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDirt : MonoBehaviour
{
    List<GameObject> dirts;
    void Start()
    {
        //gameObject.SetActive(true);
        dirts = new List<GameObject>();
        dirts.AddRange(GameObject.FindGameObjectsWithTag("HardDirt"));
        dirts.AddRange(GameObject.FindGameObjectsWithTag("Smell"));
        dirts.AddRange(GameObject.FindGameObjectsWithTag("Dirt"));
    }

    // Update is called once per frame
    public void ActiveDirt(bool save)
    {
        foreach (var d in dirts)
        {
            if(!d.activeSelf)
                d.SetActive(Random.Range(0, 3) <= 1);
        }
        if (save)
        {
            //gameObject.SetActive(false);
            //DontDestroyOnLoad(gameObject);
        }
    }
}
