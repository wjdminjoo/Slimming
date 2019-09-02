using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StageScript : MonoBehaviour
{
     private void Start() {
       sound = GameObject.Find("click").GetComponent<AudioSource>();
   }
   public void onClick(){
       SceneManager.LoadScene("Map");
       sound.Play();
   }
    public AudioSource sound;

}
