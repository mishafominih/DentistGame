using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    public List<Sprite>states;
    public List<Sprite> solidStates;
    public AudioClip goodFood;
    public AudioClip badFood;
    public int salary;
    public string solidFoodKey;
    public string breakTooth;
    public string key;

    private Money money;
    private int i = 2;
    private SpriteRenderer renderer;
    private bool isBreak = false;
    private int countFoodEatenRow;

    private const int ucciCoefficient = 50;

    void Start()
    {
        countFoodEatenRow = 0;
        renderer = GetComponent<SpriteRenderer>();
        money = Money.Instance;
        isBreak = PlayerPrefs.GetInt(breakTooth) > 0;
    }


    private void Update()
    {
        if (isBreak) {
            var sprite = solidStates[i];
            renderer.sprite = sprite;
        }
        else
        {
            renderer.sprite = states[i];
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(key, countFoodEatenRow);
    }

    public void Upd(string tag)
    {
        switch(tag)
        {
            case "good":
                Eating(1, salary, goodFood);
                countFoodEatenRow++;
                break;
            case "bad":
                Eating(-1, -salary, badFood);
                countFoodEatenRow = 0;
                break;
            case "solid":
                EatingSolidFood();
                break;
        }

        if (i < 0) i = 0;
        if (i > 4)
        {
            i = 4;
            if (isBreak)
                StateСhanges(false, 0);
        }
    }

    private void StateСhanges(bool changes, int value)
    {
        isBreak = changes;
        PlayerPrefs.SetInt(breakTooth, value);
    }

    private void EatingSolidFood()
    {
        if (PlayerPrefs.GetInt(solidFoodKey) > 0)
        {
            var rnd = new System.Random();
            var pseudoLuck = rnd.NextDouble() * 100;
            if (pseudoLuck > ucciCoefficient)
            {
                StateСhanges(true, 1);
                Eating(0, -10, goodFood);
            }
            else
                Eating(0, salary, goodFood);
        }    
    }

    private void Eating(int count, int salary, AudioClip music)
    {
        Music.PlayMusic(music);
        i += count;
        money.ChangeCount(salary);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Upd(collision.tag);
        Destroy(collision.gameObject);
    }
}
