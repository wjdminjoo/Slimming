using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CautionFade : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(isCheck());
    }
    private void Update()
    {
        GetComponent<RectTransform>().sizeDelta -= new Vector2(160, 90);
        if (GetComponent<RectTransform>().sizeDelta.x <= 1920)
            GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 1080);
        if(isAlpha)
        GetComponent<Image>().color -= new Color32(0, 0, 0, 10);

    }

    IEnumerator isCheck()
    {
        yield return new WaitForSeconds(2.0f);
        isAlpha =true;
    }
    private bool isAlpha = false;
}
