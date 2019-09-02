using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class StageSelectScript : MonoBehaviour
{
   private void Start() {
       stagepopup = GameObject.FindGameObjectWithTag("StagePopup");
       sound = GameObject.Find("pop").GetComponent<AudioSource>();

   }

    public void OnClick() {

       switch(EventSystem.current.currentSelectedGameObject.name){
           case "Forest":
           stagepopup.transform.GetChild(0).gameObject.SetActive(true);
           sound.Play();
           break;
           case "Cave":
           stagepopup.transform.GetChild(1).gameObject.SetActive(true);
           sound.Play();
           break;
           case "Sea":
           stagepopup.transform.GetChild(2).gameObject.SetActive(true);
           sound.Play();
           break;
           case "Volcano":
           stagepopup.transform.GetChild(3).gameObject.SetActive(true);
           sound.Play();
           break;
           case "Ruins":
           stagepopup.transform.GetChild(4).gameObject.SetActive(true);
           sound.Play();
           break;

       }
   }

   private GameObject stagepopup;
    public AudioSource sound;

}
