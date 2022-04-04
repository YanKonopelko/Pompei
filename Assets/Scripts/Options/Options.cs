using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Slider vfxSlider;
    public Slider musicSlider;
    private void Start()
    {
        //PlayerPrefs.SetFloat("MUSIC_VOLUME", MusicManager.volume);
        //PlayerPrefs.SetFloat("VFX_VOLUME", SoundManager.volume);
        vfxSlider.value = (PlayerPrefs.HasKey("VFX_VOLUME")) ? PlayerPrefs.GetFloat("VFX_VOLUME") : SoundManager.volume;
        musicSlider.value = (PlayerPrefs.HasKey("MUSIC_VOLUME")) ? PlayerPrefs.GetFloat("MUSIC_VOLUME") : MusicManager.volume;
    }
    public void BackToMenu()
    {
        PlayerPrefs.SetFloat("MUSIC_VOLUME", musicSlider.value);
        PlayerPrefs.SetFloat("VFX_VOLUME", vfxSlider.value);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void SliderVFXChanged(Slider slider)
    {
        SoundManager.ChangeVolume(slider.value);
    }

    public void SliderMusicChanged(Slider slider)
    {
        MusicManager.ChangeVolume(slider.value);
    }
}
