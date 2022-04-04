using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void BackToMenu()
    {
        MusicManager.ChangeMusic(MusicManager.instance.mainMenuMusic);
        SceneManager.LoadScene(1);
    }
}
