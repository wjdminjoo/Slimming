using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomThrow : MonoBehaviour
{
    private void Update()
    {
        RandX = Random.Range(-20.0f, 20.0f);
        RandY = Random.Range(-20.0f, 20.0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            StartCoroutine(RnadomCor());
        }
    }

    IEnumerator RnadomCor()
    {
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(RandX, RandY);
    }

    private float RandX;
    private float RandY;
    private GameObject player;

}
