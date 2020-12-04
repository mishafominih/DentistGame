using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if (Input.touchCount == 0) Destroy(gameObject);
        if (tooth.sprite.bounds.Intersects(coll.bounds))
        {
            if (timer.Check())
            {
                foreach(var g in GameObject.FindGameObjectsWithTag("Smell").Where(x => x.activeSelf))
                {
                    g.SetActive(false);
                    PlayerPrefs.SetInt(g.name, 0);
                }
            }
        }
    }
}
