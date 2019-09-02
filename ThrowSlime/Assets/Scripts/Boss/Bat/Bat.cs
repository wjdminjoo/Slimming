using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
  
    private void Start() {
        
        animator = GetComponent<Animator>();
        uiobject = GameObject.FindGameObjectWithTag("UIPopup");
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSmooth>();
        StartCoroutine(checkStartCor());
        uiobject.SetActive(false);
    }
    private void Update()
    {

        if (Input.GetButtonDown("Restart") || Input.GetMouseButtonDown(1) || Time.timeScale <= 0.0f)
        {
            BatSpawn.gameObject.SetActive(false);
            StartCoroutine(restart());
        }

        if (ischeckLevle1)
        {
            Timer += Time.deltaTime;
            if (Timer > limitTime)
            {
                float randomQuaternion = Random.Range(0, 180);
                GameObject newgameobject = Instantiate(wave, new Vector3(-27.8f, 12.2f, -1.0f), new Quaternion(0, 0, randomQuaternion, 1)) as GameObject;
                newgameobject.transform.SetParent(emptyParent.transform);
                Destroy(newgameobject, 6.0f);
                Timer = 0;
            }
        }

        if (ischeckLevel2)
        {
            BatSpawn.gameObject.SetActive(true);
            StartCoroutine(checkLevel2Cor());
            ischeckLevel2 = false;
        }
        if (ischeckLevel3)
        {
            StartCoroutine(checkLevel3Cor());
            ischeckLevel3 = false;
        }

        if (stopWatch.stopwatch.ElapsedMilliseconds * 0.001f > 70.0f)
            transform.position = Vector3.Lerp(transform.position, finalPos.transform.position, 1.0f * Time.deltaTime);
    }

    IEnumerator restart()
    {
        yield return null;
        Timer = 0;
        StopAllCoroutines();
        StartCoroutine(checkStartCor());
    }

    IEnumerator checkLevel3Cor()
    {
        yield return new WaitForSeconds(1.0f);
        ischeckLevle1 = true;
        BatSpawn.Play();
        yield return new WaitForSeconds(15.0f);
        BatSpawn.Stop();
        StartCoroutine(checkStartCor());
        StopCoroutine(checkLevel3Cor());
    }

    IEnumerator checkLevel2Cor()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("wave", true);
        BatSpawn.Play();
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("wave", false);
        BatSpawn.Stop();
        ischeckLevel3 = true;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;

        StopCoroutine(checkLevel2Cor());
    }

    IEnumerator checkStartCor()
    {

        yield return new WaitForSeconds(0.05f);
        for (int i = 0; i < emptyParent.transform.childCount; i++)
        {
            Destroy(emptyParent.transform.GetChild(i).GetComponent<Transform>().gameObject);
        }
        yield return new WaitForSeconds(2.0f);
        ischeckLevle1 = true;
        yield return new WaitForSeconds(15.0f);
        ischeckLevle1 = false;
        ischeckLevel2 = true;
        StopCoroutine(checkStartCor());
    }




    public GameObject emptyParent;
    public float limitTime;
    public Transform finalPos;
    public ParticleSystem BatSpawn;
    public GameObject wave;
    private Animator animator;
    private GameObject uiobject;
    private GameObject retireObejct;
    private CameraSmooth camera;
    private bool ischeckLevle1 = false;
    private bool ischeckLevel2 = false;
    private bool ischeckLevel3 = false;
    private float Timer = 0;
}
