using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZoomSetting : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.GetString("Zoom");
        GetComponent<Button>().onClick.AddListener(() => 
        { PlayerPrefs.SetString("Zoom", "False");});
    }


}
