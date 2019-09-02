using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelup : MonoBehaviour
{
    private void Update() {
        if (Input.GetButtonDown("Restart")&& !GateUI.ischeck || Input.GetMouseButtonDown(1) && !GateUI.ischeck)
        {
            for(int i = 0; i < levelup.Length; i++){
                levelup[i].SetActive(true);
            }
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
    
    public IEnumerator Restart(){
        yield return null;
         for(int i = 0; i < levelup.Length; i++){
             if(levelup[i].activeSelf == false)
                levelup[i].SetActive(true);
            }
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Levelup")){
            other.gameObject.SetActive(false);
            gameObject.transform.localScale += new Vector3(0.2f, 0.2f);
        }
    }

    public GameObject[] levelup;
}
