using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class defeatscreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI elapsedTimeText;


    void Start()
    {
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        elapsedTimeText.text = string.Format("You survived for {0:00}:{1:00}", minutes, seconds);

    }

    private void Update()
	{
		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(0);
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

	}
}
