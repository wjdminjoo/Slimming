using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInvisible : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Cursor.visible = false;
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        else if (Input.GetButtonDown("back") || Input.GetMouseButtonDown(2))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }else if(GateUI.ischeck){
             Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

}
