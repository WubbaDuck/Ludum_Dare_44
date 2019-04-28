using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioClip spawnSound;
    public AudioClip deathSound;
    public AudioClip transfusionSound;

    private float lastWalkSoundTime = 0;
    private float lastTransfusionSoundTime = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound_Walk()
    {
        float walkSoundDelay = 0.334f;

        if (!audioSource.isPlaying && (Time.time - lastWalkSoundTime) > walkSoundDelay)
        {
            audioSource.Stop();
            audioSource.clip = walkSound;
            audioSource.Play();
            lastWalkSoundTime = Time.time;
        }
    }

    public void PlaySound_Jump()
    {
        audioSource.Stop();
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    public void PlaySound_Spawn()
    {
        audioSource.Stop();
        audioSource.clip = spawnSound;
        audioSource.Play();
    }

    public void PlaySound_Death()
    {
        audioSource.Stop();
        audioSource.clip = deathSound;
        audioSource.Play();
    }

    public void PlaySound_Transfusion()
    {
        float transfusionSoundDelay = 0.334f;

        if (!audioSource.isPlaying && (Time.time - lastTransfusionSoundTime) > transfusionSoundDelay)
        {
            audioSource.Stop();
            audioSource.clip = transfusionSound;
            audioSource.Play();
            lastWalkSoundTime = Time.time;
        }
    }

    public void StopTransfusionSound()
    {
        if (audioSource.clip.name == transfusionSound.name)
        {
            audioSource.Stop();
        }
    }

}
