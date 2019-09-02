using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CharacterInfo : MonoBehaviour
{
    private void Awake()
    {
        if (GetComponent<Text>() != null)
        {
            text = GetComponent<Text>();
        }
        if (gameObject.CompareTag("Player"))
        {
            UIobject = GameObject.FindGameObjectWithTag("Retire");
            FadeInOutObejct = GameObject.FindGameObjectWithTag("FadeInOut");
        }
        stageLife = life;

    }
    private void Start()
    {

        if (!ischeck && gameObject.name != "Life" && gameObject.name != "Text")
        {
            FadeInOutObejct.SetActive(false);
            UIobject.SetActive(false);
            ischeck = true;
            activeout = true;
        }
    }
    private void Update()
    {
        if (GetComponent<Text>() != null)
        {
            text.text = "x" + string.Format("{0}", life);
        }
        if (GetComponent<Text>() != null && gameObject.CompareTag("UI"))
        {
            text.text = "소요 목숨 : " + string.Format("{0}", stageLife - life);
        }
        if (gameObject.CompareTag("Player") && life <= 0 && activeout)
        {
            FadeInOutObejct.SetActive(true);
            timer += Time.unscaledDeltaTime;
            if (timer > waitingTime)
            {
                FadeInOutObejct.GetComponent<FadeInOut>().FadeIn(0.5f);
                if (timer > waitingTime + 0.5f)
                {
                    UIobject.SetActive(true);
                    timer = 0;
                    activeout = false;
                    PlayerPrefs.DeleteAll();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("BossWall"))
        {
            life -= 1;
            stageLife -= 1;
        }
        if (other.gameObject.CompareTag("Respawn"))
            gameObject.GetComponent<BoxCollider2D>().sharedMaterial = null;

    }
    [HideInInspector] public GameObject UIobject;
    public static short life = 99;
    [HideInInspector] public bool activeout = true;

    private GameObject FadeInOutObejct;
    private Text text;
    private bool ischeck = false;
    private float timer = 0.0f;
    private float waitingTime = 0.5f;
    public short stageLife;
}
