using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DirOrigin : MonoBehaviour
{
     void Start()
    {
        PlayerPrefs.GetString("DirChange");
        GetComponent<Button>().onClick.AddListener(() => 
        { PlayerPrefs.SetString("DirChange", "true");});
    }
}
