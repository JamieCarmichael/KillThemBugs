using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script aims and launches a projetcile.
/// </summary>
public class EnemyRangedAttack : MonoBehaviour
{
    [Tooltip("This is the projectile launched.")]
    [SerializeField] GameObject projectile;

    public void RangeAttack()
    {
        GameObject player = GetComponentInParent<FlyMovement>().Player;

        Vector3 targetPosition = player.GetComponentInChildren<CinemachineVirtualCamera>().transform.position;

        Instantiate(projectile, this.transform.position, Quaternion.LookRotation(targetPosition - this.transform.position));
    }
}
