using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 0.1f;

    private IEnumerator ienum;

    public static bool hasStartBeenLoaded = false;
    private IEnumerator Start()
    {
        ienum = null;
        fadeImage.gameObject.SetActive(!hasStartBeenLoaded);
        MusicManager.ChangeMusic(MusicManager.instance.mainMenuMusic, 10f);
        if (!hasStartBeenLoaded)
        {
            hasStartBeenLoaded = true;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
            while (fadeImage.color.a > 0f)
            {
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - Time.deltaTime * fadeSpeed);
                yield return new WaitForEndOfFrame();
            }
        }
        yield return new WaitForEndOfFrame();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ToGameplay()
    {
        if (ienum != null)
            return;
        StopAllCoroutines();
        StartCoroutine(ienum = GoToGameplayWithEffects());
    }

    private IEnumerator GoToGameplayWithEffects()
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
        while (fadeImage.color.a < 1f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a + Time.deltaTime * fadeSpeed);
            yield return new WaitForEndOfFrame();
        }
        MusicManager.ChangeMusic(MusicManager.instance.gameplayMusic, 4f);
        CutsceneManager.nextCutScene = CutsceneManager.cutState.START;
        SceneManager.LoadScene(5);
    }

    public void ToOptions()
    {
        SceneManager.LoadScene(3);
    }
    public void ToCredits()
    {
        SceneManager.LoadScene(4);
    }
}
