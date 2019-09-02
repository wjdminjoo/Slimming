using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownStarObejct : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        if (ischeck)
        {
            transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime);
        }
        if (!ischeck)
        {
            transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime);
        }
        if(transform.localScale.y >= 1.3f)
            ischeck = true;
        if(transform.localScale.y <= 0.7f)
            ischeck = false;
    }

    public float rotationSpeed;
    private bool ischeck = false;
}
