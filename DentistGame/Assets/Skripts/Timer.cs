using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer// : MonoBehaviour
{
    float timer = 0;
    float time;
    public Timer(float time)
    {
        this.time = time;
    }

    public float GetTime()
    {
        return timer > time ? time : timer;
    }

    public bool Check()
    {
        if(timer > time)
        {
            return true;
        }
        timer += Time.deltaTime;
        return false;
    }

    public void Null()
    {
        timer = 0;
    }
}
