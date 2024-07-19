using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Start()
    {

        
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.Log ("Sound: " + name + " not found!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.Name == name);

        if (s == null)
        {
            Debug.Log ("Sound: " + name + " not found!");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }
}
