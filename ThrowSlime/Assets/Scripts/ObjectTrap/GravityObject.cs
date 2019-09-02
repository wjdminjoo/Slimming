using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) {
       if(other.CompareTag("Player")){
           other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1f;
       }
   }

   private void OnTriggerExit2D(Collider2D other) {
       if(other.CompareTag("Player")){
           other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
       }
   }
}
