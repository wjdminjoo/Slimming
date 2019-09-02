using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharacterBash : MonoBehaviour
{
    private void Awake()
    {
        PauseUI = GameObject.FindWithTag("PauseButton");
        directionArrow = new Transform[5];
        directionArrowBow = new Transform[2];
        bound = GameObject.Find("Sound").transform.GetChild(0).GetComponent<AudioSource>();
        for(int i = 0; i < 5; i++){
        directionArrow[i] = GameObject.Find("Canvas").transform.GetChild(i).transform;
        }
        directionArrowBow[1] = GameObject.Find("Canvas").transform.GetChild(5).transform;
        watch = GetComponent<stopWatch>();
        gameoverUI = GameObject.FindGameObjectWithTag("Retire");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (GetComponent<Animator>() != null)
        {
            animator = GetComponent<Animator>();
        }
        if(PlayerPrefs.GetString("Level") == "easy"){
            Gamelevel = 1;
        }else{
            Gamelevel = 2;
        }

        FadeInOutObejct = GameObject.FindGameObjectWithTag("FadeInOut");
        SliderUI = GameObject.FindWithTag("Slider").transform.GetChild(0).GetComponent<UICrownPos>();
        PlayerPrefs.GetString("Zoom", "True");
    }
    private void Start()
    {
        for(int i = 0; i < 5; i++){
        directionArrow[i].gameObject.SetActive(false);
        }
        //directionArrowBow[0].gameObject.SetActive(false);
        directionArrowBow[1].gameObject.SetActive(false);

        cameraSmooth = Camera.main.GetComponent<CameraSmooth>();
        temp = Vector3.zero;
        crwon = GetComponent<CharacterCrown>();
        level = GetComponent<CharacterLevelup>();
        relive = GetComponent<characterRelive>();
        if (GameObject.Find("bird"))
            bird = GameObject.FindObjectsOfType<birdObject>();
        if (GameObject.Find("stalactite"))
            dropObject = GameObject.FindObjectsOfType<DropObject>();
        sprite = gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Characters/" + gameObject.name + "/Body_" + gameObject.name);
        Time.timeScale = 1.0f;
    }

#if (UNITY_ANDROID || UNITY_IPHONE)
       private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isLive && checktime)
        {
            Time.timeScale = timeScale / Gamelevel;
            temp = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        }
        else if (Input.GetMouseButton(0) && isLive && checktime)
        {
            if (PlayerPrefs.GetString("Zoom") == "True")
                mainCamera.orthographicSize -= 0.01f;
            if (mainCamera.GetComponent<Camera>().orthographicSize <= 5.0f && mainCamera.name != "BossCamera")
            {
                mainCamera.GetComponent<Camera>().orthographicSize = 5.0f;
            }else if(mainCamera.GetComponent<Camera>().orthographicSize <= 5.0f && mainCamera.name == "BossCamera")
            {
                mainCamera.GetComponent<Camera>().orthographicSize = 8.0f;
            }
            diff = (temp - Camera.main.ScreenToViewportPoint(Input.mousePosition));
            
            if (animator != null && animator != null)
                animator.SetBool("isCheck", true);

            directionArrow[0].gameObject.SetActive(true);

            directionArrowBow[1].gameObject.SetActive(true);

            float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        for(int i = 0; i < 5; i++){
            directionArrow[i].position = transform.position;
        }
            directionArrowBow[1].position = transform.position;

        for(int i = 0; i < 5; i++){
            directionArrow[i].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 270);
        }
            directionArrowBow[1].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);

            if (diff.y >= 0)
            {
                directionArrow[0].Translate(0.0f, 0.7f, 1);
                directionArrow[1].Translate(0.0f, 1.0f, 1);
                directionArrow[2].Translate(0.0f, 1.3f, 1);
                directionArrow[3].Translate(0.0f, 1.6f, 1);
                directionArrow[4].Translate(0.0f, 1.9f, 1);
                directionArrowBow[1].Translate(0.0f, 1.0f, 1);
            }
            else if (diff.y < 0)
            {
                directionArrow[0].Translate(0.0f, 0.7f, 1);
                directionArrow[1].Translate(0.0f, 1.0f, 1);
                directionArrow[2].Translate(0.0f, 1.3f, 1);
                directionArrow[3].Translate(0.0f, 1.6f, 1);
                directionArrow[4].Translate(0.0f, 1.9f, 1);
                directionArrowBow[1].Translate(0.0f, 1.0f, 1);
            }

            if (diff.x >= 0)
            {
                directionArrow[0].Translate(0.0f, 0.7f, 1);
                directionArrow[1].Translate(0.0f, 1.0f, 1);
                directionArrow[2].Translate(0.0f, 1.3f, 1);
                directionArrow[3].Translate(0.0f, 1.6f, 1);
                directionArrow[4].Translate(0.0f, 1.9f, 1);
                directionArrowBow[1].Translate(0.0f, 1.0f, 1);
            }
            else if (diff.x < 0)
            {
                directionArrow[0].Translate(0.0f, 0.7f, 1);
                directionArrow[1].Translate(0.0f, 1.0f, 1);
                directionArrow[2].Translate(0.0f, 1.3f, 1);
                directionArrow[3].Translate(0.0f, 1.6f, 1);
                directionArrow[4].Translate(0.0f, 1.9f, 1);
                directionArrowBow[1].Translate(0.0f, 1.0f, 1);
            }

            if (diff.x > checkFastDistance * 0.1f || diff.y > checkFastDistance * 0.1f)
            {
                Color color = new Color32(255, 0, 0, 255);
                directionArrow[4].gameObject.SetActive(true);
                directionArrow[3].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (diff.x > checkHighMiddleDistance * 0.1f || diff.y > checkHighMiddleDistance * 0.1f)
            {
                Color color = new Color32(250, 244, 192, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (diff.x > checkMiddleDistance * 0.1f || diff.y > checkMiddleDistance * 0.1f)
            {
                Color color = new Color32(255, 255, 255, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(false);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (diff.x > checkSlowDistance * 0.1f || diff.y > checkSlowDistance * 0.1f)
            {
                Color color = new Color32(250, 237, 125, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(false);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(false);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }else if (-diff.x > checkFastDistance * 0.1f || -diff.y > checkFastDistance * 0.1f)
            {
                Color color = new Color32(255, 0, 0, 255);
                directionArrow[4].gameObject.SetActive(true);
                directionArrow[3].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (-diff.x > checkHighMiddleDistance * 0.1f || -diff.y > checkHighMiddleDistance * 0.1f)
            {
                Color color = new Color32(250, 244, 192, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (-diff.x > checkMiddleDistance * 0.1f || -diff.y > checkMiddleDistance * 0.1f)
            {
                Color color = new Color32(255, 255, 255, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(false);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (-diff.x > checkSlowDistance * 0.1f || -diff.y > checkSlowDistance * 0.1f)
            {
                Color color = new Color32(250, 237, 125, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(false);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(false);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else
            {
                Color color = new Color32(0, 255, 0, 255);

                directionArrow[2].gameObject.SetActive(false);
                directionArrow[1].gameObject.SetActive(false);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
        }
        else if (Input.GetMouseButtonUp(0) && isLive && checktime)
        {

            if (PlayerPrefs.GetString("Zoom") == "True")
                mainCamera.orthographicSize = 8;
            if (mainCamera.name == "BossCamera")
                mainCamera.orthographicSize = 12;

            if (stopWatch.stopwatch.IsRunning != true && PauseUI.activeInHierarchy != true)
                stopWatch.stopwatch.Start();

            diff = (temp - Camera.main.ScreenToViewportPoint(Input.mousePosition)) * -1;
            if (diff.x > 0 && animator != null)
            {
                animator.SetInteger("isFly", 1);
                transform.GetChild(2).transform.localPosition = new Vector3(-0.25f, 0, -1);
            }
            else if (diff.x < 0 && animator != null)
            {
                animator.SetInteger("isFly", 0);
                transform.GetChild(2).transform.localPosition = new Vector3(0.25f, 0, -1);
            }

            if (directionArrow[0].gameObject.GetComponent<Image>().color == Color.green)
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * -1 * slowSpeed;
            }
            else if (directionArrow[0].gameObject.GetComponent<Image>().color == new Color32(250, 237, 125, 255))
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * -1 * middleSpeed * 0.7f;
            }
            else if (directionArrow[0].gameObject.GetComponent<Image>().color == new Color32(255, 255, 255, 255))
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * -1 * middleSpeed;
            }
            else if (directionArrow[0].gameObject.GetComponent<Image>().color == new Color32(250, 244, 192, 255))
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * -1 * middleSpeed * 1.5f;
            }
            else if (directionArrow[0].gameObject.GetComponent<Image>().color == Color.red)
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * -1 * fastSpeed;
            }

            bound.Play();
            directionArrow[0].gameObject.SetActive(false);
            directionArrow[1].gameObject.SetActive(false);
            directionArrow[2].gameObject.SetActive(false);
            directionArrow[3].gameObject.SetActive(false);
            directionArrow[4].gameObject.SetActive(false);
            //directionArrowBow[0].gameObject.SetActive(false);
            directionArrowBow[1].gameObject.SetActive(false);
            Time.timeScale = 1;

            StartCoroutine(checkTime());

        }


        if (relivecheck)
        {
            checkrun += Time.unscaledDeltaTime;
            if (checkstay < checkrun && gameoverUI.activeInHierarchy == false && CharacterInfo.life != 0)
            {
                backstart();
                checkrun = 0;

            }
        }

        if (FadeInOutObejct.activeInHierarchy == true)
        {
            timer += Time.unscaledDeltaTime;
            if (timer > waitingTime)
            {
                if (timer > waitingTime + 0.5f)
                {
                    if (timer > waitingTime + 0.5f)
                    {
                        if (timer > waitingTime + 1.0f)
                        {
                            timer = 0;
                            //FadeInOutObejct.SetActive(true);
                        }
                    }
                }

            }
        }
    }
#else
    private void Update()
    {
        if (Input.GetButtonDown("back") || Input.GetMouseButtonDown(2))
        {
            SceneManager.LoadScene("Map");
        }
        if (Input.GetButtonDown("esc"))
        {
            GameObject.FindGameObjectWithTag("PauseIcon").GetComponent<PauseScript>().OnClick();
            stopWatch.stopwatch.Stop();
        }
        switch (PlayerPrefs.GetString("DirChange"))
        {
            case "true":
                DirVar(90, -1);
                break;
            case "False":
                DirVar(-90);
                break;
        }


        if (relivecheck)
        {
            checkrun += Time.unscaledDeltaTime;
            if (checkstay < checkrun && gameoverUI.activeInHierarchy == false && CharacterInfo.life != 0)
            {
                backstart();
                checkrun = 0;

            }
        }

        if (FadeInOutObejct.activeInHierarchy == true)
        {
            timer += Time.unscaledDeltaTime;
            if (timer > waitingTime)
            {
                if (timer > waitingTime + 0.5f)
                {
                    if (timer > waitingTime + 0.5f)
                    {
                        if (timer > waitingTime + 1.0f)
                        {
                            timer = 0;
                            //FadeInOutObejct.SetActive(true);
                        }
                    }
                }

            }
        }
    }
#endif

    private void DirVar(short rot, short dir = 1)
    {
        if (Input.GetMouseButtonDown(0) && isLive && checktime)
        {
            Time.timeScale = timeScale;
            temp = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        }
        else if (Input.GetMouseButton(0) && isLive && checktime)
        {
            if (PlayerPrefs.GetString("Zoom") == "True")
                mainCamera.orthographicSize -= 0.01f;
            if (mainCamera.GetComponent<Camera>().orthographicSize <= 5.0f && mainCamera.name != "BossCamera")
            {
                mainCamera.GetComponent<Camera>().orthographicSize = 5.0f;
            }
            else if (mainCamera.GetComponent<Camera>().orthographicSize <= 5.0f && mainCamera.name == "BossCamera")
            {
                mainCamera.GetComponent<Camera>().orthographicSize = 8.0f;
            }
            diff = (temp - Camera.main.ScreenToViewportPoint(Input.mousePosition));

            if (animator != null && animator != null)
                animator.SetBool("isCheck", true);

            directionArrow[0].gameObject.SetActive(true);

            //directionArrowBow[0].gameObject.SetActive(true);
            directionArrowBow[1].gameObject.SetActive(true);

            float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

            directionArrow[0].position = transform.position;
            directionArrow[1].position = transform.position;
            directionArrow[2].position = transform.position;
            directionArrow[3].position = transform.position;
            directionArrow[4].position = transform.position;
            //directionArrowBow[0].position = transform.position;
            directionArrowBow[1].position = transform.position;



            directionArrow[1].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + rot);
            directionArrow[0].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + rot);
            directionArrow[2].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + rot);
            directionArrow[3].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + rot);
            directionArrow[4].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + rot);
            //directionArrowBow[0].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            directionArrowBow[1].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - rot);

            //diff.x = Mathf.Abs(diff.x);
            //diff.y = Mathf.Abs(diff.y);

            if (diff.y >= 0)
            {
                directionArrow[0].Translate(0.0f, 0.7f, 1);
                directionArrow[1].Translate(0.0f, 1.0f, 1);
                directionArrow[2].Translate(0.0f, 1.3f, 1);
                directionArrow[3].Translate(0.0f, 1.6f, 1);
                directionArrow[4].Translate(0.0f, 1.9f, 1);
                //directionArrowBow[0].Translate(0.0f, 0.5f, 1);
                directionArrowBow[1].Translate(0.0f, 1.0f, 1);
            }
            else if (diff.y < 0)
            {
                directionArrow[0].Translate(0.0f, 0.7f, 1);
                directionArrow[1].Translate(0.0f, 1.0f, 1);
                directionArrow[2].Translate(0.0f, 1.3f, 1);
                directionArrow[3].Translate(0.0f, 1.6f, 1);
                directionArrow[4].Translate(0.0f, 1.9f, 1);
                //directionArrowBow[0].Translate(0.0f, 0.5f, 1);
                directionArrowBow[1].Translate(0.0f, 1.0f, 1);
            }

            if (diff.x >= 0)
            {
                directionArrow[0].Translate(0.0f, 0.7f, 1);
                directionArrow[1].Translate(0.0f, 1.0f, 1);
                directionArrow[2].Translate(0.0f, 1.3f, 1);
                directionArrow[3].Translate(0.0f, 1.6f, 1);
                directionArrow[4].Translate(0.0f, 1.9f, 1);
                //directionArrowBow[0].Translate(0.0f, 0.5f, 1);
                directionArrowBow[1].Translate(0.0f, 1.0f, 1);
            }
            else if (diff.x < 0)
            {
                directionArrow[0].Translate(0.0f, 0.7f, 1);
                directionArrow[1].Translate(0.0f, 1.0f, 1);
                directionArrow[2].Translate(0.0f, 1.3f, 1);
                directionArrow[3].Translate(0.0f, 1.6f, 1);
                directionArrow[4].Translate(0.0f, 1.9f, 1);
                //directionArrowBow[0].Translate(0.0f, 0.5f, 1);
                directionArrowBow[1].Translate(0.0f, 1.0f, 1);
            }

            if (diff.x > checkFastDistance * 0.1f || diff.y > checkFastDistance * 0.1f)
            {
                Color color = new Color32(255, 0, 0, 255);
                directionArrow[4].gameObject.SetActive(true);
                directionArrow[3].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (diff.x > checkHighMiddleDistance * 0.1f || diff.y > checkHighMiddleDistance * 0.1f)
            {
                Color color = new Color32(250, 244, 192, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (diff.x > checkMiddleDistance * 0.1f || diff.y > checkMiddleDistance * 0.1f)
            {
                Color color = new Color32(255, 255, 255, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(false);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (diff.x > checkSlowDistance * 0.1f || diff.y > checkSlowDistance * 0.1f)
            {
                Color color = new Color32(250, 237, 125, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(false);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(false);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (-diff.x > checkFastDistance * 0.1f || -diff.y > checkFastDistance * 0.1f)
            {
                Color color = new Color32(255, 0, 0, 255);
                directionArrow[4].gameObject.SetActive(true);
                directionArrow[3].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (-diff.x > checkHighMiddleDistance * 0.1f || -diff.y > checkHighMiddleDistance * 0.1f)
            {
                Color color = new Color32(250, 244, 192, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (-diff.x > checkMiddleDistance * 0.1f || -diff.y > checkMiddleDistance * 0.1f)
            {
                Color color = new Color32(255, 255, 255, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(false);
                directionArrow[2].gameObject.SetActive(true);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else if (-diff.x > checkSlowDistance * 0.1f || -diff.y > checkSlowDistance * 0.1f)
            {
                Color color = new Color32(250, 237, 125, 255);
                directionArrow[4].gameObject.SetActive(false);
                directionArrow[3].gameObject.SetActive(false);
                directionArrow[1].gameObject.SetActive(true);
                directionArrow[2].gameObject.SetActive(false);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
            else
            {
                Color color = new Color32(0, 255, 0, 255);

                directionArrow[2].gameObject.SetActive(false);
                directionArrow[1].gameObject.SetActive(false);
                directionArrow[0].gameObject.GetComponent<Image>().color = color;
                directionArrow[1].gameObject.GetComponent<Image>().color = color;
                directionArrow[2].gameObject.GetComponent<Image>().color = color;
                directionArrow[3].gameObject.GetComponent<Image>().color = color;
                directionArrow[4].gameObject.GetComponent<Image>().color = color;
                //directionArrowBow[0].gameObject.GetComponent<Image>().color = color;
                directionArrowBow[1].gameObject.GetComponent<Image>().color = color;
            }
        }
        else if (Input.GetMouseButtonUp(0) && isLive && checktime)
        {

            if (PlayerPrefs.GetString("Zoom") == "True")
                mainCamera.orthographicSize = 8;
            if (mainCamera.name == "BossCamera")
                mainCamera.orthographicSize = 12;

            if (stopWatch.stopwatch.IsRunning != true && PauseUI.activeInHierarchy != true)
                stopWatch.stopwatch.Start();

            diff = (temp - Camera.main.ScreenToViewportPoint(Input.mousePosition)) * -1;
            if (diff.x > 0 && animator != null)
            {
                animator.SetInteger("isFly", 1);
                transform.GetChild(2).transform.localPosition = new Vector3(-0.25f, 0, -1);
            }
            else if (diff.x < 0 && animator != null)
            {
                animator.SetInteger("isFly", 0);
                transform.GetChild(2).transform.localPosition = new Vector3(0.25f, 0, -1);
            }

            if (directionArrow[0].gameObject.GetComponent<Image>().color == Color.green)
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * dir * slowSpeed;
            }
            else if (directionArrow[0].gameObject.GetComponent<Image>().color == new Color32(250, 237, 125, 255))
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * dir * middleSpeed * 0.7f;
            }
            else if (directionArrow[0].gameObject.GetComponent<Image>().color == new Color32(255, 255, 255, 255))
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * dir * middleSpeed;
            }
            else if (directionArrow[0].gameObject.GetComponent<Image>().color == new Color32(250, 244, 192, 255))
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * dir * middleSpeed * 1.5f;
            }
            else if (directionArrow[0].gameObject.GetComponent<Image>().color == Color.red)
            {
                GetComponent<Rigidbody2D>().velocity = diff.normalized * dir * fastSpeed;
            }

            bound.Play();
            directionArrow[0].gameObject.SetActive(false);
            directionArrow[1].gameObject.SetActive(false);
            directionArrow[2].gameObject.SetActive(false);
            directionArrow[3].gameObject.SetActive(false);
            directionArrow[4].gameObject.SetActive(false);
            //directionArrowBow[0].gameObject.SetActive(false);
            directionArrowBow[1].gameObject.SetActive(false);
            Time.timeScale = 1;

            StartCoroutine(checkTime());
        }
    }

    IEnumerator checkTime()
    {
        checktime = false;
        yield return new WaitForSeconds(checkDelay);
        checktime = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall") && isLive)
        {
            directionArrow[0].gameObject.SetActive(false);
            directionArrow[1].gameObject.SetActive(false);
            directionArrow[2].gameObject.SetActive(false);
            directionArrow[3].gameObject.SetActive(false);
            directionArrow[4].gameObject.SetActive(false);
            //directionArrowBow[0].gameObject.SetActive(false);
            directionArrowBow[1].gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sortingOrder = -1;
            sprite.sortingOrder = -1;
            cameraSmooth.camerashake(2, 0.1f);
            relivecheck = true;
            isLive = false;
            Time.timeScale = 0.0f;
            stopWatch.stopwatch.Reset();
            stopWatch.stopwatch.Stop();
        }
        else if (other.gameObject.CompareTag("BossWall") && isLive)
        {
            GameObject.FindGameObjectWithTag("crownUI").transform.GetChild(9).gameObject.SetActive(false);
            directionArrow[0].gameObject.SetActive(false);
            directionArrow[1].gameObject.SetActive(false);
            directionArrow[2].gameObject.SetActive(false);
            directionArrow[3].gameObject.SetActive(false);
            directionArrow[4].gameObject.SetActive(false);
            //directionArrowBow[0].gameObject.SetActive(false);
            directionArrowBow[1].gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sortingOrder = -1;
            sprite.sortingOrder = -1;
            cameraSmooth.camerashake(2, 0.1f);
            relivecheck = true;
            isLive = false;
            Time.timeScale = 0.0f;
            stopWatch.stopwatch.Reset();
            stopWatch.stopwatch.Stop();
        }
    }


    private void backstart()
    {
        StartCoroutine(crwon.Restart());
        // StartCoroutine(level.Restart());
        if (GameObject.Find("stalactite"))
            for (int i = 0; i < dropObject.Length; i++)
                StartCoroutine(dropObject[i].Restart());

        if (GameObject.Find("bird"))
        {
            for (int i = 0; i < bird.Length; i++)
            {
                StartCoroutine(bird[i].Restart());
            }
        }
        StartCoroutine(SliderUI.Restart());
        StartCoroutine(relive.Restart());
        GetComponent<BoxCollider2D>().sharedMaterial = null;
        relivecheck = false;
        if (GetComponent<Animator>() != null)
            animator.SetBool("isCheck", false);

        transform.GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = 2;
        transform.GetChild(3).GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        cameraSmooth.stopShake();
        sprite.sortingOrder = 2;
        GetComponent<SpriteRenderer>().sortingOrder = 2;
        checkrun = 0;
    }
    
    public float checkFastDistance;
    public float checkHighMiddleDistance;
    public float checkMiddleDistance;
    public float checkSlowDistance;
    public bool relivecheck = false;
    public bool isLive = true;
    public float slowSpeed;
    public float middleSpeed;
    public float fastSpeed;
    public float checkDelay;

    public float reachRadius = 4.0f;
    public float timeScale;
    [HideInInspector] public Vector3 diff;
    private Vector3 direction;
    private CameraSmooth cameraSmooth;
    private bool checktime = true;
    private characterRelive relive;
    private Vector3 temp;

    [HideInInspector] public AudioSource bound;
    private CharacterCrown crwon;
    private CharacterInfo info;
    private CharacterLevelup level;
    private characterRelive Relive;
    private birdObject[] bird;
    private Transform[] directionArrowBow;
    private Transform[] directionArrow;
    private SpriteRenderer sprite;
    private float checkrun = 0;
    private float checkstay = 0.7f;
    private float timer = 0.0f;
    private float waitingTime = 0.5f;
    private GameObject gameoverUI;
    private DropObject[] dropObject;
    private stopWatch watch;
    private Animator animator;
    private GameObject FadeInOutObejct;
    private UICrownPos SliderUI;
    private Camera mainCamera;
    private GameObject PauseUI;

    [Header("GameLevel 조정")]
    private short Gamelevel;
}