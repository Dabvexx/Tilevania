using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables
    // Variables.
    public static AudioManager current;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip[] audioClips;

    private AudioClip lastClip;
    #endregion

    #region Unity Methods

    void Awake()
    {
        current = this;
    }

    #endregion

    #region Private Methods
    // Private Methods.
    private AudioClip RandomClip()
    {
        return audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
    }

    private AudioClip RandomClipNonRepeat()
    {
        int attempts = 3;
        AudioClip newClip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];

        // Try to get a new sound multiple times and just pray because im lazy
        while (newClip == lastClip && attempts > 0)
        {
            newClip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
            attempts--;
        }

        lastClip = newClip;
        return newClip;
    }

    #endregion

    #region Public Methods
    // Public Methods.
    //public void PlaySound(AudioClip clip)
    //{
    //    audioSource.PlayOneShot(clip);
    //}

    public void PlaySoundRandom()
    {
        audioSource.PlayOneShot(RandomClip());
    }

    public event Action onPlaySound;
    public void PlaySound()
    {
        if(onPlaySound != null)
        {
            onPlaySound();
        }
    }
    #endregion
}