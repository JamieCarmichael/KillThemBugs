using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] int keyNumber;

    private KeyChain keyChain;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KeyChain>(out keyChain))
        {
            keyChain.PickUpKey(keyNumber);
            this.gameObject.SetActive(false);
        }
    }
}
