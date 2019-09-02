using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBlood : MonoBehaviour
{
    private void Awake()
    {
        if (gameObject.name == "blood_" + gameObject.name)
        {
            rend = GetComponent<SpriteRenderer>();
            int rand = Random.Range(0, blood.Length);
            rend.sprite = blood[rand];
            Debug.Log(rand);
        }

        if (gameObject.CompareTag("Player"))
        {
            bloodSplash = GameObject.Find("blood_" + gameObject.name);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Instantiate(bloodSplash, new Vector3(transform.position.x, transform.position.y, bloodPos -= 0.01f), Quaternion.identity);
            bloodSplash.transform.localScale = new Vector2(2.0f, 2.0f);
        }
    }





    public GameObject bloodSplash;
    public Sprite[] blood;
    private SpriteRenderer rend;
    private static float bloodPos = -1.0f;
}
