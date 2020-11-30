using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    public List<Sprite>states;

    private int i = 2;
    private SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        renderer.sprite = states[i];
    }

    public void Upd(bool n)
    {
        if (n == true)
            i++;
        else
            i--;
        if (i < 0) i = 0;
        if (i > 4) i = 4;
    }
}
