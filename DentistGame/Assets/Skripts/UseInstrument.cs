using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseInstrument : MonoBehaviour
{
    public float TimerAlive = 1;

    private static UseInstrument Instance;
    private float timer = 0;
    private Camera camera;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.touchCount > 0)
        {
            timer = 0;
            transform.position = camera.ScreenToWorldPoint(Input.GetTouch(0).position);
            transform.position += new Vector3(0, 1, -transform.position.z);
        }
        else if(timer > TimerAlive)
        {
            Destroy(gameObject);
        }
    }
}
