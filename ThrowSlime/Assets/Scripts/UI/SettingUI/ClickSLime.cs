using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSLime : MonoBehaviour
{
    public void OnClick(){
        audiosource = GameObject.Find("Sound/click");
        audiosource.GetComponent<AudioSource>().Play();
    }

    private GameObject audiosource;
}
