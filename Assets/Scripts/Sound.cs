using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource musicSource;

    public GameObject musicOnIcon;
    public GameObject musicOffIcon;

    void Awake()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded; // Scene load event
    }

    void OnDestroy()
    {
        //SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int musicState = PlayerPrefs.GetInt("Music", 1);
        musicSource.mute = musicState == 0;

        if (!musicSource.isPlaying && musicState == 1)
            musicSource.Play();

        UpdateIcon();
    }

    public void MusicOn()
    {
        PlayerPrefs.SetInt("Music", 1);
        musicSource.mute = false;

        if (!musicSource.isPlaying)
            musicSource.Play();

        UpdateIcon();
    }

    public void MusicOff()
    {
        PlayerPrefs.SetInt("Music", 0);
        musicSource.mute = true;

        if (musicSource.isPlaying)
            musicSource.Stop();

        UpdateIcon();
    }

    void UpdateIcon()
    {
        bool isOn = PlayerPrefs.GetInt("Music", 1) == 1;

        musicOnIcon.SetActive(isOn);
        musicOffIcon.SetActive(!isOn);
    }
}