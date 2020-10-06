using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseBrash : MonoBehaviour
{
    private BoxCollider2D coll;
    private List<BoxCollider2D> dirts;
    private List<Timer> timers;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        dirts = GameObject
            .FindGameObjectsWithTag("Dirt")
            .Select(x => x.GetComponent<BoxCollider2D>())
            .ToList();
        timers = new List<Timer>(dirts.Count);
        for(int i = 0; i < dirts.Count; i++)
        {
            timers.Add(new Timer(1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < dirts.Count; i++)
        {
            if (dirts[i].bounds.Intersects(coll.bounds))
            {
                if (timers[i].Check())
                {
                    Destroy(dirts[i].gameObject);
                    dirts.RemoveAt(i);
                    timers.RemoveAt(i);
                    i--;
                }
            }
            else
            {
                timers[i].Null();
            }
        }
    }
}
