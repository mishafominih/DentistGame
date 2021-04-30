using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip flip;

    public float Interval = 0.5f;
    public float Force = 25;
    public float AngleUp = -60;
    public float AngleDown = -120;

    Rigidbody2D rb;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var pos = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(pos.x, pos.y, AngleDown);
        timer = Interval;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            if (timer >= Interval)
            {
                Music.PlayMusic(audioSource, flip);
                timer = 0;
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(0, Force));
            }
        }
        ChangeRotate();
    }

    private void ChangeRotate()
    {
        var pos = transform.rotation.eulerAngles;
        if (timer >= Interval)
            transform.rotation = Quaternion.Euler(pos.x, pos.y, AngleDown);
        else
            transform.rotation = Quaternion.Euler(pos.x, pos.y, AngleUp);
    }
}
