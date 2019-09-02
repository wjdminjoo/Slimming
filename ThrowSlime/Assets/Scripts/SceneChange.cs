using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
 
    private void Awake() {
        scenecode = name;
        sound  = GameObject.Find("Sound/click");
        temp = transform.localScale;
    }

    
    public void onClick(){
    transform.localScale = new Vector3(1, 1, 1);
       sound.GetComponent<AudioSource>().Play();
       SceneManager.LoadScene(scenecode);

    }

    private string scenecode;
    private GameObject sound;
    private Vector3 temp;
   
}
