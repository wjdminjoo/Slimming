using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodPackerInfo : MonoBehaviour
{

    private void Awake()
    {
        //WoodPackerHP = 5;
        //GetComponent<GateUI>().enabled = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (stopWatch.stopwatch.ElapsedMilliseconds * 0.001f >= 20 && crown[0].GetComponent<RandomCrown>().ischeck)
        {
            crown[0].gameObject.SetActive(true);
            crown[0].GetComponent<RandomCrown>().ischeck = false;
        }
        if (stopWatch.stopwatch.ElapsedMilliseconds * 0.001f >= 40 && crown[1].GetComponent<RandomCrown>().ischeck)
        {
            crown[1].gameObject.SetActive(true);
            crown[1].GetComponent<RandomCrown>().ischeck = false;
        }
        if (stopWatch.stopwatch.ElapsedMilliseconds * 0.001f >= 60 && crown[2].GetComponent<RandomCrown>().ischeck)
        {
            crown[2].gameObject.SetActive(true);
            crown[2].GetComponent<RandomCrown>().ischeck = false;
        }
        if (Time.timeScale <= 0.0f)
        {
            for (int i = 0; i < 3; i++)
            {
                stopWatch.stopwatch.Reset();
                crown[i].gameObject.transform.position = origin.transform.position;
                crown[i].gameObject.SetActive(false);
                crown[i].GetComponent<RandomCrown>().ischeck = true;

            }
        }
        // if (HpImage.value <= 0.1f)
        // {
        //     gameObject.tag = "Gate";

        // }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // if (other.gameObject.CompareTag("Player"))
        // {
        //     //HpImage.value -= WoodPackerHP * 0.01f;
        //     StartCoroutine(coolTimeCor());
        //     GetComponent<SpriteRenderer>().color = Color.red;
        //     animator.SetBool("isHit", true);
        //     StartCoroutine(animCor());
        // }
    }
    public void ChangeTag(string name)
    {
        gameObject.tag = name;
    }

    IEnumerator coolTimeCor()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1.0f);
        GetComponent<SpriteRenderer>().color = Color.white;
        StopCoroutine(coolTimeCor());
    }
    // IEnumerator animCor()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     animator.SetBool("isHit", false);
    // }
    public Transform[] crown;
    public static int WoodPackerHP;
    public GameObject origin;
    // public Slider HpImage;
    private bool ischeck = true;
    private bool corwn1Check = true;
    private bool corwn2Check = true;
    private bool corwn3Check = true;
    private Animator animator;


}
