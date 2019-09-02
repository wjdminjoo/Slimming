using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSetting : MonoBehaviour
{
    private void Awake()
    {
        backVol = PlayerPrefs.GetFloat("SFXVol", 1.0f);
        audiosource = GameObject.Find("Sound").GetComponentsInChildren<AudioSource>();
        if (backVolume != null)
        {
            for (int i = 0; i < audiosource.Length; i++)
            {
                backVolume.value = backVol;
                audiosource[i].volume = backVolume.value;
            }
        }else
        {
            for (int i = 0; i < audiosource.Length; i++)
            audiosource[i].volume = backVol;
        }
    }

    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        if (backVolume != null)
        {
            for (int i = 0; i < audiosource.Length; i++)
            {
                audiosource[i].volume = backVolume.value;
                backVol = backVolume.value;
            }
        }else
        {
            for (int i = 0; i < audiosource.Length; i++)
            audiosource[i].volume = backVol;
        }
        PlayerPrefs.SetFloat("SFXVol", backVol);
    }


    public Slider backVolume;
    public AudioSource[] audiosource;
    private AudioListener listener;
    private float backVol;
}
