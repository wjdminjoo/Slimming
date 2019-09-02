using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEyeRender : MonoBehaviour
{
    private void Awake()
    {
        Parentrender = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameObject.transform.localPosition = new Vector3(0.25f, -0.2f, -1);

    }
    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = Parentrender.sortingOrder;
        if (Input.GetButtonDown("Restart") || Input.GetMouseButtonDown(1))
        {
            gameObject.transform.localPosition = new Vector3(0.25f, -0.2f, -1);
        }
        if(Time.timeScale <= 0.0f){
        gameObject.transform.localPosition = new Vector3(0.25f, -0.2f, -1);
        }
        if (gameObject.GetComponent<SpriteRenderer>().sortingOrder == 1)
            GetComponent<SpriteRenderer>().enabled = false;
        else
            GetComponent<SpriteRenderer>().enabled = true;

        if(ischeck){
            
            transform.localPosition -= new Vector3(0, eyespeed);
        }else{

            transform.localPosition += new Vector3(0, eyespeed);
        }

        if(transform.localPosition.y <= -0.28f){
            ischeck = false;
        }else if(transform.localPosition.y >= -0.20f){
            ischeck = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
            animator.SetBool("scary", true);
        if (other.gameObject.CompareTag("Gate"))
            animator.SetBool("smile", true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("scary", false);
        animator.SetBool("smile", false);

    }

    public float eyespeed;


    private Vector3 eyeTemp;
    private SpriteRenderer Parentrender;
    private Animator animator;
    private bool ischeck = true;
    
}
