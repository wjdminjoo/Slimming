using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    private void Start()
    {
        originY = transform.position.y;
    }

    private void Update()
    {
        if (ischeck)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Restart"))
        {
            ischeck = false;
            transform.position = new Vector3(transform.position.x, originY);
        }
    }

    public IEnumerator Restart()
    {
        yield return null;
        ischeck = false;
        transform.position = new Vector3(transform.position.x, originY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ischeck = true;
        }
    }

    public float speed;
    private bool ischeck = false;
    private float originY;
}
