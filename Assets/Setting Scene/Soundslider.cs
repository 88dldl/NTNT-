using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Soundslider : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        UpdateAudioListenerVolume();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    private void UpdateAudioListenerVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
    }
}
