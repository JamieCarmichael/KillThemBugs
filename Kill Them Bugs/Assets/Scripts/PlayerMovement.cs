using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script moves a player using a character controler. It has movement, jumping and gravity. Requires an input manager to give it inputs.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Tooltip("This is the input manager holding the input actions.")]
    [SerializeField] InputManager inputManager;
    [Tooltip("This is the character controler that will be moved.")]
    [SerializeField] CharacterController characterController;
    [Tooltip("This is the speed the player will move at.")]
    [SerializeField] float speed = 10.0f;
    [Tooltip("This is the Layer Mask that will be check to see if the player is grounded. Make sure this does not include the player's layer.")]
    [SerializeField] LayerMask groundCheckLayerMask;
    [Tooltip("This is the distance from the player that will be checked for ground. 0.1f is recommended")]
    [SerializeField] float groundCheckDistance = 0.1f;
    [Tooltip("This is a multiplier to increase gravities effect on the player. Recommended 2; ")]
    [SerializeField] float gravityMultiplier = 2.0f;
    [Tooltip("This is the height that the player will jump.")]
    [SerializeField] float jumpHeight = 2.0f;
    [Tooltip("This is the animator that is animating the player.")]
    [SerializeField] Animator thisAnimatior;
    [Tooltip("This is the audio source for moving and jumping.")]
    [SerializeField] AudioSource thisAudioSource;
    [Tooltip("This is an array of audio clips for jumping.")]
    [SerializeField] AudioClip[] jumpAudioClips;
    [Tooltip("This is an array of audio clips for walking.")]
    [SerializeField] AudioClip[] walkingAudioClips;

    private int jumpNumber = 0;
    private int walkNumber = 0;


    private Vector3 horizontalMovement;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private RaycastHit groundCheckHit;

    private void Start()
    {
        inputManager.ThisPlayerControls.PlayerMovement.Jump.performed += context => JumpPlayer();
    }

    private void Update()
    {
        CheckGrounded();
        
        MovePlayer(inputManager.ThisPlayerControls.PlayerMovement.Movement.ReadValue<Vector2>());

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void CheckGrounded()
    {
        Vector3 sphereOrigin = this.gameObject.transform.position;
        sphereOrigin.y += characterController.radius;
        isGrounded = Physics.SphereCast(sphereOrigin, characterController.radius, Vector3.down, out groundCheckHit, groundCheckDistance, groundCheckLayerMask, QueryTriggerInteraction.Ignore);
        
        if (isGrounded && playerVelocity.y <= 0.0f)
        {
            playerVelocity.y = 0.0f;
        }
        else
        {
            playerVelocity += Physics.gravity * gravityMultiplier * Time.deltaTime;
        }
    }

    private void MovePlayer(Vector2 moveInput)
    {
        if (moveInput.magnitude > 1)
        {
            moveInput = moveInput.normalized;
        }
        if (moveInput.magnitude != 0)
        {
            thisAnimatior.SetBool("IsWalking", true);
            if (isGrounded)
            {
                if (!thisAudioSource.isPlaying)
                {
                    //Play audio when walking on the ground.
                    walkNumber = (walkNumber + 1) % walkingAudioClips.Length;
                    thisAudioSource.clip = walkingAudioClips[walkNumber];
                    thisAudioSource.Play();
                }

            }
            else
            {
                //Stopping walking audio if not grounded but still moving
                for (int i = 0; i < walkingAudioClips.Length; i++)
                {
                    if (thisAudioSource.clip == walkingAudioClips[i])
                    {
                        thisAudioSource.Stop();
                    }
                }
            }
        }
        else
        {
            thisAnimatior.SetBool("IsWalking", false);

            //Stopping walking audio if not moving
            for (int i = 0; i < walkingAudioClips.Length; i++)
            {
                if (thisAudioSource.clip == walkingAudioClips[i])
                {
                    thisAudioSource.Stop();
                }
            }
        }
        horizontalMovement = (transform.right * moveInput.x) + (transform.forward * moveInput.y);
        characterController.Move(horizontalMovement * speed * Time.deltaTime);
    }

    private void JumpPlayer()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y * gravityMultiplier);

            //Play audio when jumping.
            jumpNumber = (jumpNumber + 1) % jumpAudioClips.Length;
            thisAudioSource.clip = jumpAudioClips[jumpNumber];
            thisAudioSource.Play();
        }
    }
}
