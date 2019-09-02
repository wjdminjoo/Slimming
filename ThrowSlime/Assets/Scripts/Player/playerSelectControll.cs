using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterID
{
    PLAYERS,
    COPS,
    EXPLORER,
    HUNTER,
    MAGICIAN,
    PIRATES,
    SANTA,
    COOKER
}


public class playerSelectControll : MonoBehaviour
{
    private void Awake()
    {
        childeObject = new GameObject[transform.childCount];
        
        
    }
    private void Start()
    {
         for (int i = 0; i < transform.childCount; i++)
        {
            childeObject[i] = transform.GetChild(i).gameObject;
            childeObject[i].SetActive(false);
        }
        PlayerPrefs.GetString("PlayerState");
       
        childeObject[PlayerPrefs.GetInt("PlayerState")].SetActive(true);
    }
   
    private short characterNum;
    private GameObject[] childeObject;
}
