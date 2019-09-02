using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodPacker : MonoBehaviour
{
    private void Start()
    {
        animator = GetComponent<Animator>();
        uiobject = GameObject.FindGameObjectWithTag("UIPopup");
        uiobject.SetActive(false);
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSmooth>();
        StartCoroutine(checkStartCor());
    }
    private void Update()
    {
        if (Input.GetButtonDown("Restart") || Input.GetMouseButtonDown(1) || Time.timeScale <= 0.0f)
        {
            leaf.gameObject.SetActive(false);
            feather.gameObject.SetActive(false);
            transform.position = new Vector3(originTran.position.x, originTran.position.y);
            animator.SetBool("fly", false);
            StartCoroutine(restart());
        }

        if (isLeafcheck)
        {
            leaf.gameObject.SetActive(true);
            StartCoroutine(checkLeafCor());
            isLeafcheck = false;
        }

        if (isFeathergcheck)
        {
            feather.gameObject.SetActive(true);
            StartCoroutine(checkFeatherCor());
            isFeathergcheck = false;
        }

        if (ischeckLevel2)
        {
            StartCoroutine(checkLevel2Cor());
            leaf.Stop();
            ischeckLevel2 = false;
        }
        if (ischeckLevel3)
        {
            StartCoroutine(checkLevel3Cor());
            ischeckLevel3 = false;
        }
        if (!moveCheck)
            gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, target.position, 1.0f * Time.deltaTime);
        else
            gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, featherTarget.position, 1.0f * Time.deltaTime);
        if (stopWatch.stopwatch.ElapsedMilliseconds * 0.001f > 68.0f)
        {
            animator.SetBool("fly", false);
            transform.position = Vector3.Slerp(gameObject.transform.position, featherTarget.position, 1.0f * Time.deltaTime);
            if (stopWatch.stopwatch.ElapsedMilliseconds * 0.001f > 70.0f)
                transform.position = Vector3.Slerp(transform.position, finalPos.transform.position, 1.0f * Time.deltaTime);
        }
    }

    IEnumerator restart()
    {
        yield return null;
        ischeckLevel2 = false;
        ischeckLevel3 = false;
        isFeathergcheck = false;
        moveCheck = false;
        isLeafcheck = false;
        StopAllCoroutines();
        StartCoroutine(checkStartCor());
    }

    IEnumerator checkLevel3Cor()
    {
        particleEyes.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        particleEyes.SetActive(false);
        camera.camerashake(1, 0.1f);
        moveCheck = false;
        animator.SetInteger("isState", 1);
        isLeafcheck = true;
        isFeathergcheck = true;
        moveCheck = false;
        yield return new WaitForSeconds(15.0f);
        StopCoroutine(checkLevel3Cor());
    }

    IEnumerator checkLevel2Cor()
    {
        particleEyes.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        particleEyes.SetActive(false);
        animator.SetInteger("isState", 2);
        isFeathergcheck = true;
        moveCheck = true;
        yield return new WaitForSeconds(15.0f);
        ischeckLevel3 = true;
        StopCoroutine(checkLevel2Cor());
    }

    IEnumerator checkStartCor()
    {
        transform.position = originTran.position;
        yield return new WaitForSeconds(2.8f);
        animator.SetBool("fly", true);
        yield return new WaitForSeconds(1.0f);
        particleEyes.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        particleEyes.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        animator.SetInteger("isState", 1);
        isLeafcheck = true;
        camera.camerashake(2.0f, 1.2f);
        yield return new WaitForSeconds(15.0f);
        ischeckLevel2 = true;
        StopCoroutine(checkStartCor());
    }


    IEnumerator checkLeafCor()
    {
        leaf.Play();
        yield return new WaitForSeconds(1.0f);

    }

    IEnumerator checkFeatherCor()
    {
        feather.Play();
        yield return new WaitForSeconds(1.0f);
    }


    public GameObject particleEyes;
    public Transform finalPos;
    public Transform originTran;
    public Transform target;
    public ParticleSystem feather;
    public Transform featherTarget;
    public ParticleSystem leaf;
    private Animator animator;
    private GameObject uiobject;
    private GameObject retireObejct;
    private CameraSmooth camera;
    private bool isLeafcheck = false;
    private bool isFeathergcheck = false;
    private bool ischeckLevel2 = false;
    private bool ischeckLevel3 = false;
    private bool moveCheck = false;


}
