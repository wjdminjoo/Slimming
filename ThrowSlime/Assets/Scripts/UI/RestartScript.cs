using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
   private void Start() {
       sound = GameObject.Find("click").GetComponent<AudioSource>();
   }
   public void onClick(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       sound.Play();
       stopWatch.stopwatch.Restart();

   }
    public AudioSource sound;
}
