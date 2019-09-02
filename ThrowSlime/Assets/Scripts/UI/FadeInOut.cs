using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    public void FadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeIn(fadeOutTime, nextEvent));
    }

    public void FadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        StartCoroutine(CoFadeOut(fadeOutTime, nextEvent));
    }

    IEnumerator CoFadeIn(float fadeOutTime, System.Action nextEvent = null)
    {
        Image objectimage = this.gameObject.GetComponent<Image>();
        Color tempColor = objectimage.color;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.unscaledDeltaTime / fadeOutTime;
            objectimage.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;

            yield return null;
        }

        objectimage.color = tempColor;
        if (nextEvent != null) nextEvent();
        //StartCoroutine(CoFadeOut(fadeOutTime));
        //StopCoroutine(CoFadeIn(0.0f));
    }

    IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        Image objectimage = this.gameObject.GetComponent<Image>();
        Color tempColor = objectimage.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.unscaledDeltaTime / fadeOutTime;
            objectimage.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        objectimage.color = tempColor;
        if (nextEvent != null) nextEvent();
        //StartCoroutine(CoFadeIn(fadeOutTime));
        //StopCoroutine(CoFadeOut(0.0f));

    }
}
