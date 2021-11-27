using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details this script handles the inputs for the player and then pushes the values to other scripts to do the actions.
/// </summary>
public class InputManager : MonoBehaviour
{

    private PlayerControls playerControls;
    public PlayerControls ThisPlayerControls
    {
        get
        {
            return playerControls;
        }
    }

    private void Awake()
    {
        playerControls = new PlayerControls();


        playerControls.PlayerMovement.Enable();



    }

    private void OnDisable()
    {
        playerControls.PlayerMovement.Disable();
    }
}
