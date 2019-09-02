using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StageTextScript : MonoBehaviour
{

    private void Start()
    {
        text = GetComponent<Text>();
        string temp = Application.loadedLevelName;
        text.text = temp;
    }
    
    private Text text;
}
