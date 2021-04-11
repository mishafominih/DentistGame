using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConversionScenes : MonoBehaviour
{
    public string NameScene;

    public void CreateSecene() => SceneManager.LoadScene(NameScene, LoadSceneMode.Single);
}

