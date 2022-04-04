using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public VideoPlayer player;

    public float fadeSpeed = 0.5f;

    private IEnumerator Start()
    {
        Camera.main.backgroundColor = Color.white;

        player.Prepare();
        yield return new WaitUntil(() => player.isPrepared);
        player.Play();
        print(player.isPlaying);
        yield return new WaitWhile(()=> player.isPlaying);
        yield return new WaitForSeconds(1f);

        Camera.main.backgroundColor = Color.black;
        
        while (player.targetCameraAlpha > 0)
        {
            player.targetCameraAlpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        StartMenu.hasStartBeenLoaded = false;
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartMenu.hasStartBeenLoaded = false;
            if (player.isPlaying)
                player.Stop();
            StopAllCoroutines();
            SceneManager.LoadScene(1);
        }
    }
}
