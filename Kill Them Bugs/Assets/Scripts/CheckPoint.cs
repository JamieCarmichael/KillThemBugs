using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] CheckPointManager checkPointManager;
    private void OnTriggerEnter(Collider other)
    {
        checkPointManager.SetCheckPoint(this);
    }
}
