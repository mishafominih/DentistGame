using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseDentallFlos : MonoBehaviour
{
    private BoxCollider2D coll;
    private List<BoxCollider2D> dirts;
    private List<Timer> timers;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        dirts = GameObject
            .FindGameObjectsWithTag("HardDirt")
            .Where(x => x.activeSelf)
            .Select(x => x.GetComponent<BoxCollider2D>())
            .ToList();
        timers = new List<Timer>(dirts.Count);
        for (int i = 0; i < dirts.Count; i++)
        {
            timers.Add(new Timer(2));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) Destroy(gameObject);
        for (int i = 0; i < dirts.Count; i++)
        {
            if (dirts[i].bounds.Intersects(coll.bounds))
            {
                if (timers[i].Check())
                {
                    dirts[i].gameObject.SetActive(false);
                    PlayerPrefs.SetInt(dirts[i].name, 0);
                    dirts.RemoveAt(i);
                    timers.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
