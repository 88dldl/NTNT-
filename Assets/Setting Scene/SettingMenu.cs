using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public Slider sensitivitySlider;
    Resolution[] resolutions;
    // public CamRotate camRotateScript;
    public GameObject camrotate;
    public GameObject now;

    public void Start ()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // camRotateScript = FindObjectOfType<CamRotate>().GetComponent<CamRotate>();
        // camRotateScript = GameObject.FindWithTag("MainCamera").GetComponent<CamRotate>();
        camrotate = GameObject.FindWithTag("MainCamera");
        Debug.Log(camrotate.name);
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 0.5f);
        SetSensitivity(savedSensitivity);
        //마우스 감도 유지

        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        SetVolume(savedVolume);
        //소리 유지
        // now.SetActive(false);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
        PlayerPrefs.SetFloat("Volume", volume);
        Debug.Log(volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        Debug.Log(sensitivity);

        if (camrotate.GetComponent<CamRotate>() != null)
        {
            camrotate.GetComponent<CamRotate>().SetRotationSpeed(sensitivity);
        }
    }
    public void BackTo(){
        now.SetActive(false);
    }

}
