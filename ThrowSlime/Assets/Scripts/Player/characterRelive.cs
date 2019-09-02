using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRelive : MonoBehaviour
{
    private void Awake() {
        slimeX = transform.position.x;
        slimeY = transform.position.y;
    }
    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        boundSound = GetComponent<CharacterBash>().bound;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Restart") && !GateUI.ischeck || Input.GetMouseButtonDown(1) && !GateUI.ischeck)
        {
            if(GetComponent<Animator>() != null)
            GetComponent<Animator>().SetBool("isCheck", false);

            rigid2D.velocity = Vector2.zero;
            gameObject.transform.position = new Vector2(slimeX, slimeY + 0.3f);
            boundSound.Play();
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBash>().isLive == true)
            {
                CharacterInfo.life -= 1;
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sortingOrder = 2;
            GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleShadow>().particle.Play();
            GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleShadow>().particleRender.sortingOrder = 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBash>().isLive = true;
            Time.timeScale = 1.0f;
            GetComponent<CharacterBash>().relivecheck = false;

        }
    }
   
    public IEnumerator Restart(){
        yield return null;

            rigid2D.velocity = Vector2.zero;
            gameObject.transform.position = new Vector2(slimeX, slimeY + 0.3f);
            boundSound.Play();
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBash>().isLive == true)
            {
                CharacterInfo.life -= 1;
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sortingOrder = 2;
            GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleShadow>().particle.Play();
            GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleShadow>().particleRender.sortingOrder = 1;
            Time.timeScale = 1.0f;
            yield return new WaitForSeconds(0.5f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterBash>().isLive = true;


    }
    private float slimeX;
    private float slimeY;
    private AudioSource boundSound;
    private Rigidbody2D rigid2D;

}
