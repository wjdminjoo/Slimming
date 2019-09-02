using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodPackerTargetMove : MonoBehaviour
{
    private void Update() {
        if(woodPacker.transform.position.x - transform.position.x <= 0)
        transform.position = Vector3.Slerp(transform.position, target.position, 1.5f * Time.deltaTime);
    }
   public Transform target;
   public Transform woodPacker;
}
