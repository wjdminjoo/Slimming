using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    void Start()
    {
        childGameObject = gameObject.GetComponentsInChildren<Image>();
        PlayerPrefs.GetInt("PlayerState");
    }

    void Update()
    {
        switch (PlayerPrefs.GetInt("PlayerState"))
        {
            case 0:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[0].GetComponent<Image>().enabled = true;
                break;
            case 1:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[1].GetComponent<Image>().enabled = true;
                break;
            case 2:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[2].GetComponent<Image>().enabled = true;
                break;
            case 3:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[3].GetComponent<Image>().enabled = true;
                break;
            case 4:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[4].GetComponent<Image>().enabled = true;
                break;
            case 5:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[5].GetComponent<Image>().enabled = true;
                break;
            case 6:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[6].GetComponent<Image>().enabled = true;
                break;
            case 7:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[7].GetComponent<Image>().enabled = true;
                break;
            case 8:
                for (int i = 0; i < childGameObject.Length; i++)
                    childGameObject[i].GetComponent<Image>().enabled = false;
                childGameObject[8].GetComponent<Image>().enabled = true;
                break;
        }
    }



    private Image[] childGameObject;
}
