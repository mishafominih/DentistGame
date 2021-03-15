using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Interval = 0.5f;
    public float Force = 25;

    Rigidbody2D rb;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            if (timer >= Interval)
            {
                timer = 0;
                rb.AddForce(new Vector2(0, Force));
            }
        }
    }
}
