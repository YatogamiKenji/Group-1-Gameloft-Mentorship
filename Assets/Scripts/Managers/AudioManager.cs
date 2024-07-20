using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance { get => instance;}

    public Sound[] sounds;

  
    private void Awake()
    {
        // Singleton init
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        // Add sound clip and its settings based on sounds list
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        PlaySound("Test Theme");
    }
    public void PlaySound(string name)
    {
        //Find sound by name and play if exsist
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + s.name + "was not found");
            return;
        }
        s.source.Play();
    }

}
