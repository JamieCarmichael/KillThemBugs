using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script takes an input and then runs the melee attack.
/// </summary>
public class MeleeAttack : MonoBehaviour
{
    [Tooltip("This is the input manager.")]
    [SerializeField] InputManager inputManager;
    [Tooltip("This is the animator that runs the melee attack.")]
    [SerializeField] Animator animator;
    [Tooltip("This is the collider that is used to trigger the damage.")]
    [SerializeField] Collider meleeCollider;
    [Tooltip("This is the name of the Melee bool that initiates the animation.")]
    [SerializeField] string meleeBool = "Melee";
    [Tooltip("This is the gun manager that is disabled so you can't shoot while meleeing.")]
    [SerializeField] GunManager gunManager;
    [Tooltip("This is the audio source for the fly swatter.")]
    [SerializeField] AudioSource thisAudioSource;

    private void Start()
    {
        inputManager.ThisPlayerControls.PlayerMovement.Melee.performed += PreformMeleeAttack;
    }

    private void PreformMeleeAttack(InputAction.CallbackContext context)
    {
        animator.SetBool(meleeBool, true);
        gunManager.enabled = false;
        thisAudioSource.Play();
    }
    public void TurnOnMeleeCollider()
    {
        meleeCollider.enabled = true;
    }
    public void TurnOffMeleeCollider()
    {
        meleeCollider.enabled = false;
    }
    public void EndMeleeAnimation()
    {
        animator.SetBool(meleeBool, false);
        gunManager.enabled = true;
    }
}
