using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update() {
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.transform.position, targetPos, smooth * Time.unscaledDeltaTime* 50);
        }


    }
    public void camerashake(float mount, float time)
    {
        originPos = transform.localPosition;
        StartCoroutine(shake(mount, time));
    }
    public void stopShake()
    {
        StopCoroutine(shake(0, 0));
    }
    IEnumerator shake(float mount, float time)
    {
        shakeTimer = 0.0f;
        while (shakeTimer <= time)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * mount + originPos;
            shakeTimer += Time.fixedDeltaTime;
            yield return null;
        }
        transform.localPosition = originPos;
    }


    [HideInInspector] public float shakeTimer;
    public Vector2 minPos;
    public Vector2 maxPos;
    public float smooth;
    private Transform target;
    private Vector3 originPos;

}
