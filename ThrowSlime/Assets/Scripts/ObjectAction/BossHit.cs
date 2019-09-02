using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHit : MonoBehaviour
{
    private void Start()
    {
        woodpackertag = GameObject.Find("WoodPecker").GetComponent<WoodPackerInfo>();
    }

    private void Update() {
        if(GetComponent<SpriteRenderer>() != null && !ischeck){
            GetComponent<SpriteRenderer>().enabled = false;
        }else if(GetComponent<SpriteRenderer>() != null && ischeck){
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && ischeck && GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            Player = other.gameObject;
            other.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = Resources.Load<PhysicsMaterial2D>("PhysicMaterials/HitBoss");
            other.gameObject.GetComponent<Animator>().SetBool("attackMode" , true);
            ischeck = false;
            woodpackertag.ChangeTag("bossHit");
            StartCoroutine(coolTimeCor());
        }
    }

    IEnumerator coolTimeCor()
    {
        yield return new WaitForSeconds(5.0f);
        Player.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = null;
        Player.gameObject.GetComponent<Animator>().SetBool("attackMode" , false);
        yield return new WaitForSeconds(15.0f);
        ischeck = true;
    }

    private GameObject Player;
    private WoodPackerInfo woodpackertag;
    private bool ischeck = true;
}
