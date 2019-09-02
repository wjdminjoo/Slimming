using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterCrown : MonoBehaviour
{

    private void Awake()
    {
        uiCrown = new GameObject[3];
        crown = new GameObject[3];

        crown[0] = GameObject.FindGameObjectWithTag("crownParent").transform.GetChild(0).gameObject;
        crown[1] = GameObject.FindGameObjectWithTag("crownParent").transform.GetChild(1).gameObject;
        crown[2] = GameObject.FindGameObjectWithTag("crownParent").transform.GetChild(2).gameObject;
        uiCrown[0] = GameObject.FindGameObjectWithTag("PopUpCrown").transform.GetChild(0).gameObject;
        uiCrown[1] = GameObject.FindGameObjectWithTag("PopUpCrown").transform.GetChild(1).gameObject;
        uiCrown[2] = GameObject.FindGameObjectWithTag("PopUpCrown").transform.GetChild(2).gameObject;
        CrownParticle = GameObject.FindGameObjectsWithTag("CrownEffect");

        if (CrownParticle.Length > 0)
        {
            CrownParticle[0].GetComponent<ParticleSystem>().Stop();
            CrownParticle[1].GetComponent<ParticleSystem>().Stop();
            CrownParticle[2].GetComponent<ParticleSystem>().Stop();
        }
        
        crownSound = GameObject.Find("Sound").transform.GetChild(2).GetComponent<AudioSource>();
        image = GameObject.FindGameObjectWithTag("crownUI").GetComponentsInChildren<Image>();
    }
    private void Start() {
        CrownParticle[0].transform.position = crown[0].transform.position;
        CrownParticle[1].transform.position = crown[1].transform.position;
        CrownParticle[2].transform.position = crown[2].transform.position;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Restart") && !GateUI.ischeck || Input.GetMouseButtonDown(1) && !GateUI.ischeck)
        {

            for (int i = 0; i < 3; i++)
            {
                image[i].sprite = Resources.Load<Sprite>("icon/2");
                uiCrown[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/2");
            }
            transform.GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = 2;
            transform.GetChild(3).GetComponent<SpriteRenderer>().sortingOrder = 2;
            crown[0].SetActive(true);
            crown[1].SetActive(true);
            crown[2].SetActive(true);
        }
    }

    public IEnumerator Restart()
    {
        yield return null;


        for (int i = 0; i < 3; i++)
        {
            image[i].sprite = Resources.Load<Sprite>("icon/2");
            uiCrown[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/2");
        }
        crown[0].SetActive(true);
        crown[1].SetActive(true);
        crown[2].SetActive(true);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("crown"))
        {
            crown[int.Parse(other.gameObject.name)].SetActive(false);
            image[int.Parse(other.gameObject.name)].sprite = Resources.Load<Sprite>("icon/1");
            uiCrown[int.Parse(other.gameObject.name)].GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/1");
            if (CrownParticle.Length > 0)
                CrownParticle[int.Parse(other.gameObject.name)].GetComponent<ParticleSystem>().Play();
            crownSound.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("wall"))
        {

            for (int i = 0; i < 3; i++)
            {
                image[i].sprite = Resources.Load<Sprite>("icon/2");
                uiCrown[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/2");
            }
            crown[0].SetActive(true);
            crown[1].SetActive(true);
            crown[2].SetActive(true);
        }

        if (other.gameObject.CompareTag("Gate"))
        {
            if (image[2].sprite == Resources.Load<Sprite>("icon/1") || PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_score") == 3)
            {
                score = 3;
            }
            else if (image[1].sprite == Resources.Load<Sprite>("icon/1")|| PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_score") == 2)
            {
                score = 2;
            }
            else if (image[0].sprite == Resources.Load<Sprite>("icon/1"))
            {
                score = 1;
            }
            
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_score", score);
        }
    }
    public GameObject[] CrownParticle;
    public AudioSource crownSound;
    public GameObject[] crown;
    public GameObject[] uiCrown;
    private Image[] image;
    private short score = 0;


}
