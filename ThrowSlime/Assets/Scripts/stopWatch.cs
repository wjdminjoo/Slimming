using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class stopWatch : MonoBehaviour
{
    private void Awake()
    {
        stopwatch = new Stopwatch();
        PauseUI = GameObject.FindWithTag("PauseButton");
    }
    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Restart") && !GateUI.ischeck || Input.GetMouseButtonDown(1) && !GateUI.ischeck)
        {
            stopwatch.Restart();
        }
        if (gameObject.GetComponent<Text>() != null && !ischeck)
        {
            text.text = "소요 시간  :  " + string.Format("{0:n}", stopwatch.ElapsedMilliseconds * 0.001f) + "sec";
            ischeck = true;
        }
        if (gameObject.GetComponent<Text>() != null && gameObject.name == "Text")
        {
            text.text = "소요 시간  " + string.Format("{0:n}", stopwatch.ElapsedMilliseconds * 0.001f) + "sec";
        }
        if (gameObject.GetComponent<Text>() != null && gameObject.name == "PlayTime")
        {
            text.text = string.Format("{0:n}", stopwatch.ElapsedMilliseconds * 0.001f);
        }

        if (GetComponent<Image>() != null && gameObject.CompareTag("RankUI"))
        {
            if (Srank > stopwatch.ElapsedMilliseconds * 0.001f)
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("RANK/S");
            }
            else if (Arank > stopwatch.ElapsedMilliseconds * 0.001f)
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("RANK/A");
            }
            else if (Brank > stopwatch.ElapsedMilliseconds * 0.001f)
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("RANK/B");
            }
            else if (Crank > stopwatch.ElapsedMilliseconds * 0.001f)
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("RANK/C");
            }
            else
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("RANK/D");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gate") && gameObject.CompareTag("Player"))
        {
            if (Srank > stopwatch.ElapsedMilliseconds * 0.001f)
            {
                temp = stopwatch.ElapsedMilliseconds * 0.001f;
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Timer", temp);
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Rank", "S");
            }
            else if (Arank > stopwatch.ElapsedMilliseconds * 0.001f)
            {
                temp = stopwatch.ElapsedMilliseconds * 0.001f;
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Timer", temp);
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Rank", "A");
            }
            else if (Brank > stopwatch.ElapsedMilliseconds * 0.001f)
            {
                temp = stopwatch.ElapsedMilliseconds * 0.001f;
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Timer", temp);
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Rank", "B");
            }
            else if (Crank > stopwatch.ElapsedMilliseconds * 0.001f)
            {
                temp = stopwatch.ElapsedMilliseconds * 0.001f;
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Timer", temp);
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Rank", "C");
            }
            else
            {
                temp = stopwatch.ElapsedMilliseconds * 0.001f;
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Timer", temp);
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Rank", "D");
            }
        }
    }

    
    public float Srank;
    public float Arank;
    public float Brank;
    public float Crank;
    public float Drank;
    public float Frank;
    [HideInInspector] public static Stopwatch stopwatch;
    [HideInInspector] public static float Timer;
    private Text text;
    private bool ischeck = false;
    private float temp;
    private GameObject PauseUI;
}

