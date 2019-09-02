using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerSpriteMask : MonoBehaviour
{
       private void Start()
    {
        gameObject.GetComponent<SpriteMask>().sprite = Resources.Load<Sprite>("Forest_Flower/" + gameObject.name);
        gameObject.tag = "wall";
    }
}
