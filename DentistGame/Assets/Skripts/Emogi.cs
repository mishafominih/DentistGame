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
        int count = GetCountDirt("HardDirt") > 0 ? 1 : 0;
        count += GetCountDirt("Smell") > 0 ? 1 : 0;
        count += GetCountDirt("Dirt") > 0 ? 1 : 0;
        if (count == 1)
            renderer.sprite = GetSprite("Norm");
        if (count == 2)
            renderer.sprite = GetSprite("Sad1");
        if (count == 3)
            renderer.sprite = GetSprite("Shok");
    }

    int GetCountDirt(string tag)
    {
        var tags = dirts
            .Where(x => x.tag == tag)
            .Where(x => x.activeSelf);
        return tags == null ? 0 : tags.Count();
    }

    Sprite GetSprite(string name)
    {
        return Emogies.Where(x => x.name.Contains(name)).FirstOrDefault();
    }
}
