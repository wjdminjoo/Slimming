using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSetting : MonoBehaviour
{
    private void Awake() {
        backVol = PlayerPrefs.GetFloat("backVol", 1.0f);
        if (backVolume != null)
        {
            backVolume.value = backVol;
            audiosource.volume = backVolume.value;
        }else
        {
            audiosource.volume = backVol;
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
            audiosource.volume = backVolume.value;
            backVol = backVolume.value;
        }else
        {
            audiosource.volume = backVol;
        }
        PlayerPrefs.SetFloat("backVol", backVol);
    }


    public Slider backVolume;
    public AudioSource audiosource;
    private AudioListener listener;
    private float backVol;
}
