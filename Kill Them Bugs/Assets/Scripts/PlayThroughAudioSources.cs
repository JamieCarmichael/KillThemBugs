using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayThroughAudioSources : MonoBehaviour
{
    [SerializeField] AudioSource thisAudioSource;

    [SerializeField] AudioClip[] audioClips;

    private int audioClipCount;
    void Update()
    {
        if (!thisAudioSource.isPlaying)
        {
            audioClipCount++;
            audioClipCount = audioClipCount % audioClips.Length;
            thisAudioSource.clip = audioClips[audioClipCount];
            thisAudioSource.Play();
        }
    }
}
