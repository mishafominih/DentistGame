using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseBrash : MonoBehaviour
{
    public GameObject Effect;

    private GameObject realEffect;
    private BoxCollider2D coll;
    private List<BoxCollider2D> dirts;
    private List<Timer> timers;
    void Start()
    {
        realEffect = Instantiate(Effect, gameObject.transform);
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
        bool isCleaning = false;
        for(int i = 0; i < dirts.Count; i++)
        {
            if (dirts[i].bounds.Intersects(coll.bounds))
            {
                isCleaning = true;
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
        if (isCleaning) {
            realEffect.SetActive(true);
        }
        else
        {
            realEffect.SetActive(false);
        }
    }

    public bool IsClean()
    {
        return dirts.Count == 0;
    }
}
