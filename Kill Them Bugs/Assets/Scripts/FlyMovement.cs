using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Cinemachine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script moves an agent with a navmesh agent towords another asset. If they get close to the target they initiate an animation which should have events in it to trigger events within this script. It will stop the agent from moving if it is in range and can see the player.
/// </summary>

public class FlyMovement : MonoBehaviour
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
    [Tooltip("This the the location the attack is launched from.")]
    [SerializeField] GameObject attackLocation;
    [Tooltip("This is the layer mask checked when identifying if there is a clear line of sight on the player.")]
    [SerializeField] LayerMask layersToCheck;
    [Tooltip("This is how long the agent takes between shots.")]
    [SerializeField] float timeBetweenAttacks = 3.0f;

    private Vector3 targetDirection;
    private Vector3 attackPos;
    private float timeToAttack;
    private Transform playersFace;
    private NavMeshHit navMeshHit;
    private int areaMask;


    [Tooltip("The minimum speed that the ant will move at.")]
    [SerializeField] float minSpeed = 5.0f;
    [Tooltip("The maximum speed that the ant will move at and the chase speed.")]
    [SerializeField] float maxSpeed = 8.0f;
    [Tooltip("The time between finding new locations to walk to minimunm.")]
    [SerializeField] float minTimeToRetarget = 2.0f;
    [Tooltip("The time between finding new locations to walk to maximum.")]
    [SerializeField] float maxTimeToRetarget = 4.0f;
    [Tooltip("Distance from ant that a random position is found from. Half of this is the radius of the area searched for the random position.")]
    [SerializeField] float randomPosDDistance = 5.0f;

    private Vector3 targetPosition;
    private float timeToRetarget;
    float heightDifference;
    private Vector3 directionToTarget;
    private Vector3 randomPos;
    private float safeHeightDifference = 1.0f;
    private AudioSource thisAudioSource;

    public GameObject Player
    {
        get
        {
            return player;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<InputManager>().gameObject;
        //thisNavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        areaMask = NavMesh.AllAreas;
        playersFace = player.GetComponentInChildren<CinemachineVirtualCamera>().transform;
    }
    private void OnEnable()
    {
        thisAudioSource = this.gameObject.GetComponent<AudioSource>();
        thisAudioSource.enabled = true;
    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < distanceToPlayer)
        {
            RaycastHit hit;

            attackPos = attackLocation.transform.position;
            targetDirection = playersFace.position - attackPos;
            //Debug.DrawRay(attackPos, targetDirection, Color.green);
            if (Physics.Raycast(attackPos, targetDirection, out hit, distanceToPlayer, layersToCheck, QueryTriggerInteraction.Ignore))
            {
                if (hit.transform == player.transform)
                {
                    AttackPlayer();
                }
                else
                {
                    MoveTowardsPlayer();
                }
            }
        }
        else
        {
            MoveTowardsPlayer();
        }
    }

    private void SetTargetLocation()
    {
        if (NavMesh.SamplePosition(player.transform.position, out navMeshHit, checkRadius, areaMask))
        {
            thisNavMeshAgent.isStopped = false;
            thisNavMeshAgent.SetDestination(navMeshHit.position);
        }
    }

    private void AttackPlayer()
    {
        thisNavMeshAgent.SetDestination(transform.position);
        thisNavMeshAgent.isStopped = true;
        this.gameObject.transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        if (timeToAttack < Time.time)
        {
            timeToAttack = Time.time + timeBetweenAttacks;
            animator.SetBool(attackAnimationName, true);
        }
    }

    private void MoveTowardsPlayer()
    {
        if (Time.time > timeToRetarget || Vector3.Distance(targetPosition, transform.position) < thisNavMeshAgent.stoppingDistance + 0.1f)
        {
            timeToRetarget = Time.time + Random.Range(minTimeToRetarget, maxTimeToRetarget);
            thisNavMeshAgent.speed = Random.Range(minSpeed, maxSpeed);

            heightDifference = transform.position.y - player.transform.position.y;
            if (heightDifference > safeHeightDifference || heightDifference < -safeHeightDifference)
            {
                SetTargetLocation();
            }
            else
            {
                directionToTarget = (player.transform.position - transform.position).normalized;
                targetPosition = transform.position + (directionToTarget * randomPosDDistance);

                randomPos = Random.insideUnitCircle;
                targetPosition = targetPosition + (randomPos * (randomPosDDistance / 2));

                if (NavMesh.SamplePosition(targetPosition, out navMeshHit, checkRadius, areaMask))
                {
                    targetPosition = navMeshHit.position;
                    thisNavMeshAgent.isStopped = false;
                    thisNavMeshAgent.SetDestination(navMeshHit.position);
                }
            }
        }
    }
}
