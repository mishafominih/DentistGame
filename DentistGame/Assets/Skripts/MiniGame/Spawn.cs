using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<Sprite> Good;
    public List<Sprite> Bad;
    public GameObject prefab;
    public Vector2 Left;
    public Vector2 Right;

    private Timer rate;
    // Start is called before the first frame update
    void Start()
    {
        rate = new Timer(2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (rate.Check())
        {
            var count = Random.Range(1, 3);
            for(int i = 0; i < count; i++)
            {
                var posX = Random.Range(Left.x, Right.x);
                var rand = Random.Range(0, 3) < 1;
                prefab.GetComponent<SpriteRenderer>().sprite = rand ?
                    Good[Random.Range(0, Good.Count)] :
                    Bad[Random.Range(0, Good.Count)];
                prefab.tag = rand ? "good" : "bad";
                Instantiate(prefab, new Vector3(posX, transform.position.y, 0), new Quaternion());
            }
            rate.Null();
        }
    }
}
