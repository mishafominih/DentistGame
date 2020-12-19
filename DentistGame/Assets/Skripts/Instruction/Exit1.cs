using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit1 : MonoBehaviour
{
    public GameObject windows;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void ExitOfWindow()
    {
        Destroy(windows);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
