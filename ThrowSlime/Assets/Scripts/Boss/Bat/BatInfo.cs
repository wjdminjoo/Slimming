using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatInfo : MonoBehaviour
{
    private void Awake()
    {
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
        
    }
     public Transform[] crown;
    public static int WoodPackerHP;
    public GameObject origin;
    private bool ischeck = true;
    private bool corwn1Check = true;
    private bool corwn2Check = true;
    private bool corwn3Check = true;
    private Animator animator;
}
