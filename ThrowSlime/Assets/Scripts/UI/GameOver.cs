using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Awake()
    {
        FadeInOutObejct = GameObject.FindGameObjectWithTag("FadeInOut");
    }
    private void Start()
    {
        button = GetComponent<Button>();
    }
    private void Update()
    {
        Time.timeScale = 0;
        if(waittime < timer && ischeck){
        timer = 0.0f;
        SceneManager.LoadScene("Title");
        }else if(waittime > timer && ischeck){
            timer += Time.unscaledDeltaTime;
        }
    }
    
    public void OnClick()
    {
        //FadeInOutObejct.SetActive(true);
        CharacterInfo.life = 99;
        FadeInOutObejct.GetComponent<FadeInOut>().FadeOut(1.0f);
        ischeck = true;
    }

    private Button button;
    private GameObject FadeInOutObejct;
    private float timer;
    private float waittime = 1.0f;
    private bool ischeck = false;
}
