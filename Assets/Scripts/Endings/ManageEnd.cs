using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageEnd : MonoBehaviour
{
    public GameObject choice;
    public GameObject[] toDisable;

    private static ManageEnd instance;

    private void Start()
    {
        instance = this;
        instance.choice.SetActive(false);
    }

    public static void ShowFinalChoice()
    {
        foreach (GameObject go in instance.toDisable)
        {
            if (go)
                go.SetActive(false);
        }
        instance.choice.SetActive(true);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ShowFinalChoice();
    }
#endif

    static public void DoEnd(int endNum)
    {
        if (endNum > 3) endNum = 3;

        if (endNum == 1)
        {
            if (MusicManager.instance)
                MusicManager.ChangeMusic(MusicManager.instance.endingOneMusic, 3f);
            CutsceneManager.nextCutScene = CutsceneManager.cutState.END_1;
        }
        if (endNum == 2)
        {
            if (MusicManager.instance)
                MusicManager.ChangeMusic(MusicManager.instance.endingTwoMusic, 3f);
            CutsceneManager.nextCutScene = CutsceneManager.cutState.END_2;
        }
        if (endNum == 3)
        {
            if (MusicManager.instance)
                MusicManager.ChangeMusic(MusicManager.instance.endingThreeMusic, 3f);
            CutsceneManager.nextCutScene = CutsceneManager.cutState.END_3;
        }

        SceneManager.LoadScene(5);
    }
}
