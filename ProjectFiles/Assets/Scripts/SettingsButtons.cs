using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
	public GameObject PauseMenu, SettingsMenu;

	public void Resume() //Resumes game and lets player move again
	{
		Debug.Log("Resumed");
		PauseMenu.SetActive(false);
		SettingsMenu.SetActive(false);
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void sens()
	{
	}


	public void brightness()
	{
	}

	public void Back()
	{
		PauseMenu.SetActive(false);
		SettingsMenu.SetActive(true);
	}
}
