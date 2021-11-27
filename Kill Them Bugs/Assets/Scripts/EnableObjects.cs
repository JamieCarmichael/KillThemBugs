using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjects : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToEnable;

    public void TurnOnObjects()
    {
        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(true);
        }
    }
}
