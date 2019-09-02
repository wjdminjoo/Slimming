using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestCutScene : MonoBehaviour
{
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        if(!isCutSceneForest){
            animator.SetBool("isCheck", true);
            StartCoroutine(isCutSceneForestCor());
        }else{
            gameObject.SetActive(false);
        }
    }


    IEnumerator isCutSceneForestCor(){
        yield return new WaitForSeconds(9.0f);
        isCutSceneForest = true;
    }





    private Animator animator;
    public static bool isCutSceneForest = false;
}
