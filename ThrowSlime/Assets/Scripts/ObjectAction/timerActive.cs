using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerActive : MonoBehaviour
{
    private void Awake()
    {
        Timetext = GameObject.FindGameObjectWithTag("UICanvasTime");
        Player = GameObject.FindGameObjectWithTag("Player");
        uiobject = GameObject.FindGameObjectWithTag("UIPopup");
    }
    

    private void Update()
    {
        if (limitTime > Timer && isCheck)
        {
            Timer = stopWatch.stopwatch.ElapsedMilliseconds * 0.001f;
        }
        else if (limitTime < Timer && isCheck)
        {
            ItemObject.SetActive(true);
            isCheck = false;
        }

        if (GetComponent<Text>() != null && limitTime > Timer && isCheck)
        {
            Timetext.GetComponent<Text>().color = new Color(255f / 255f, 0, 0, 60f / 255f);
            Timetext.GetComponent<Text>().text = string.Format("{0:f2}", 70.0f - Timer);
        }
        else if (GetComponent<Text>() != null && limitTime < Timer && isCheck)
        {
            Timetext.GetComponent<Text>().text = null;
        }
       
        if(Timer > 70.0f){
            Player.gameObject.GetComponent<CharacterBash>().isLive = false;
            stopWatch.stopwatch.Stop();
            Player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Player.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            uiobject.SetActive(true);
            Time.timeScale = 0.0f;
            gameObject.SetActive(false);
        }
    }

    private GameObject uiobject;
    private GameObject ItemObject;
    private static float Timer;
    private float limitTime = 60.0f;
    private bool isCheck = true;
    private GameObject Timetext;
    private bool iscorcheck = false;
    private GameObject Player;

}
