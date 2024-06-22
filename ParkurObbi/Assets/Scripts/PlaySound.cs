using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField, Header("AudioSource")]private AudioSource au;
    [SerializeField, Header("Sound")] private AudioClip ClipSound;

    // Проигроваем звук
    public void _PlaySound()
    {
        au.PlayOneShot(ClipSound);
    }
}
