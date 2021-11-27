using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script will apply damage to the player.
/// </summary>
public class PlayerTakeDamage : MonoBehaviour
{
    [Tooltip("This is the Player Stats script used to hold the Player Stats.")]
    [SerializeField] PlayerStats playerStats;
    [Tooltip("This is the particle system that runs when the player takes damage.")]
    [SerializeField] ParticleSystem onHitParticle;

    public void TakeDamage(int damageTaken)
    {
        playerStats.CurrentHealth -= damageTaken;
        onHitParticle.Play();
    }
}
