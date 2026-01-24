using UnityEngine;

public class ButtonSoundClick : MonoBehaviour
{
    public AudioSource clickSound;

    public void PlayClick()
    {
        if (PlayerPrefs.GetInt("ButtonSound", 1) == 1)
        {
            clickSound.Play();
        }
    }
}
