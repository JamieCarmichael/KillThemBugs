using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Jamie Carmichael
/// Details: This script switches the music to a new clip on enable and then switches it back in disable.
/// </summary>
public class SwitchMusic : MonoBehaviour
{
    [Tooltip("This is the tage of the music object.")]
    [SerializeField] string musicTag = "Music";
    [Tooltip("This is the new audio clip.")]
    [SerializeField] AudioClip newMusicClip;

    private AudioClip oldMusicClip;

    private AudioSource musicAudioSource;

    private void OnEnable()
    {
        musicAudioSource = GameObject.FindGameObjectWithTag(musicTag).GetComponent<AudioSource>();

        oldMusicClip = musicAudioSource.clip;
        musicAudioSource.clip = newMusicClip;
        musicAudioSource.Play();

    }
    private void OnDisable()
    {
        musicAudioSource.clip = oldMusicClip;
        musicAudioSource.Play();
    }

}
