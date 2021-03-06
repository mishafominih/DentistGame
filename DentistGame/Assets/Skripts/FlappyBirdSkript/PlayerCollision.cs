﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip goodFood;
    public AudioClip endGame;
    public int salary;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Music.PlayMusic(endGame);
            StartCoroutine(Coroutine());
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            Points.Instance.CheckResult();
        }
        if (collision.tag == "Fruit")
        {
            Music.PlayMusic(goodFood);
            Points.Instance.AddPoint();
            Money.Instance.ChangeCount(salary);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2.5f);
        ReloadScene();
    }

    private static void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
