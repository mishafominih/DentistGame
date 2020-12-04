using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDirt : MonoBehaviour
{
    List<GameObject> dirts;
    void Start()
    {
        dirts = new List<GameObject>();
        dirts.AddRange(GameObject.FindGameObjectsWithTag("HardDirt"));
        dirts.AddRange(GameObject.FindGameObjectsWithTag("Smell"));
        dirts.AddRange(GameObject.FindGameObjectsWithTag("Dirt"));
        GetState();
    }

    private void GetState()
    {
        foreach(var e in dirts)
        {
            bool isAvtive;
            if (PlayerPrefs.HasKey(e.name))
                isAvtive = PlayerPrefs.GetInt(e.name) != 0;
            else
            {
                PlayerPrefs.SetInt(e.name, 1);
                isAvtive = true;
            }
            e.SetActive(isAvtive);
        }
    }

    // Update is called once per frame
    public void ActiveDirt(bool update)
    {
        foreach (var d in dirts)
        {
            if (!d.activeSelf)
            {
                var active = Random.Range(0, 3) < 2;
                if (update)
                    d.SetActive(active);
                PlayerPrefs.SetInt(d.name, active ? 1 : 0);
            }
        }
    }
}
