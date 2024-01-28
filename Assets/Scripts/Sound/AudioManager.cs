using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("ThemeMusic");
        
    }
    private void Update()
    {
        Debug.Log(musicSource.volume);
    }
    public void PlayMusic(string name)
    {
        Sounds s = Array.Find(musicSounds, x => x.Name == name);
        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySfx(string name)
    {
        Sounds s = Array.Find(sfxSounds, x => x.Name == name);
        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSfx()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
