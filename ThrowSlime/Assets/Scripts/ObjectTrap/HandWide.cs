using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWide : MonoBehaviour
{
    private void Start() {
        character = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (isCheck)
        {
            arm.transform.rotation = Quaternion.LookRotation(Vector3.forward, (transform.position - character.transform.position) * -1);

            if (arm.transform.localScale.y <= 4.0f)
            {
                arm.transform.localScale += new Vector3(0,  Speed* Time.deltaTime, 0);
                hand.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        if(Time.timeScale <= 0){
             arm.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            character = other.gameObject;
        transform.rotation = other.transform.rotation;
        isCheck = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            temp = other.transform.rotation.z;
            transform.Rotate(new Vector3(0, 0, temp));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isCheck = false;
    }

    public float Speed;
    public GameObject hand;
    public GameObject arm;
    private GameObject character;
    private float temp;
    private bool isCheck = false;
}
