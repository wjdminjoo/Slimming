using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomalButton : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.GetString("Level");
        GetComponent<Button>().onClick.AddListener(() => 
        { PlayerPrefs.SetString("Level", "nomal");});
    }
}
