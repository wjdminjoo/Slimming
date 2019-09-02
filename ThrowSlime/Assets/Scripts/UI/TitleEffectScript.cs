using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEffectScript : MonoBehaviour
{

    private void Update()
    {

        if (time < Timer && !ischeck)
        {
            randX = Random.Range(-6.26f, 11.53f);
            randY = Random.Range(-3.25f, 6.94f);
            Instantiate(title[num], new Vector3(randX, randY, -num), Quaternion.identity);
            Timer = 0;
            num += 1;
        }
        if (num >= title.Length)
            num = 0;

        Timer += Time.deltaTime;
        if (num == 100 && !ischeck)
        {
            ischeck = true;
        }
    }
    public GameObject[] title;
    private short num = 0;
    private float time = 3.0f;
    private float Timer = 0;
    private float randX;
    private float randY;
    private bool ischeck = false;
}
