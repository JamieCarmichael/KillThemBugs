using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script runs an event after a period of time.
/// </summary>
public class OnTimeEvent : MonoBehaviour
{
    [Tooltip("This is the event that is triggered.")]
    [SerializeField] UnityEvent eventToTrigger;
    [Tooltip("This is how long between this object being enabled and  the event happening.")]
    [SerializeField] float timeUntilEventTriggered = 1.0f;
    [Tooltip("If this is true the timer will start when this script is enabled if false it needs to be triggered.")]
    [SerializeField] bool runOnEnable = false;

    private void OnEnable()
    {
        if (runOnEnable)
        {
            StartTimer();
        }
    }
    public void StartTimer()
    {
        Invoke("RunEvent", timeUntilEventTriggered);
    }

    private void RunEvent()
    {
        eventToTrigger?.Invoke();
    }
}
