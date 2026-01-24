using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    public AudioSource musicSource;

    public GameObject musicOnIcon;
    public GameObject musicOffIcon;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        ApplyMusicState();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Sirf MainMenu scene me icons assign karo
        if (scene.name == "MainMenu")
        {
            musicOnIcon = GameObject.Find("MusicOnIcon"); // GameObject ka exact name
            musicOffIcon = GameObject.Find("MusicOffIcon");
        }
        else
        {
            musicOnIcon = null;
            musicOffIcon = null;
        }

        ApplyMusicState(); // music aur icon update
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

    void ApplyMusicState()
    {
        int musicState = PlayerPrefs.GetInt("Music", 1);

        if (musicState == 1)
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

        UpdateIcon();
    }

    void UpdateIcon()
    {
        // sirf tab update karo agar icons exist karte hain
        if (musicOnIcon == null || musicOffIcon == null)
            return;

        bool isOn = PlayerPrefs.GetInt("Music", 1) == 1;

        musicOnIcon.SetActive(isOn);
        musicOffIcon.SetActive(!isOn);
    }
}