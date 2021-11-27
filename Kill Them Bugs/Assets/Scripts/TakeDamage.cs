using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script will recieve damage and then do something when the health drops to 0.
/// </summary>
public class TakeDamage : MonoBehaviour
{
    [Tooltip("This is the initial health of this asset.")]
    [SerializeField] int health = 3;
    [Tooltip("This is the Particle that will be spawned when this asset runs out of healht and is destroyed.")]
    [SerializeField] GameObject deathParticles;
    [Tooltip("This is the location that the particle will spawn at when this asset is destroyed.")]
    [SerializeField] Transform particleSpawnLocation;
    [Tooltip("This is a multiplier that will increase the the force applied to this asset when hit but not killed if it has a rigidbody.")]
    [SerializeField] float impactMultiplier = 3.0f;
    [Tooltip("This is the time after being shot that the rigidbody will remain not kinematic (Active).")]
    [SerializeField] float timeRigidbodyActive = 2.0f;
    [Tooltip("This is the script that contains the pick up that is created when this enemy dies.")]
    [SerializeField] CreateObject createOnDeath;
    [Tooltip("This event is called on this asset running out off health.")]
    [SerializeField] UnityEvent onDeathEvent;

    private Rigidbody thisRigidbody;
    private SpawnEnemy thisSpawnEnemy;

    public SpawnEnemy ThisSpawnEnemy
    {
        set { thisSpawnEnemy = value; }
    }

    public void ReceiveDamage(int damage, Vector3 positionAtImpact)
    {
        health -= damage;
        if (health <= 0)
        {
            KillThis();
        }
        else if (TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
        {
            thisRigidbody = rigidbody;
            thisRigidbody.isKinematic = false;
            thisRigidbody.AddForce((this.transform.position - positionAtImpact) * impactMultiplier, ForceMode.Impulse);
            Invoke("MakeKinematic", timeRigidbodyActive);
        }
    }
    private void MakeKinematic()
    {
        thisRigidbody.isKinematic = true;
    }

    private void KillThis()
    {
        if (deathParticles != null)
        {
            Instantiate(deathParticles, particleSpawnLocation.position, particleSpawnLocation.rotation);
        }
        if (createOnDeath != null)
        {
            createOnDeath.MakeObject(this.gameObject.transform.position);
        }
        if (thisSpawnEnemy != null)
        {
            thisSpawnEnemy.ReduceEnemyCount();
        }
        onDeathEvent?.Invoke();

        Destroy(this.gameObject);
    }
}
