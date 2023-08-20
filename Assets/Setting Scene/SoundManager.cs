using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider sound_slider;
    private float preSoundValue;

    public void OnMuteClick(bool isOn)
    {
        if(isOn)
        {
            preSoundValue = sound_slider.value;

            sound_slider.value = 0;
        }
        else
        {
            sound_slider.value = preSoundValue;
        }
    }
}
