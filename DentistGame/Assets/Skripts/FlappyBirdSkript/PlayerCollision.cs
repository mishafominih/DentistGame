using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            StartCoroutine(Coroutine());
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        if (collision.tag == "Fruit")
        {
            Points.Instance.AddPoint();
            Money.Instance.ChangeCount(25);
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
