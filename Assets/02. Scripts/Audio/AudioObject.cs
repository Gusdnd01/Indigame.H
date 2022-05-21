using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    public void Play(AudioClip clip, float pitch, float volume)
    {
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}
