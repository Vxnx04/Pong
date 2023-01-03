using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
   // public AudioMixerGroup outputAudioMixerGroup;
    public float volume;
    [Range(-1f, 1f)]
    public float pitch;
    public bool loop;
    [Header("3D Settings")]
    [Range(0.0f, 1.0f)]
    public float SpatialBlend;
    [Range(0.0f, 1.0f)]
    public float reverbZone;
    
    [HideInInspector]
    public AudioSource source;
}
