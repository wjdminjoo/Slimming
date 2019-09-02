using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScript : MonoBehaviour
{
    private void Start()
    {
        sound = GameObject.Find("click").GetComponent<AudioSource>();
    }
    public void onClick()
    {
        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_score") == 3)
        {
            Scene scene = SceneManager.GetActiveScene();
            int curScene = scene.buildIndex;
            int nextScene = curScene + 1;
            SceneManager.LoadScene(nextScene);
            sound.Play();
        }
    }
    public AudioSource sound;
}
