using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirManager : MonoBehaviour
{
    void Update()
    {

        if (PlayerPrefs.GetString("DirChange") == "False")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
