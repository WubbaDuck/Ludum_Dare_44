using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // public AudioClip[] musicArray;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // void OnLevelWasLoaded(int level)
    // {
    //     AudioClip thisLevelMusic = levelMusicChangeArray[level];

    //     if (thisLevelMusic)
    //     { // If there is music for the current level
    //         audioSource.Stop();
    //         audioSource.clip = thisLevelMusic;
    //         audioSource.loop = true;
    //         audioSource.Play();
    //     }
    // }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
