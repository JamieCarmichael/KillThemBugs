using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script handles basic bullet movement and damage.
/// </summary>
public class Bullet : MonoBehaviour
{
    [Tooltip("This is the speed the bullet travels at.")]
    [SerializeField] float speed = 10.0f;
    [Tooltip("This is the time before a bullet destroys itself if it does not hit anything.")]
    [SerializeField] float timeUntilDestroySelf = 5.0f;
    [Tooltip("This is the damage that is applied on contact with object.")]
    [SerializeField] int damage = 1;

    private Rigidbody rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        Invoke("DestroyThis", timeUntilDestroySelf);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<TakeDamage>(out TakeDamage takeDamage))
        {
            takeDamage.ReceiveDamage(damage, transform.position);
        }
        DestroyThis();
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
