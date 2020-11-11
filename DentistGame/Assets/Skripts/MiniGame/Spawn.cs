using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> Objects;
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
                Instantiate(Objects.OrderBy(x => Random.Range(-1, 1)).FirstOrDefault(), 
                    new Vector3(posX, transform.position.y, 0), 
                    new Quaternion());
            }
            rate.Null();
        }
    }
}
