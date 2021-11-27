using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioSource : MonoBehaviour
{
    AudioSource audioSource;
    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

    }
    public void PlayAudio()
    {
        audioSource.Play();
    }
}
