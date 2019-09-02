using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCrown : MonoBehaviour
{
    private void Start() {
        dirX = Random.Range(-55.0f, -45.0f);
        dirY = Random.Range(5.0f, 20.0f); 
    }
    private void Update() {
        transform.position = Vector3.Slerp(transform.position, new Vector3(dirX, dirY) , 5.0f * Time.deltaTime);
        if(Time.timeScale <= 0.0f && Input.GetMouseButtonDown(1) && Input.GetButtonDown("Restart")){
            transform.position = origin;
            gameObject.SetActive(false);
        }
        if(ischeck){
            gameObject.SetActive(false);
        }
    }
    public Vector3 origin;
    public bool ischeck = true;
    private float dirX; 
    private float dirY;
}
