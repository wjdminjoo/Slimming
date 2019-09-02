using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveScript : MonoBehaviour
{
    private void Start()
    {
        randomRo = Random.Range(0, 20);
    }

    private void Update()
    {
        transform.localScale += new Vector3(3.0f, 3.0f, 0.0f) * Time.deltaTime;
        if (randomRo > 10)
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), randomRo * Time.deltaTime, Space.World);
        else
            transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f), randomRo * Time.deltaTime, Space.World);

    }
    private float randomRo;
}
