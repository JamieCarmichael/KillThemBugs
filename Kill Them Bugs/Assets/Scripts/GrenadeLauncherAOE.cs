using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script is to be placed on a greade lanucher bullet. It does AOE damage.
/// </summary>
public class GrenadeLauncherAOE : MonoBehaviour
{
    [Tooltip("This is the speed the bullet travels at.")]
    [SerializeField] float speed = 20.0f;
    [Tooltip("This is the time before a bullet destroys itself if it does not hit anything.")]
    [SerializeField] float timeUntilDestroySelf = 5.0f;
    [Tooltip("This is the damage that is applied on contact with object.")]
    [SerializeField] int damage = 1;
    [Tooltip("This is the radius that is checked for assets to damage.")]
    [SerializeField] float radius = 3.0f;
    [Tooltip("This is a layer mask that is checked for assets to be desroyed by the explosion.")]
    [SerializeField] LayerMask layersToHit;
    [Tooltip("This is the explosion that is triggered when this object is destroyed.")]
    [SerializeField] GameObject explosion;

    private Rigidbody rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        Invoke("DestroyThis", timeUntilDestroySelf);
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageObjects();
        DestroyThis();
    }

    private void DestroyThis()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    public void DamageObjects()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, radius, layersToHit);
        for (int i = 0; i < collidersInRange.Length; i++)
        {
            if (collidersInRange[i].TryGetComponent<TakeDamage>(out TakeDamage takeDamage))
            {
                takeDamage.ReceiveDamage(damage,this.transform.position);
            }
        }
    }
}
