using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateUI : MonoBehaviour
{
    private void Awake()
    {
        uiobject = GameObject.FindGameObjectWithTag("UIPopup");
        gameObject.tag = "Gate";
        timer = 0.0f;
        isUIActive = false;
    }
    private void Start()
    {
        uiobject.SetActive(false);
    }


    private void Update()
    {
        if (uiobject.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!uiobject.activeSelf)
        {
            ischeck = false;
        }

        if (isUIActive)
        {
            timer += Time.unscaledDeltaTime;
            if (timer > limitTime)
            {
                uiobject.SetActive(true);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            player = other.gameObject;
            if (gameObject.name == "left")
            {
                other.transform.position = new Vector3(other.transform.position.x, transform.position.y);
                gameObject.transform.parent.GetComponent<Animator>().SetInteger("absorb", 1);
            }
            else if (gameObject.name == "right")
            {
                other.transform.position = new Vector3(other.transform.position.x, transform.position.y);
                gameObject.transform.parent.GetComponent<Animator>().SetInteger("absorb", 2);
            }
            else if (gameObject.name == "up")
            {
                other.transform.position = new Vector3(transform.position.x, other.transform.position.y);
                gameObject.transform.parent.GetComponent<Animator>().SetInteger("absorb", 3);
            }
            else if (gameObject.name == "down")
            {
                other.transform.position = new Vector3(transform.position.x, other.transform.position.y);
                gameObject.transform.parent.GetComponent<Animator>().SetInteger("absorb", 4);
            }
        }



        other.gameObject.GetComponent<CharacterBash>().isLive = false;

        GameObject.FindGameObjectWithTag("Slider").GetComponent<InGameSlider>().textSlime.GetComponent<Text>().color = new Color32(193, 0, 255, 255);
        GameObject.FindGameObjectWithTag("Slider").GetComponent<InGameSlider>().textSlime.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

        stopWatch.stopwatch.Stop();
        ischeck = true;
        other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 0.0f;
        isUIActive = true;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        GameObject.FindGameObjectWithTag("Slider").GetComponent<InGameSlider>().textSlime.GetComponent<Text>().color = new Color32(193, 0, 255, 255);
        GameObject.FindGameObjectWithTag("Slider").GetComponent<InGameSlider>().textSlime.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

        gameObject.transform.parent.GetComponent<Animator>().SetInteger("absorb", 0);
    }

    public static bool ischeck = false;
    private GameObject uiobject;

    private float limitTime = 1.5f;
    private float timer;
    private bool isUIActive = false;
    private GameObject player;
}
