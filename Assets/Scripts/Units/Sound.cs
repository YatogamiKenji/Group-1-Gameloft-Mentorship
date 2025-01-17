using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {
    public enum AudioType { sfx, music }

    public AudioType audioType;

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range (0.1f, 3f)]
    public float pitch;

    public bool loop;

    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
