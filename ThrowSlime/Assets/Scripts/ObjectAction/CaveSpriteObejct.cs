using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSpriteObejct : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<SpriteMask>().sprite = Resources.Load<Sprite>("Cave_Object/" + gameObject.name);
        gameObject.tag = "wall";

    }
}
