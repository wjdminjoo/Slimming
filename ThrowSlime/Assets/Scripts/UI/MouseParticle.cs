using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParticle : MonoBehaviour
{
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        cameraTrans = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        if (Input.GetMouseButtonDown(0) == true)
        {
            child = Instantiate(prefabParticle, new Vector3(cameraTrans.x, cameraTrans.y, -10), Quaternion.identity);
            Destroy(child, 1.0f);
        }
        else if (Input.GetMouseButton(0) == true && !ischeckMenu)
        {
            player =  camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            child = Instantiate(Traileffect, new Vector3(cameraTrans.x, cameraTrans.y, -10), Quaternion.identity);
            Destroy(child, 1.0f);
        }
    }
    public GameObject Traileffect;
    public GameObject prefabParticle;
    public bool ischeckMenu = false;
    private Vector3 cameraTrans;
    private Camera camera;
    private GameObject child;
    private Vector3 player;
    

}
