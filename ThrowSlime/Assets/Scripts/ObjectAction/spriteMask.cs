using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteMask : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<SpriteMask>().sprite = Resources.Load<Sprite>("Forest_object/" + gameObject.name);
    }

}
