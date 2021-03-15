using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInstuments : MonoBehaviour
{
    public GameObject windows;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Click()
    {
        var createWindows = Instantiate(windows, new Vector3(0, 0), new Quaternion());
        createWindows.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
