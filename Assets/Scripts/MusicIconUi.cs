using UnityEngine;

public class MusicIconUi : MonoBehaviour
{
    public GameObject musicOnIcon;
    public GameObject musicOffIcon;

    void Start()
    {
        UpdateIcons();
    }

    public void MusicOn()
    {
        Sound.instance.MusicOn();
        UpdateIcons();
    }

    public void MusicOff()
    {
        Sound.instance.MusicOff();
        UpdateIcons();
    }

    void UpdateIcons()
    {
        if (Sound.instance == null) return;

        bool isOn = Sound.instance.IsMusicOn();

        musicOnIcon.SetActive(isOn);
        musicOffIcon.SetActive(!isOn);
    }
}

