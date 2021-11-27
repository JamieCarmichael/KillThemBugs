using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script contains a method that creates an object.
/// </summary>
public class CreateObject : MonoBehaviour
{
    [Tooltip("This is the objec created.")]
    [SerializeField] GameObject createdObject;

    public void MakeObject(Vector3 spawnLocation)
    {
        Instantiate(createdObject, spawnLocation, this.gameObject.transform.rotation);
    }
}
