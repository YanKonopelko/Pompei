using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 0.1f;

    private IEnumerator ienum;

    private static FadeInOut instance;
    private void Start()
    {
        instance = this;
        DoFade(0);
    }
    public static void DoFade(float targetAlpha)
    {
        if (instance.fadeImage)
        {
            if (instance.ienum != null)
                instance.StopCoroutine(instance.ienum);
            instance.StartCoroutine(instance.ienum = instance.Fade(targetAlpha));
        }
    }

    private IEnumerator Fade(float alpha)
    {
        if (!fadeImage.gameObject.activeSelf)
            fadeImage.gameObject.SetActive(true);

        if (alpha > 0)
        {
            while (fadeImage.color.a < (alpha - 0.001f))
            {
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a + Time.deltaTime * fadeSpeed);
                yield return new WaitForEndOfFrame();
            }
        } else
        {
            while (fadeImage.color.a > (alpha + 0.001f))
            {
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - Time.deltaTime * fadeSpeed);
                yield return new WaitForEndOfFrame();
            }
        }
        yield return null;
    }
}
