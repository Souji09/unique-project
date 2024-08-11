using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{
    public static Audio Instance;
    public Sound[] musicSound, sfxSound;
    public AudioSource musicSource, sfxSource;
    public Button muteMusic;
    public Button muteSFX;
    private void Awake()
    {
        if(Instance== null)
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
        muteMusic.onClick.AddListener(SettingMusic);
        muteSFX.onClick.AddListener(SettingSFX);
        musicSource.volume = 1;
        sfxSource.volume = 1;
        PlayMusic("MainMenuTheme");

    }
    public void PlayMusic(string name)

    {

        Sound s = Array.Find(musicSound, x => x.name == name);
        if (s == null)
        {
            Debug.Log("khong co am thanh ten nhu the dau em");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSound, x => x.name == name);
        if (s == null)
        {
            Debug.Log("khong co am thanh ten nhu the dau em");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }

    }
    public void SettingMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void SettingSFX()
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
