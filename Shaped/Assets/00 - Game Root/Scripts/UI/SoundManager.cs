﻿
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioMixer _audio;
    static float _musicVolume, _soundMusic;
    public static float MusicVolume { get { return _musicVolume; } }
    public static float SoundVolume { get { return _soundMusic; } }

    void Awake()
    {
        instance = this;

        _audio = Resources.Load<AudioMixer>("Audio");

        _audio.GetFloat("MusicVolume", out _musicVolume);
        _audio.GetFloat("MusicVolume", out _soundMusic);
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
