using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioClip jumpSound, pickupSound;
    private static AudioClip jumpSound_static, pickupSound_static;

    private static AudioSource audioSource;

    void Awake()
    {
        jumpSound_static = jumpSound;
        pickupSound_static = pickupSound;

        audioSource = GetComponent<AudioSource>();

    }

    public static void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound_static);
    }

    public static void PlayPickupSound()
    {
        audioSource.PlayOneShot(pickupSound_static);
    }
}
