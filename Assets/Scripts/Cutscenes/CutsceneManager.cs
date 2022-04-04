using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public enum cutState { START = 0, END_1, END_2, END_3 };
    public static cutState nextCutScene = cutState.START;

    public bool enableInStart = true;
    public bool clickSkip = true;

    public Image cutSceneItself;

    public GameObject pressAnyKey;

    public Sprite[] startCutScene;
    public Sprite[] endingOneCutScene;
    public Sprite[] endingTwoCutScene;
    public Sprite[] endingThreeCutScene;

    private static CutsceneManager instance;

    private static IEnumerator ienum;
    private static IEnumerator ienum_wait;
    private bool doneShowing = true;

    public float waitForSlide = 3f;
    private void Start()
    {
        instance = this;

        pressAnyKey.SetActive(false);
        PlayCutScene();
    }

    public static void PlayCutScene()
    {
        cutState scene = nextCutScene;

        if (ienum != null)
            instance.StopCoroutine(ienum);
        switch (scene)
        {
            case (cutState.START):
                {
                    instance.StartCoroutine(ienum = instance.PlaySomeShit(instance.startCutScene));
                    break;
                }
            case (cutState.END_1):
                {
                    instance.StartCoroutine(ienum = instance.PlaySomeShit(instance.endingOneCutScene));
                    break;
                }
            case (cutState.END_2):
                {
                    instance.StartCoroutine(ienum = instance.PlaySomeShit(instance.endingTwoCutScene));
                    break;
                }
            case (cutState.END_3):
                {
                    instance.StartCoroutine(ienum = instance.PlaySomeShit(instance.endingThreeCutScene));
                    break;
                }
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (ienum_wait != null)
                StopCoroutine(ienum_wait);
            doneShowing = true;
        }
    }

    private IEnumerator PlaySomeShit(Sprite[] images)
    {
        for (int i = 0; i < images.Length; i++)
        {
            doneShowing = false;
            if (ienum_wait != null)
                StopCoroutine(ienum_wait);
            cutSceneItself.sprite = images[i];
            if (i < images.Length - 1)
                StartCoroutine(ienum_wait = WaitSomeShit());
            else
                StartCoroutine(WaitAfterLastSlide());
            yield return new WaitUntil(() => doneShowing);
        }

        switch (nextCutScene)
        {
            case (cutState.START):
                {
                    SceneManager.LoadScene(2);
                    break;
                }
            default:
                {
                    if (MusicManager.instance)
                        MusicManager.ChangeMusic(MusicManager.instance.creditsMusic, 5f);
                    SceneManager.LoadScene(4);
                    break;
                }
        }
    }

    private IEnumerator WaitSomeShit()
    {
        yield return new WaitForSeconds(waitForSlide);
        doneShowing = true;
    }

    private IEnumerator WaitAfterLastSlide()
    {
        yield return new WaitForSeconds(waitForSlide);
        pressAnyKey.SetActive(true);
    }
}
