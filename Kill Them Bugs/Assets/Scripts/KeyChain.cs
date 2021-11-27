using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChain : MonoBehaviour
{
    [SerializeField] bool[] keys;


    public void PickUpKey(int keyPickedUp)
    {
        keys[keyPickedUp] = true;
    }
    public bool CheckKey (int keyToCheck)
    {
        return keys[keyToCheck];
    }
}
