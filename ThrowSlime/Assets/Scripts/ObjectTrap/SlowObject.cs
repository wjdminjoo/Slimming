using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlowObject : MonoBehaviour
{
   private void Start() {
       collider2D = GetComponent<CircleCollider2D>();
   }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Time.timeScale = 0.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
            Time.timeScale = 1.0f;        
    }

   private CircleCollider2D collider2D;
}
