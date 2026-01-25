using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    public AudioSource musicSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        ApplyMusicState();
    }

    public void MusicOn()
    {
        PlayerPrefs.SetInt("Music", 1);
        ApplyMusicState();
    }

    public void MusicOff()
    {
        PlayerPrefs.SetInt("Music", 0);
        ApplyMusicState();
    }

    public bool IsMusicOn()
    {
        return PlayerPrefs.GetInt("Music", 1) == 1;
    }

    void ApplyMusicState()
    {
        if (IsMusicOn())
        {
            musicSource.mute = false;
            if (!musicSource.isPlaying)
                musicSource.Play();
        }
        else
        {
            musicSource.mute = true;
            musicSource.Stop();
        }
    }
}