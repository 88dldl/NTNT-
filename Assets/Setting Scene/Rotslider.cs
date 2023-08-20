using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotslider : MonoBehaviour
{
    public Slider sensitivitySlider;
    public CamRotate camRotateScript;
    private void Awake()
    {
        camRotateScript = FindObjectOfType<CamRotate>();
    }

    private void Start()
    {
        if (camRotateScript != null)
        {
            sensitivitySlider.value = GetNormalizedSensitivity();
            sensitivitySlider.onValueChanged.AddListener(UpdateRotationSpeed);
        }
        else
        {
            Debug.LogWarning("CamRotate script not found.");
        }
    }

    public void SetSensitivity(float sensitivity)
    {
        float normalizedSensitivity = sensitivity / sensitivitySlider.maxValue;
        PlayerPrefs.SetFloat("MouseSensitivity", normalizedSensitivity);
        UpdateRotationSpeed(normalizedSensitivity);
    }
    

    private float GetNormalizedSensitivity()
    {
        return PlayerPrefs.GetFloat("MouseSensitivity", 0.5f) * sensitivitySlider.maxValue;
    }

    private void UpdateRotationSpeed(float normalizedSensitivity)
    {
        camRotateScript.SetRotationSpeed(normalizedSensitivity);

    }
}
