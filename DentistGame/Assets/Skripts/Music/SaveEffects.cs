using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().enabled = PlayerPrefs.GetInt("Effects") == 1;  
    }
}
