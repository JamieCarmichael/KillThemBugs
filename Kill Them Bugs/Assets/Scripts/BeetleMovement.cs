using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using Cinemachine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script moves an agent with a navmesh agent towords another asset. If they get close to the target they initiate an animation which should have events in it to trigger events within this script.
/// </summary>

public class BeetleMovement : MonoBehaviour
{
    [Tooltip("This is the player that wil be chased.")]
    [SerializeField] GameObject player;
    [Tooltip("This is the navmesh agent being moved. This should be on this asset.")]
    [SerializeField] NavMeshAgent thisNavMeshAgent;
    [Tooltip("This is the animator being animated. This should be on this asset.")]
    [SerializeField] Animator animator;
    [Tooltip("This is the distance that is checked when finding a navmesh location. Rule of thumb is twice the assets hight.")]
    [SerializeField] float checkRadius = 3.0f;
    [Tooltip("This is the distyance to the player when the attack is triggered. This is from pivot point to pivot point so you will need to anticipate the size of the assets.")]
    [SerializeField] float distanceToPlayer;
    [Tooltip("This is the name of the bool that needs to be true to trigger the animation.")]
    [SerializeField] string attackAnimationName;
    [Tooltip("This is where the raycast that looks for a position to charge at starts.")]
    [SerializeField] Transform raycastOrigin;
    [Tooltip("This is how far is checked for a position to charge at.")]
    [SerializeField] float raycastDistance = 100f;
    [Tooltip("This is the layer mask that is checked for the position to charge at. Ensure it does not include the beetles layer.")]
    [SerializeField] LayerMask layerMask;
    [Tooltip("This is the speed while charging.")]
    [SerializeField] float chargeSpeed = 10.0f;
    [Tooltip("This is the acceseration while charging.")]
    [SerializeField] float chargeAcceleration = 15.0f;
    [Tooltip("This is the speed when not charging.")]
    [SerializeField] float walkSpeed = 5.0f;
    [Tooltip("This is the acceleration when not charging.")]
    [SerializeField] float walkAcceleration = 10.0f;
    [Tooltip("This is the distance that will be charged.")]
    [SerializeField] float chargeDistance = 20.0f;
    [Tooltip("This is how close to the target the charge will stop.")]
    [SerializeField] float chargeStoppingDistence = 0.1f;

    [SerializeField] float minChargeDistance = 1.0f;

    [SerializeField] float maxAttackTime = 7.0f;

    [Tooltip("This should be private!!")]
    [SerializeField] bool isAttacking = false;

    [SerializeField] bool isCharging = false;

    private NavMeshHit navMeshHit;
    private int areaMask;
    private RaycastHit hit;

    private EnemyAnimations thisEnemyAniumations;

    private Vector3 targetPos;
    private Vector3 target;
    Vector3 raycastDirection;

    private float timeToStopAttack;

