using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ElapsedTime : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI elapsedTimeText;

    void Start()
    {
        // Retrieve the elapsed time from PlayerPrefs
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);

        // Format the elapsed time into minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // Determine the correct wording for minutes
        string minutesText = (minutes == 1) ? "minute" : "minutes";

        // Determine the correct wording for seconds
        string secondsText = (seconds == 1) ? "second" : "seconds";

        // Display the elapsed time in the UI with correct wording
        if (minutes > 0)
        {
            elapsedTimeText.text = string.Format("You escaped in {0} {1} and {2} {3}", minutes, minutesText, seconds, secondsText);
        }
        else
        {
            elapsedTimeText.text = string.Format("You escaped in {0} {1}", seconds, secondsText);
        }
    }
}
