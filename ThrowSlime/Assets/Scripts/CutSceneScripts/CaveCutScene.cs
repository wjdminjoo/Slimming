using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCutScene : MonoBehaviour
{
   private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        if(!isCutSceneCave){
            animator.SetBool("isCheck", true);
            StartCoroutine(isCutSceneCaveCor());
        }else{
            gameObject.SetActive(false);
        }
    }


    IEnumerator isCutSceneCaveCor(){
        yield return new WaitForSeconds(9.0f);
        isCutSceneCave = true;
    }





    private Animator animator;
    public static bool isCutSceneCave = false;
}
