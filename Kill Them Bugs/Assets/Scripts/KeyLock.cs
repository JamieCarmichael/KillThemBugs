using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyLock : MonoBehaviour
{
    [SerializeField] int keyNumber;

    [SerializeField] UnityEvent OnOpenKey;

    private KeyChain keyChain;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KeyChain>(out keyChain))
        {
            if (keyChain.CheckKey(keyNumber))
            {
                OnOpenKey?.Invoke();
                this.enabled = false;
            }
        }
    }
}
