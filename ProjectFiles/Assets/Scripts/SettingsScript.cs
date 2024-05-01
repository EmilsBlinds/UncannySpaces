using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class SettingsScript : MonoBehaviour
{
    public GameObject PauseMenu, SettingsMenu;
    public FirstPersonControllerCustom playerController;
    public GameObject CameraOverlay, StaminaCanvas;


    void Start()
    {

    }

    void Update() //If Q is pressed, closes options menu
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (PauseMenu.activeSelf)
            {
                Resume();
                CameraOverlay.SetActive(true);
                StaminaCanvas.SetActive(true);
            }
        }

    }


    public void Resume()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerController.canMove = true;
        CameraOverlay.SetActive(true);
        StaminaCanvas.SetActive(true);
    }

}
