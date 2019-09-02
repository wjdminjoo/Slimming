using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EasyButton : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.GetString("Level");
        GetComponent<Button>().onClick.AddListener(() => 
        { PlayerPrefs.SetString("Level", "easy");});
    }
}
