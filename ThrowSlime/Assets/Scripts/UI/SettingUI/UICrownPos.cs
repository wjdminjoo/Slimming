        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICrownPos : MonoBehaviour
{
    private void Awake()
    {
        finalPos = GameObject.FindGameObjectWithTag("Gate");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        crown = GameObject.FindGameObjectWithTag("crownParent").transform.GetChild(0).GetComponent<Transform>();
        secondCrown = GameObject.FindGameObjectWithTag("crownParent").transform.GetChild(1).GetComponent<Transform>();
        thirdCrown = GameObject.FindGameObjectWithTag("crownParent").transform.GetChild(2).GetComponent<Transform>();
        crownDistance = crown.transform.position.x - finalPos.transform.position.x;
        secondcrownDistance = secondCrown.transform.position.x - finalPos.transform.position.x;
        thirdcrownDistance = thirdCrown.transform.position.x - finalPos.transform.position.x;
        
            dist = player.position.x - finalPos.transform.position.x;

    }
    private void Start()
    {
       
            transform.GetChild(0).transform.localPosition = new Vector3(-500 + (1 - crownDistance / dist) * 1000, 22);
            transform.GetChild(1).transform.localPosition = new Vector3(-500 + (1 - secondcrownDistance / dist) * 1000, 22);
            transform.GetChild(2).transform.localPosition = new Vector3(-500 + (1 - thirdcrownDistance / dist) * 1000, 22);
    }
    private void Update()
    {
        characterDistance = player.position.x - finalPos.transform.position.x;
        transform.GetChild(3).transform.localPosition = new Vector3(-500 + (1 - characterDistance / dist) * 1000, 22);

        if (crown.gameObject.activeInHierarchy == false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if (secondCrown.gameObject.activeInHierarchy == false)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        if (thirdCrown.gameObject.activeInHierarchy == false)
        {
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    public IEnumerator Restart()
    {
        yield return null;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public GameObject finalPos;
    private float crownDistance;
    private float secondcrownDistance;
    private float thirdcrownDistance;
    private float characterDistance;
    private Transform crown;
    private Transform secondCrown;
    private Transform thirdCrown;
    private Transform player;
    private float dist;
}
