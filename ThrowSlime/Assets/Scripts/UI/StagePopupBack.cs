using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class StagePopupBack : MonoBehaviour
{
    private void Start() {
       stagepopup = GameObject.FindGameObjectWithTag("StagePopup");
       sound = GameObject.Find("click").GetComponent<AudioSource>();

   }

    public void OnClick() {

       switch(EventSystem.current.currentSelectedGameObject.name){
           case "ForestBack":
           stagepopup.transform.GetChild(0).gameObject.SetActive(false);
           sound.Play();
           break;
            case "CaveBack":
           stagepopup.transform.GetChild(1).gameObject.SetActive(false);
           sound.Play();
           break;
            case "SeaBack":
           stagepopup.transform.GetChild(2).gameObject.SetActive(false);
           sound.Play();
           break;
            case "VolcanoBack":
           stagepopup.transform.GetChild(3).gameObject.SetActive(false);
           sound.Play();
           break;
            case "RuinsBack":
           stagepopup.transform.GetChild(4).gameObject.SetActive(false);
           sound.Play();
           break;

       }
   }
    private GameObject stagepopup;
    public AudioSource sound;

}
