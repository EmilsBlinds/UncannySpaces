using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class ControlsPanelScript : MonoBehaviour
{
    public GameObject PauseMenu, SettingsMenu, ControlsMenu;
    public FirstPersonControllerCustom playerController;
    public GameObject CameraOverlay, StaminaCanvas;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ControlsMenu.activeSelf)
            {
                Resume();

            }
        }

        
    }


    public void Resume()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerController.canMove = true;
        CameraOverlay.SetActive(true);
        StaminaCanvas.SetActive(true);
    }

}
