using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEffectScript : MonoBehaviour
{
    private void Start() {
        camerasmooth = Camera.main.GetComponent<CameraSmooth>();
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBash>();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<CharacterBash>().isLive == true){
            CharacterInfo.life -= 1;
            other.gameObject.GetComponent<ParticleDead>().particleRender.sortingOrder = 1;
            other.gameObject.GetComponent<CharacterBash>().isLive = false;
            other.gameObject.GetComponent<ParticleDead>().deadParticle.Play();
            other.gameObject.GetComponent<ParticleDead>().audioSource.Play();
            other.gameObject.GetComponent<ParticleShadow>().particle.Stop();
            other.gameObject.GetComponent<ParticleShadow>().particleRender.sortingOrder = -1;
            other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
            other.gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = -1;
            other.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().sortingOrder = -1;
            camerasmooth.camerashake(2, 0.1f);
            Time.timeScale = 0.0f;
            stopWatch.stopwatch.Restart();
            stopWatch.stopwatch.Stop();
            other.gameObject.GetComponent<CharacterBash>().relivecheck = true;
        }
    }

    private CharacterBash character;
    private CameraSmooth camerasmooth;
}
