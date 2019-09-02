using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverAlpha : MonoBehaviour
{
    
    void Update()
    {
        GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
    }
}
