using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance { get => instance;}

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;
    [SerializeField] private Sound[] sounds;

  
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
            DontDestroyOnLoad(gameObject);
        }
        

        // Add sound clip and its settings based on sounds list
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            switch (s.audioType)
            {
                case Sound.AudioType.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;

                case Sound.AudioType.sfx:
                    s.source.outputAudioMixerGroup = sfxMixerGroup;
                    break;
            }
            if (s.playOnAwake) 
                s.source.Play();
        }
    }
    private void Start()
    {
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
    public void StopSound(string name)
    {
        //Find sound by name and play if exsist
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + s.name + "was not found");
            return;
        }
        s.source.Stop();

    }

    public void UpdateMixerVolume(float musicVolume = -1, float soundEffectsVolume = -1)
    {
        if (musicVolume != -1)
        {
            musicMixerGroup.audioMixer.SetFloat("Music Volume", musicVolume * 20);
        }    
        if (soundEffectsVolume != -1)
        {
            sfxMixerGroup.audioMixer.SetFloat("SFX Volume", soundEffectsVolume * 20);
        }  
    }
    public float GetValue(string name)
    {
        float result = -1f;
        if (name == "Music Volume")
            musicMixerGroup.audioMixer.GetFloat(name, out result);
        else if (name == "SFX Volume")
            sfxMixerGroup.audioMixer.GetFloat(name, out result);
        return result/20;
    }
}
