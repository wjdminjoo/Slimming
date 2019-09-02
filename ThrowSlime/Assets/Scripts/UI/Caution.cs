using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Caution : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(isCheck());
    }
    private void Update()
    {
        image[1].transform.position = Vector3.Lerp(image[1].transform.position, pos[0].transform.position, barSpeed * Time.deltaTime);
        image[2].transform.position = Vector3.Lerp(image[2].transform.position, pos[1].transform.position, barSpeed * Time.deltaTime);
    }

    IEnumerator isCheck()
    {
        Soundplay.Play();
        yield return new WaitForSeconds(1.0f);
        barSpeed = barSpeed * 0.1f;
        yield return new WaitForSeconds(1.0f);
        barSpeed = barSpeed * 10.0f;
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }




    public Image[] image;
    public GameObject[] pos;
    public float barSpeed;
    public AudioSource Soundplay;

}