using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script handles a player looking around in first person.
/// </summary>
public class PlayerAim : MonoBehaviour
{
    [Tooltip("This is the input manager holding the input actions.")]
    [SerializeField] InputManager inputManager;
    [Tooltip("This is the transform of the camera that is looking around. The camera should be attached to the player.")]
    [SerializeField] Transform aimingCamera;
    [Tooltip("This is the mouse sensitivity on the X axis.")]
    [SerializeField] float mouseSensitivityX = 10.0f;
    [Tooltip("This is the mouse sensitivity on the Y axis.")]
    [SerializeField] float mouseSensitivityY = 10.0f;
    [Tooltip("This is the minimum angle that the player can look at. It stops the player looking down until the are looking behind themself.")]
    [SerializeField] float xClampMin = -85.0f;
    [Tooltip("This is the maximum angle that the player can look at. It stops the player looking up until the are looking behind themself.")]
    [SerializeField] float xClampMax = 85.0f;

    private Vector2 mouseMovement;
    private float xRotation;

    public float MouseSensitivityX { set { mouseSensitivityX = value; } }
    public float MouseSensitivityY { set { mouseSensitivityY = value; } }

    private void OnEnable()
    {
        mouseSensitivityX = PlayerPrefs.GetFloat("mouseSensitivityX", mouseSensitivityX);
        mouseSensitivityY = PlayerPrefs.GetFloat("mouseSensitivityY", mouseSensitivityY);
    }

    private void Update()
    {
        MouseInput();
    }

    public void MouseInput()
    {
        Vector2 mouseInput = new Vector2(inputManager.ThisPlayerControls.PlayerMovement.AimX.ReadValue<float>(), inputManager.ThisPlayerControls.PlayerMovement.AimY.ReadValue<float>());

        mouseMovement = new Vector2(mouseInput.x * mouseSensitivityX, mouseInput.y * mouseSensitivityY) * Time.deltaTime;

        xRotation -= mouseMovement.y;
        xRotation = Mathf.Clamp(xRotation, xClampMin, xClampMax);
        aimingCamera.transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        transform.rotation *= Quaternion.Euler(Vector3.up * mouseMovement.x);
    }
}
