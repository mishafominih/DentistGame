using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInstruments : MonoBehaviour
{
    public GameObject windows;
    public GameObject backWindows;
    public void ExitOfWindow()
    {
        var createWindows = Instantiate(backWindows, transform.parent.parent);
        Destroy(windows);
    }
}
