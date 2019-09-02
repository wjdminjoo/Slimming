using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraSearch : MonoBehaviour
{
    private void Awake() {
        GetComponent<Canvas>().worldCamera  = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        GetComponent<Canvas>().sortingLayerName = "Foreground";
    }
}
