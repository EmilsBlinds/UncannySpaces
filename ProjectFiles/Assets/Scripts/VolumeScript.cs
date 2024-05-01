using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Initialize the slider value to match the current volume
        volumeSlider.value = AudioListener.volume;
    }

    public void SetVolume(float volume)
    {
        // Update the AudioListener volume based on the slider value
        AudioListener.volume = volume;
    }
}