    private void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<InputManager>().gameObject;
        }
        //thisNavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        areaMask = NavMesh.AllAreas;
    }

    private void Update()
    {
        if (!isAttacking)
        {
            if (thisNavMeshAgent.isActiveAndEnabled)
            {
                if (Vector3.Distance(player.transform.position, transform.position) < distanceToPlayer)
                {
                    thisNavMeshAgent.SetDestination(transform.position);
                    thisNavMeshAgent.isStopped = true;
                    this.gameObject.transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                    if (animator != null)
                    {
                        animator.SetBool(attackAnimationName, true);
                        isAttacking = true;
                        timeToStopAttack = Time.time + maxAttackTime;
                    }
                }
                else if (NavMesh.SamplePosition(player.transform.position, out navMeshHit, checkRadius, areaMask))
                {
                    thisNavMeshAgent.isStopped = false;
                    thisNavMeshAgent.SetDestination(navMeshHit.position);
                }
            }
        }
        else if (isCharging)
        {
            if (thisNavMeshAgent.isActiveAndEnabled)
            {
                if (Vector3.Distance(targetPos, transform.position) < thisNavMeshAgent.stoppingDistance + chargeStoppingDistence)
                {
                    EndCharge();
                }

                else if (targetPos == Vector3.zero)
                {
                    EndCharge();
                }
                else if (Vector3.Distance(thisNavMeshAgent.destination, transform.position) < thisNavMeshAgent.stoppingDistance + chargeStoppingDistence)
                {
                    EndCharge();
                }
            }
        }
        if (isAttacking)
        {
            if (Time.time > timeToStopAttack)
            {
                EndCharge();
            }
        }
    }

    public void ChargeAttack()
    {
        isCharging = true;
        target = player.GetComponentInChildren<CinemachineVirtualCamera>().transform.position;
        target.y = raycastOrigin.position.y;
        raycastDirection = (target - raycastOrigin.position).normalized;

        Physics.Raycast(raycastOrigin.position, raycastDirection, out hit, raycastDistance, layerMask, QueryTriggerInteraction.Ignore);
        //Debug.DrawRay(raycastOrigin.position, raycastDirection, Color.red, raycastDistance);

        if (hit.point != Vector3.zero)
        {
            if (NavMesh.SamplePosition(hit.point, out navMeshHit, checkRadius, areaMask))
            {
                if (Vector3.Distance(hit.point,transform.position) < minChargeDistance)
                {
                    if (NavMesh.SamplePosition(targetPos, out navMeshHit, checkRadius, areaMask))
                    {
                        thisNavMeshAgent.isStopped = false;
                        thisNavMeshAgent.SetDestination(navMeshHit.position);
                        thisNavMeshAgent.speed = chargeSpeed;
                        thisNavMeshAgent.acceleration = chargeAcceleration;
                        targetPos = navMeshHit.position;
                    }
                    else
                    {
                        NoTarget();
                    }
                }
                else
                {
                    targetPos = raycastOrigin.position + (transform.forward * chargeDistance);
                    if (NavMesh.SamplePosition(targetPos, out navMeshHit, checkRadius, areaMask))
                    {
                        thisNavMeshAgent.isStopped = false;
                        thisNavMeshAgent.SetDestination(navMeshHit.position);
                        thisNavMeshAgent.speed = chargeSpeed;
                        thisNavMeshAgent.acceleration = chargeAcceleration;
                        targetPos = navMeshHit.position;
                    }
                    else
                    {
                        NoTarget();
                    }
                }

            }
            else
            {
                targetPos = raycastOrigin.position + (transform.forward * chargeDistance);
                if (NavMesh.SamplePosition(targetPos, out navMeshHit, checkRadius, areaMask))
                {
                    thisNavMeshAgent.isStopped = false;
                    thisNavMeshAgent.SetDestination(navMeshHit.position);
                    thisNavMeshAgent.speed = chargeSpeed;
                    thisNavMeshAgent.acceleration = chargeAcceleration;
                    targetPos = navMeshHit.position;
                }
                else
                {
                    NoTarget();
                }
            }
        }
        else
        {
            targetPos = raycastOrigin.position + (transform.forward * chargeDistance);
            if (NavMesh.SamplePosition(targetPos, out navMeshHit, checkRadius, areaMask))
            {
                thisNavMeshAgent.isStopped = false;
                thisNavMeshAgent.SetDestination(navMeshHit.position);
                thisNavMeshAgent.speed = chargeSpeed;
                thisNavMeshAgent.acceleration = chargeAcceleration;
                targetPos = navMeshHit.position;
            }
            else
            {
                NoTarget();
            }
        }
    }
    public void EndCharge()
    {
        thisNavMeshAgent.speed = walkSpeed;
        thisNavMeshAgent.acceleration = walkAcceleration;
        isAttacking = false;
        isCharging = false;
        if (thisEnemyAniumations == null)
        {
            thisEnemyAniumations = animator.gameObject.GetComponent<EnemyAnimations>();
        }
        thisEnemyAniumations.AttackEnd();
    }

    private void NoTarget()
    {
        if (NavMesh.SamplePosition(player.transform.position, out navMeshHit, checkRadius, areaMask))
        {
            thisNavMeshAgent.isStopped = false;
            thisNavMeshAgent.SetDestination(navMeshHit.position);
        }
    }
}
