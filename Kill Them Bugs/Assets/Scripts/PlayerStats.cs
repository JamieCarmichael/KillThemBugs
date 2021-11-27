using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script holds basic player stats and has methods to change them. 
/// </summary>
public class PlayerStats : MonoBehaviour
{
    [Tooltip("This is the In Game UI Script.")]
    [SerializeField] InGameUI inGameUI;
    [Tooltip("This is the maximum health the player can have.")]
    [SerializeField] int maxHealth = 10;
    [Tooltip("This is the health at the start of the level.")]
    [SerializeField] int startHealth = 10;
    [Tooltip("This is the players animator. Likly attached to the player.")]
    [SerializeField] Animator playerAnimator;
    [Tooltip("This is the bool that is triggered on the animatior when the player dies.")]
    [SerializeField] string deathBool = "Dead";
    [Tooltip("This is the scriptable object that has the scene navigation.")]
    [SerializeField] SceneNavigation sceneNavigation;
    [Tooltip("This is the audio source for when the player takes damage.")]
    [SerializeField] AudioSource audioSource;

    private int currentHealth;

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            inGameUI.SetHealthImage(currentHealth, maxHealth);
            audioSource.Play();
            if (currentHealth == 0)
            {
                playerAnimator.SetBool(deathBool, true);
                //Debug.Log("Player Died");
            }
        }
    }

    private void Start()
    {
        currentHealth = startHealth;
    }

    public void PlayerDead()
    {
        sceneNavigation.LoadCurrentScene();
    }

    public void ResetHealth()
    {
        currentHealth = startHealth;
    }
}
