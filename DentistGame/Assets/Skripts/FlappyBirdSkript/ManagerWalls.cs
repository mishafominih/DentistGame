using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWalls : MonoBehaviour
{
    public List<GameObject> MultiWalls;
    public float distanse = 2f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = distanse;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > distanse)
        {
            timer = 0;
            var index = Random.Range(0, MultiWalls.Count);
            var obj = MultiWalls[index];
            Instantiate(obj, transform.position, new Quaternion());
        }
    }
}
