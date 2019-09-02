using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownGameObject : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y == limitY)
        {

        }
        else
        {
            transform.position -= new Vector3(0, 0.3f * Time.deltaTime);
        }

    }

    public float limitY;
}
