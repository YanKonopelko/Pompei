using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;

    public void Lose()
    {
        _deathPanel.SetActive(true);
        SoundManager.PlaySound(SoundManager.instance.DeathSound);
        GameObject.Find("Player").GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine("Restart");
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        MusicManager.ChangeMusic(MusicManager.instance.gameplayMusic);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
