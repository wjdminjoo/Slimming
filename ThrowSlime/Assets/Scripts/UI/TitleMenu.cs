using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
     private void Start() {
       sound = GameObject.Find("click").GetComponent<AudioSource>();
   }
    public void onClick(){
       SceneManager.LoadScene("Title");
       sound.Play();
   }
    public AudioSource sound;
}
