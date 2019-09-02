using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDead : MonoBehaviour
{
    void Start()
    {
        audioSource = GameObject.Find("Sound").transform.GetChild(1).GetComponent<AudioSource>();
        particleRender.sortingOrder = -1;
        audioSource.Stop();
    }

    void Update()
    {
        if (deadParticle != null)
        {
            ParticleSystem.MainModule main = deadParticle.main;
            if (main.startRotation.mode == ParticleSystemCurveMode.Constant)
                main.startRotation = -transform.eulerAngles.z * Mathf.Deg2Rad;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            particleRender.sortingOrder = 1;
            deadParticle.Play();
            audioSource.Play();
            isCheck = true;

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (isCheck)
        {
            particleRender.sortingOrder = -1;
            audioSource.Stop();
            isCheck = false;
        }
    }


    public AudioSource audioSource;
    public ParticleSystem deadParticle;
    public ParticleSystemRenderer particleRender;
    private bool isCheck = false;

}
