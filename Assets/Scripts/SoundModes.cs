using UnityEngine;

public class SoundModes : MonoBehaviour
{
    public AudioSource music;

    void Start()
    {
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
    }
}
