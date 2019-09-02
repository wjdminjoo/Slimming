using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerStoreSelect : MonoBehaviour
{
    private void Start() {
        PlayerPrefs.GetInt("PlayerState", 0);
        GetComponent<Button>().onClick.AddListener(() => { PlayerPrefs.SetInt("PlayerState", int.Parse(EventSystem.current.currentSelectedGameObject.name));});

    }

}
