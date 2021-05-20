using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouch : MonoBehaviour
{
    private static int maxLayer = 0;
    PolygonCollider2D sprite;
    public Camera cam;
    private bool isMine = false;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Vector3 touch = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (sprite.OverlapPoint(touch))
            {
                isMine = true;
                int sortingOrder = spriteRenderer.sortingOrder;
                if (sortingOrder > maxLayer)
                {
                    maxLayer = spriteRenderer.sortingOrder;
                }
            }
        }
        else
        {
            if (isMine && GetComponent<SpriteRenderer>().sortingOrder == maxLayer)
            {
                if (spriteRenderer.color == Color.green)
                {
                    spriteRenderer.color = Color.white;
                }
                else
                {
                    spriteRenderer.color = Color.green;
                }
                maxLayer = 0;
            }
            isMine = false;
        }
    }
}
