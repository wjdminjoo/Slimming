using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShadow : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
            particle.Play();
        if (particle != null)
        {
            ParticleSystem.MainModule main = particle.main;
            if (main.startRotation.mode == ParticleSystemCurveMode.Constant)
                main.startRotation = -transform.eulerAngles.z * Mathf.Deg2Rad;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            particleRender.sortingOrder = -1;
            isCheck = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (isCheck)
        {
            particleRender.sortingOrder = 1;
            isCheck = false;
        }
    }
    public ParticleSystem particle;
    public ParticleSystemRenderer particleRender;
    private bool isCheck = false;
}
