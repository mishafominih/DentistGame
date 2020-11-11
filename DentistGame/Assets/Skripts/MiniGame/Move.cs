using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            var pos = camera.ScreenToWorldPoint(Input.GetTouch(0).position);
            transform.position = new Vector3(pos.x,
                transform.position.y, transform.position.z);

        }
    }
}
