using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private void Awake()
    {
        Pauseobject = GameObject.FindGameObjectWithTag("PauseButton");
        PauseIcon = GameObject.FindGameObjectWithTag("PauseIcon");
        timer = 0.0f;
        waitingTime = 1;
        objectName = gameObject.name;
    }
    private void Start()
    {
        for (int i = 0; i < num.Length; i++)
            num[i].SetActive(false);
        Pauseobject.SetActive(false);
    }
    private void Update()
    {
        
        if (Pauseobject.activeSelf)
        {
            Time.timeScale = 0.0f;
            Pauseobject.transform.GetChild(0).transform.GetChild(2).GetComponent<Image>().enabled = true;
            Pauseobject.transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().enabled = true;
            stopWatch.stopwatch.Stop();
        }
        if (ischeck&& objectName =="Exit_Button")
        {
            Pauseobject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
            Pauseobject.transform.GetChild(0).transform.GetChild(2).GetComponent<Image>().enabled = false;
            Pauseobject.transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().enabled = false;
            timer += Time.unscaledDeltaTime;
            if (timer > waitingTime && objectName =="Exit_Button")
            {
                num[0].SetActive(true);
                if (timer > waitingTime + 1)
                {
                    num[0].SetActive(false);
                    num[1].SetActive(true);
                    if (timer > waitingTime + 2)
                    {
                        num[1].SetActive(false);
                        num[2].SetActive(true);

                        if (timer > waitingTime + 3)
                        {
                            num[2].SetActive(false);
                            Time.timeScale = 1.0f;
                            Pauseobject.SetActive(false);

                            timer = 0;
                            ischeck = false;
                            stopWatch.stopwatch.Start();
                            //PauseIcon.GetComponent<Button>().interactable = true;
                            gameObject.GetComponent<Image>().enabled = true;
                            gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;

                        }
                    }
                }

            }
        }
    }
    public void OnClick()
    {
        if (Pauseobject.activeSelf)
        {
            ischeck = true;
        }
        else
        {
            Pauseobject.SetActive(true);
            Pauseobject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
            Debug.Log(Pauseobject.transform.GetChild(0).transform.GetChild(1).gameObject.name);
            Pauseobject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public GameObject[] num;
    private GameObject Pauseobject;
    private GameObject PauseIcon;
    private bool ischeck = false;
    private string objectName;
    private float timer;
    private int waitingTime;
}
