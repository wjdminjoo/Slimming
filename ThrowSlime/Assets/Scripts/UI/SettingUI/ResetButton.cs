using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
   private void Start() {
            GetComponent<Button>().onClick.AddListener(() => { PlayerPrefs.DeleteAll(); });
       
   }
}
