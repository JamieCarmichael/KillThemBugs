using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script will stop its game object being destoryed when changing scenes. If there is already a game object with the same tag then this object will be destroyed on awake.
/// </summary>
public class DontDestroy : MonoBehaviour
{
    private string thisTag;
    void Awake()
    {
        thisTag = this.gameObject.tag;
        GameObject[] objs = GameObject.FindGameObjectsWithTag(thisTag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
