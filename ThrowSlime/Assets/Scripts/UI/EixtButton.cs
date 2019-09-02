using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EixtButton : MonoBehaviour
{
    public void onClick(){
        transform.localScale = new Vector3(1, 1, 1);
        Application.Quit();
    }
}
