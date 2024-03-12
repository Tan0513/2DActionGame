using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    public AudioClip jumpSound, hurtSound, cherrySound;

    private void Awake() 
    {
        instance = this;
    }
    
    public void JumpAudio()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    public void HurtAudio()
    {
        audioSource.clip = hurtSound;
        audioSource.Play();
    }

    public void CherryAudio()
    {
        audioSource.clip = cherrySound;
        audioSource.Play();
    }
}
