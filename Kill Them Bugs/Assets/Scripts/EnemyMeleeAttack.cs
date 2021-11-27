using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script handles the melee attack done by an enemy.
/// </summary>
public class EnemyMeleeAttack : MonoBehaviour
{
    [Tooltip("This is the damage done with the melee attack.")]
    [SerializeField] int attackDamage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerTakeDamage>(out PlayerTakeDamage playerTakeDamage))
        {
            playerTakeDamage.TakeDamage(attackDamage);
            gameObject.SetActive(false);
        }
    }
}
