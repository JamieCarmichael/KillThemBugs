using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script handles swithcing guns and shoots the active gun.
/// </summary>
public class GunManager : MonoBehaviour
{
    [Tooltip("This is the input manager holding the input actions.")]
    [SerializeField] InputManager inputManager;
    [Tooltip("This is a list of the guns that the player has. If this is changed let Jamie know as the order is used in the AmmoPickUp script.")]
    [SerializeField] private List<Gun> guns;
    [Tooltip("This is the audio source for the ammo pick up sound.")]
    [SerializeField] AudioSource audioSource;

    private int currentGun;

    private void Start()
    {
        inputManager.ThisPlayerControls.PlayerMovement.SwitchWeapon.performed += SwitchWeapon;
        inputManager.ThisPlayerControls.PlayerMovement.Shoot.performed += ShootInput;
        inputManager.ThisPlayerControls.PlayerMovement.Reload.performed += ReloadCurrentWeapon;

        SetUpGun();
    }

    private void Update()
    {
        if (guns[currentGun].IsFullAuto)
        {
            ShootInput(inputManager.ThisPlayerControls.PlayerMovement.Shoot.ReadValue<float>());
        }
    }

    private void ShootInput(float inputValue)
    {
        if (inputValue > 0)
        {
            guns[currentGun].ShootGun();
        }
    }
    private void ShootInput(InputAction.CallbackContext context)
    {
        if (!guns[currentGun].IsFullAuto)
        {
            guns[currentGun].ShootGun();
        }
    }

    private void SwitchWeapon(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            currentGun = (currentGun + 1) % (guns.Count);

            SetUpGun();
        }
        else
        {
            if (currentGun == 0)
            {
                currentGun += guns.Count;
            }
            currentGun = (currentGun - 1) % (guns.Count);

            SetUpGun();
        }
    }
    private void SetUpGun()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            if (i == currentGun)
            {
                guns[i].gameObject.SetActive(true);
            }
            else
            {
                guns[i].gameObject.SetActive(false);
            }
        }
    }
    private void ReloadCurrentWeapon(InputAction.CallbackContext context)
    {
        StartCoroutine(guns[currentGun].Reload());
    }
    public void increaseAmmo(int ammoIncrease, int gunNumber)
    {
        guns[gunNumber].CurrentAmmoToCarry += ammoIncrease;
        audioSource.Play();
    }
    public void ResetAllGuns()
    {
        foreach (var thisgun in guns)
        {
            thisgun.ResetAmmo();
        }
    }
}
