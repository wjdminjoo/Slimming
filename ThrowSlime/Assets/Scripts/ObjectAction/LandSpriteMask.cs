using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpriteMask : MonoBehaviour
{
      private void Start()
    {
        gameObject.GetComponent<SpriteMask>().sprite = Resources.Load<Sprite>("Land/" + gameObject.name);
        if(gameObject.tag == null)
        gameObject.tag = "wall";

    }

}
