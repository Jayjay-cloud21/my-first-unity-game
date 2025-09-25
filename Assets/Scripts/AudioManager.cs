using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private float prevMusicVolume;
    private float prevSFXVolume;

    public bool IsMusicMuted()
    {
    return musicSource.volume == 0;
    }

    public bool IsSFXMuted()
    {
        return sfxSource.volume == 0;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }

        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }


    public void PlaySFX(string name)
    {
        Sound sfx = Array.Find(sfxSounds, x => x.name == name);

        if (sfx == null)
        {
            Debug.Log("sfx not found");
        }

        else
        {
            sfxSource.clip = sfx.clip;
            sfxSource.Play();
        }
    }

    public void ToggleMusic()
    {
    if (musicSource.volume > 0)
    {
        prevMusicVolume = musicSource.volume;
        musicSource.volume = 0;
    }
    else
    {
        musicSource.volume = prevMusicVolume > 0 ? prevMusicVolume : 1f;
    }
    }
    public void ToggleSFX()
    {
        if (sfxSource.volume > 0)
        {
            prevSFXVolume = sfxSource.volume;
            sfxSource.volume = 0.0f;
        }
        else
        {
            sfxSource.volume = prevSFXVolume > 0 ? prevSFXVolume : 1f;
        }
        
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public float GetSFXVolume()
    {
        return sfxSource.volume;
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
