using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessScript : MonoBehaviour
{
    public Slider BrightnessSlider;

    public PostProcessProfile Brightness;
    public PostProcessLayer Layer;

    AutoExposure exposure;

    private const string BrightnessKey = "Brightness";

    void Start()
    {

        Brightness.TryGetSettings(out exposure);
        
        float savedBrightness = PlayerPrefs.GetFloat(BrightnessKey, 0.5f);
        BrightnessSlider.value = savedBrightness;

        AdjustBrightness(savedBrightness);
    }

    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;

            PlayerPrefs.SetFloat(BrightnessKey, value);
        }
        else
        {
            exposure.keyValue.value = .05f;

            PlayerPrefs.SetFloat(BrightnessKey, .05f);
        }
    }
}
