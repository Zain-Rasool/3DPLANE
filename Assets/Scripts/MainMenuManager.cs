using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject modePanel;

    private void Start()
    {
        mainPanel.SetActive(true);
        modePanel.SetActive(false);
    }

    // ---------- PLAY ----------
    public void PlayButton()
    {
        mainPanel.SetActive(false);
        modePanel.SetActive(true);
    }

    // ---------- BACK ----------
    public void BackButton()
    {
        modePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // ---------- FREE MODE ----------
    public void PlayFreeMode()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(1);
    }

    // ---------- MISSION MODE ----------
    public void PlayMissionMode()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(2);
    }

    // ---------- QUIT ----------
    public void QuitGame()
    {
        Application.Quit();
    }
}
