using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script runs an event when the trigger this is attacked to is hit.
/// </summary>
public class OnTriggerEvent : MonoBehaviour
{
    [Tooltip("This is the event that is triggered.")]
    [SerializeField] UnityEvent eventToTrigger;
    private void OnTriggerEnter(Collider other)
    {
        eventToTrigger?.Invoke();
    }
}
