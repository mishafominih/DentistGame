using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Emogi : MonoBehaviour
{
    public List<Sprite> Emogies;

    private List<GameObject> dirts;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        dirts = new List<GameObject>();
        dirts.AddRange(GameObject.FindGameObjectsWithTag("Dirt"));
        dirts.AddRange(GameObject.FindGameObjectsWithTag("HardDirt"));
        dirts.AddRange(GameObject.FindGameObjectsWithTag("Smell"));
    }

    // Update is called once per frame
    void Update()
    {
        renderer.sprite = GetSprite("Happy");
        if (GetCountDirt("HardDirt") > 0)
            renderer.sprite = GetSprite("Norm");
        if (GetCountDirt("Smell") > 0)
            renderer.sprite = GetSprite("Sad1");
        if (GetCountDirt("Dirt") > 0)
            renderer.sprite = GetSprite("Shok");
    }

    int GetCountDirt(string tag)
    {
        dirts = dirts.Where(x => x != null).ToList();
        return dirts.Where(x => x.tag == tag).Count();
    }

    Sprite GetSprite(string name)
    {
        return Emogies.Where(x => x.name.Contains(name)).FirstOrDefault();
    }
}
