using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPowerUp : MonoBehaviour
{
    // This will make audio clickable, triggered.
    public AudioClip audioClip;
    public AudioSource audioSrc;

    public void playSound()
    {
        audioSrc.PlayOneShot(audioClip);
    }
}
