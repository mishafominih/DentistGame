using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    private SpriteRenderer player;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        speed = Random.Range(0.04f, 0.1f);
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.bounds.Intersects(GetComponent<SpriteRenderer>().bounds))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<States>().Upd(tag == "good");
            Destroy(gameObject);
        }
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - speed,
            transform.position.z);
    }
}
