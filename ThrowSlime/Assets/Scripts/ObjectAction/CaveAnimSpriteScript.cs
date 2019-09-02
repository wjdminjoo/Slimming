using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveAnimSpriteScript : MonoBehaviour
{
       private void Start()
    {
        gameObject.GetComponent<SpriteMask>().sprite = Resources.Load<Sprite>("Cave_Object/Cave_Ani" + gameObject.name);
        gameObject.tag = "wall";

    }
}
