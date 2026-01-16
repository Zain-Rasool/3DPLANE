using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // FREE MODE BUTTON
    public void PlayFreeMode()
    {
        Time.timeScale = 1f; // safety
        AudioListener.pause = false;

        SceneManager.LoadScene(1); // Free Mode
    }

    // MISSION MODE BUTTON
    public void PlayMissionMode()
    {
        Time.timeScale = 1f; // safety
        AudioListener.pause = false;

        SceneManager.LoadScene(2); // Mission Mode
    }

    // QUIT BUTTON (optional)
    public void QuitGame()
    {
        Application.Quit();
    }
}
