using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouthManager : MonoBehaviour
{
    public int StartChance = 100;
    private const string SAVE_CHANCE = "PlacementStartChance";
    private List<Vector3> startPositions;
    private List<GameObject> tooths;
    // Start is called before the first frame update
    void Start()
    {
        tooths = GameObject.FindGameObjectsWithTag("Tooth").ToList();
        startPositions = tooths
            .Select(x => x.transform.position)
            .ToList();
        var chance = PlayerPrefs.GetInt(SAVE_CHANCE);
        if (chance < StartChance) StartChance = chance;
        randomTooth(0, tooths.Count / 2);
        randomTooth(tooths.Count / 2, tooths.Count);
    }

    private void randomTooth(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            for (int j = start; j < end && j != i; j++)
            {
                var tooth1 = tooths[i];
                var tooth2 = tooths[j];
                if (Random.Range(0, StartChance) < 1)
                {
                    swapPosition(tooth1, tooth2);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var greenTouth = tooths
            .Where(x => x.GetComponent<SpriteRenderer>().color == Color.green)
            .ToList();
        if (greenTouth.Count == 2)
        {
            swapPosition(greenTouth[0], greenTouth[1]);
            greenTouth.ForEach(x =>
            {
                x.GetComponent<SpriteRenderer>().color = Color.white;
            });
        }
        for (int i = 0; i < tooths.Count; i++)
        {
            var toothPos = tooths[i].transform.position;
            var startPos = startPositions[i];
            if (Mathf.Abs(Mathf.Abs(startPos.x) - Mathf.Abs(toothPos.x)) > 0.1 ||
                Mathf.Abs(Mathf.Abs(startPos.y) - Mathf.Abs(toothPos.y)) > 0.1)
                return;
        }
        PlayerPrefs.SetInt(SAVE_CHANCE, StartChance - 10 > 0 ? StartChance - 10 : 5);
        SceneManager.LoadScene(7);
    }

    private static void swapPosition(GameObject first, GameObject second)
    {
        var savePos = second.transform.position;
        second.transform.position = first.transform.position;
        first.transform.position = savePos;
        var firstRenderer = first.GetComponent<SpriteRenderer>();
        var secondRenderer = second.GetComponent<SpriteRenderer>();
        var order = secondRenderer.sortingOrder;
        secondRenderer.sortingOrder = firstRenderer.sortingOrder;
        firstRenderer.sortingOrder = order;
    }

}
