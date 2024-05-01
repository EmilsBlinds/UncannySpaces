using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public FirstPersonControllerCustom playerController;
    public GameObject CameraOverlay, StaminaCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!PauseMenu.activeSelf)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerController.canMove = false;

        CameraOverlay.SetActive(false);
        StaminaCanvas.SetActive(false);
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerController.canMove = true;

        CameraOverlay.SetActive(true);
        StaminaCanvas.SetActive(true);
    }
}
