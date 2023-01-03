using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("The AudioManager instance is NULL");
            }

            return instance;
        }
    }

    void Awake()
    {
        AudioListener.pause = false;
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop =s.loop;
            s.source.reverbZoneMix = s.reverbZone;
            s.source.spatialBlend = s.SpatialBlend;
        }
    }
    
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        s.source.PlayOneShot(s.clip);
    }

    public void Play(string name, Vector3 position)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        GameObject temp = new GameObject("temp", typeof(AudioSource));
        AudioSource source = temp.GetComponent<AudioSource>();

        temp.transform.position = position;
        source = s.source;
        source.PlayOneShot(source.clip);

        Destroy(temp, source.clip.length);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            return;
        }

        s.source.Stop();
    }
}