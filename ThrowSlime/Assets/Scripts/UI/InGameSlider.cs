using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSlider : MonoBehaviour
{

    private void Start()
    {

        if (BossCheck != true)
        {
            textSlime = transform.GetChild(3).gameObject;
            finalPos = GameObject.FindGameObjectWithTag("Gate");
            Image = transform.GetChild(0).GetComponent<Image>();
            Player = GameObject.FindGameObjectWithTag("Player");
            distance = Player.transform.position.x - finalPos.transform.position.x;
        }
    }

    private void Update()
    {
        if (BossCheck != true)
        {
            var dist = Player.transform.position.x - finalPos.transform.position.x;
            Image.fillAmount = 1 - (dist / distance);
        }
        if(BossCheck == true){
            gameObject.SetActive(false);
        }
    }



    public bool BossCheck = false;
    public GameObject finalPos;
    [HideInInspector]public GameObject textSlime;
    private Image Image;
    private GameObject Player;
    private float distance;
}
