using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField, Header("AudioSource")]private AudioSource au;
    // ����������� ����
    public void _PlaySound(AudioClip ClipSound)
    {
        au.PlayOneShot(ClipSound);
    }
}
