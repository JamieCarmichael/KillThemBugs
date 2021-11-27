using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script does damage on trigger enter.
/// </summary>
public class MeleeDamage : MonoBehaviour
{
    [Tooltip("This is the damage done.")]
    [SerializeField] int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<TakeDamage>(out TakeDamage takeDamage))
        {
            takeDamage.ReceiveDamage(damage, transform.position);
        }
    }
}
