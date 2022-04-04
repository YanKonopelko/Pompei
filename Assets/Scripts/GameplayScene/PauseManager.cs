using UnityEngine;
using UnityEngine.UI;
public class PauseManager  : MonoBehaviour
{
    public bool isPaused = false;
    public Sprite paused;
    public Sprite unpaused;
    public GameObject _panel;
    public void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            transform.GetComponent<Image>().sprite = paused;
            _panel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            transform.GetComponent<Image>().sprite = unpaused;
            _panel.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }
}
