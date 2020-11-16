
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioMixer _audio;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _audio = Resources.Load<AudioMixer>("Audio");
    }

    void SetSoundVolume(float volume)
    {
        _audio.SetFloat("SoundVolume", volume);
    }
    
    void SetMusicVolume(float volume)
    {
        _audio.SetFloat("MusicVolume", volume);
    }

    /*              PUBLIC STATICS              */

    public static void Static_SetSoundVolume(float volume)
    {
        instance.SetSoundVolume(volume);
    }
    public static void Static_SetMusicVolume(float volume)
    {
        instance.SetMusicVolume(volume);
    }
}
