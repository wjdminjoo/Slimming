using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdObject : MonoBehaviour
{
    private void Awake()
    {
        animator = GetComponent<Animator>();
        origin = transform.position;
        x = origin.x;
        y = origin.y;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Restart") || Input.GetMouseButtonDown(1))
        {
            isfly = false;
            gameObject.transform.position = new Vector2(x, y);
            ischeck = false;
            animator.SetBool("fly", false);
            temp = Vector3.zero;
        }
        if (isfly)
        {
            transform.position +=  temp * speed * Time.deltaTime;
        }
    }
   

    public IEnumerator Restart()
    {
        yield return null;
        isfly = false;
        gameObject.transform.position = new Vector2(x, y);
        ischeck = false;
        animator.SetBool("fly", false);
        temp = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            character = other.transform;
            // temp = Mathf.Sqrt((character.transform.position.x - transform.position.x) * (character.transform.position.x - transform.position.x) + 
            // (character.transform.position.y - transform.position.y) * (character.transform.position.y - transform.position.y)); // 루트

            // temp = Mathf.Sqrt(temp); // cos의 변
            temp = (character.transform.position - transform.position).normalized;
            StartCoroutine(CoroutinMove());
            
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        StopCoroutine(CoroutinMove());
    }

    IEnumerator CoroutinMove()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("fly", true);
        isfly = true;

    }
    public float x;
    public float y;
    public float speed;
    private Transform character;
    private Vector3 origin;
    private bool ischeck = false;
    private Animator animator;
    private Vector3 temp;
    private bool isfly = false;
}
