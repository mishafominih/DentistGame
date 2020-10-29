using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseToothPaste : MonoBehaviour
{
    SpriteRenderer tooth;
    BoxCollider2D coll;
    Timer timer;
    void Start()
    {
        tooth = GameObject.FindGameObjectWithTag("Tooth").GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        timer = new Timer(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (tooth.sprite.bounds.Intersects(coll.bounds))
        {
            if (timer.Check())
            {
                foreach(var g in GameObject.FindGameObjectsWithTag("Smell"))
                {
                    Destroy(g);
                }
            }
        }
    }
}
