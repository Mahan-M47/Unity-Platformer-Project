using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioClip jumpSound, pickupSound, winSound;
    private static AudioClip jumpSound_static, pickupSound_static, winSound_static;

    private static AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        jumpSound_static = jumpSound;
        pickupSound_static = pickupSound;
        winSound_static = winSound;
    }

    public static void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound_static);
    }

    public static void PlayPickupSound()
    {
        audioSource.PlayOneShot(pickupSound_static);
    }

    public static void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound_static);
    }
}
