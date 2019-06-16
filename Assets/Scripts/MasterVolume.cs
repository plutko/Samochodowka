using UnityEngine;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    private float masterVolume = 1f;
    public Slider volumeSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            masterVolume = PlayerPrefs.GetFloat("masterVolume");
        }
        volumeSlider.value = masterVolume;
    }

    void Update()
    {
        AudioListener.volume = masterVolume;
    }

    public void ChangeVolume(float volume)
    {
        masterVolume = volume;
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        PlayerPrefs.Save();
    }
}