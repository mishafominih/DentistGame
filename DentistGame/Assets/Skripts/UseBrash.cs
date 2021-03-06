﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseBrash : MonoBehaviour
{
    public GameObject Effect;
    public AudioClip cleaning;
    public int salary;

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
            .Where(x => x.activeSelf)
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
    //    if (Input.touchCount == 0) Destroy(gameObject);
        bool isCleaning = false;
        for(int i = 0; i < dirts.Count; i++)
        {
            if (dirts[i].bounds.Intersects(coll.bounds))
            {
                isCleaning = true;
                Music.PlayCleaningMusic(cleaning);
                if (timers[i].Check())
                {
                    dirts[i].gameObject.SetActive(false);
                    PlayerPrefs.SetInt(dirts[i].name, 0);
                    dirts.RemoveAt(i);
                    timers.RemoveAt(i);
                    i--;
                    Work();
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

    private void Work()
    {
        var money = Money.Instance;
        var coefficient = PlayerPrefs.HasKey("moneyCoefficient") ? PlayerPrefs.GetInt("moneyCoefficient") : 1;
        money.ChangeCount(salary * coefficient);
    }

    public bool IsClean()
    {
        return dirts.Count == 0;
    }
}
