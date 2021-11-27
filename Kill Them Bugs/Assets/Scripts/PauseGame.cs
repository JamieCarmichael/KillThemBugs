using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script pauses the game.
/// </summary>
public class PauseGame : MonoBehaviour
{
    [Tooltip("This is the input manager holding the input actions.")]
    [SerializeField] InputManager inputManager;
    [Tooltip("This is the game object for the pause menu.")]
    [SerializeField] GameObject pausePanel;

    private bool gamePaused = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inputManager.ThisPlayerControls.PlayerMovement.Escape.performed += Pause;
        inputManager.ThisPlayerControls.InMenu.Escape.performed += Pause;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1.0f;
        inputManager.ThisPlayerControls.PlayerMovement.Disable();
        inputManager.ThisPlayerControls.InMenu.Disable();
    }
    private void Pause(InputAction.CallbackContext context)
    {
        if (!gamePaused)
        {
            Time.timeScale = 0.0f;
            gamePaused = !gamePaused;
            pausePanel.SetActive(gamePaused);
            inputManager.ThisPlayerControls.PlayerMovement.Disable();
            inputManager.ThisPlayerControls.InMenu.Enable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            gamePaused = !gamePaused;
            pausePanel.SetActive(gamePaused);
            inputManager.ThisPlayerControls.InMenu.Disable();
            inputManager.ThisPlayerControls.PlayerMovement.Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void Pause()
    {
        if (!gamePaused)
        {
            Time.timeScale = 0.0f;
            gamePaused = !gamePaused;
            pausePanel.SetActive(gamePaused);
            inputManager.ThisPlayerControls.PlayerMovement.Disable();
            inputManager.ThisPlayerControls.InMenu.Enable();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            gamePaused = !gamePaused;
            pausePanel.SetActive(gamePaused);
            inputManager.ThisPlayerControls.InMenu.Disable();
            inputManager.ThisPlayerControls.PlayerMovement.Enable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
