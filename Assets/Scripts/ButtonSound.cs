using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonSound;

    public GameObject soundOnIcon;
    public GameObject soundOffIcon;

    void Start()
    {
        UpdateIcon();
    }

    // BUTTON CLICK SOUND 
    public void PlayButtonSound()
    {
        if (PlayerPrefs.GetInt("ButtonSound", 1) == 1)
        {
            buttonSound.Play();
        }
    }

    //SOUND ON
    public void SoundOn()
    {
        PlayerPrefs.SetInt("ButtonSound", 1);
        UpdateIcon();
    }

    //SOUND OFF
    public void SoundOff()
    {
        PlayerPrefs.SetInt("ButtonSound", 0);
        UpdateIcon();
    }

    void UpdateIcon()
    {
        bool isOn = PlayerPrefs.GetInt("ButtonSound", 1) == 1;

        soundOnIcon.SetActive(isOn);
        soundOffIcon.SetActive(!isOn);
    }
}