using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceObject : MonoBehaviour
{

    private void Start()
    {
        collider2d = GetComponent<CircleCollider2D>();
        child = transform.GetChild(0).GetComponent<Transform>();
        otherObject = new GameObject();
    }

    private void Update() {
        if(ischeck){
          child.transform.rotation = Quaternion.LookRotation(Vector3.forward, (transform.position - otherObject.transform.position) * -1);
          if(child.transform.localScale == new Vector3(1, 3, 1))
          child.transform.localScale += new Vector3(0, 1 * Time.deltaTime, 0);
          }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ischeck = true;
            otherObject.transform.position = other.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        ischeck = false;
         child.transform.localScale = new Vector3(1, 1, 1);
    }

    public static float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
    }
    private GameObject otherObject;
    private Transform child;
    private CircleCollider2D collider2d;
    private bool ischeck;
}
