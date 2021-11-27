using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script changes the material on an array of objects.
/// </summary>
public class SwitchMaterials : MonoBehaviour
{
    [SerializeField] Material newMaterial;

    [SerializeField] MeshRenderer[] meshRenderers;

    public void ChangeMaterial()
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material = newMaterial;
        }
    }
}
