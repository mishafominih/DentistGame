using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    public List<Sprite>states;
    public AudioClip goddFood;
    public AudioClip badFood;

    private Money money;
    private int i = 2;
    private SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        money = Money.Instance;
    }


    private void Update()
    {
        renderer.sprite = states[i];
    }

    public void Upd(bool n)
    {
        if (n)
        {
            Music.PlayMusic(goddFood);
            i++;
            money.ChangeCount(20);
        }
        else
        {
            Music.PlayMusic(badFood);
            i--;
            money.ChangeCount(-1);
        }

        if (i < 0) i = 0;
        if (i > 4) i = 4;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Upd(collision.tag == "good");
        Destroy(collision.gameObject);
    }
}
