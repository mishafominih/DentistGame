using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public string tagBadFood;
    public List<GameObject> prefabs;

    private List<Vector3> PointsForSpawn = new List<Vector3>();
    private Timer rate;
    // Start is called before the first frame update
    void Start()
    {
        rate = new Timer(1.25f);
        for (int i = 0; i < transform.childCount; i++)
            PointsForSpawn.Add(transform.GetChild(i).position);
    }

    // Update is called once per frame
    void Update()
    {
        if (rate.Check())
        {
            var countElements = Random.Range(1, 3);
            for(int i = 0; i < countElements; i++)
            {
                var indexPos = Random.Range(0, PointsForSpawn.Count);
                var position = PointsForSpawn[indexPos];

                var indexPrefab = Random.Range(0, prefabs.Count);
                var prefab = prefabs[indexPrefab];
                if (prefab.tag == "bad" && PlayerPrefs.GetInt(tagBadFood) > 0)
                {
                    prefab.GetComponent<SpriteRenderer>().color = Color.gray;
                }
                Instantiate(prefab, position, new Quaternion());
            }
            rate.Null();
        }
    }
}
