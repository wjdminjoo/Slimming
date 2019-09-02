using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectAnimSpriteMask : MonoBehaviour
{
 private void Start()
    {
        gameObject.tag = "wall";
        gameObject.GetComponent<SpriteMask>().sprite = Resources.Load<Sprite>("Object_Anime/" + gameObject.name);
    }
}
