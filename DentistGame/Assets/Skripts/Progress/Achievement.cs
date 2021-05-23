using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public string key;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(key))
        {
            var data = PlayerPrefs.GetInt(key);
            if (data >= count)
                OpenAchievement();
        }
    }

    private void OpenAchievement()
    {
        var image = GetComponentsInChildren<Image>().ToList();
        image.ForEach(x => x.color = new Color(255, 255, 255, 255));
    }
}
