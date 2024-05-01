using UnityEngine;
using UnityEngine.UI;

public class DotScript : MonoBehaviour
{
    public float beepInterval = 0.5f; // Time between beeps
    private Image DotImage;

    void Start()
    {
        DotImage = GetComponent<Image>();
        // Start the beeping coroutine
        InvokeRepeating("ToggleVisibility", 0f, beepInterval);
    }

    void ToggleVisibility()
    {
        // Toggle dot visibility
        DotImage.enabled = !DotImage.enabled;
    }
}
