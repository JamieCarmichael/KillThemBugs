using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
/// <summary>
/// Author: Jamie Carmichael
/// Datails: This script runs events during the anumation.
/// </summary>

public class BeetleAttackAnimations : MonoBehaviour
{
    [Tooltip("This is the animator being animated. This should be on this asset.")]
    [SerializeField] Animator animator;
    [SerializeField] string attackAnimationName;
    [Tooltip("This is an event that runs during the animation to start the attack.")]
    [SerializeField] UnityEvent startAttack;
    [Tooltip("This is the event that runs at the end of the attack to end the attack.")]
    [SerializeField] UnityEvent endAttack;

    [SerializeField] NavMeshAgent thisNavMeshAgent;
    public void AttackStart()
    {
        animator.SetBool(attackAnimationName, false);
        startAttack?.Invoke();
    }
    public void AttackEnd()
    {
        endAttack?.Invoke();
    }

}
