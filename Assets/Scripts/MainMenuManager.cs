using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject modePanel;
    public GameObject settingsPanel;
    public GameObject exitPanel;

    private void Start()
    {
        mainPanel.SetActive(true);
        modePanel.SetActive(false);
        settingsPanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    // ---------- PLAY ----------
    public void PlayButton()
    {
        HideAllPanels();
        modePanel.SetActive(true);
    }

    // ---------- BACK ----------
    public void BackButton()
    {
        HideAllPanels();
        mainPanel.SetActive(true);
    }

    // ---------- SETTINGS ----------
    public void OpenSettings()
    {
        HideAllPanels();
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        HideAllPanels();
        mainPanel.SetActive(true);
    }

    // ---------- EXIT ----------
    public void OpenExitPanel()
    {
        exitPanel.SetActive(true);
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        exitPanel.SetActive(false);
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

    // ---------- UTIL ----------
    void HideAllPanels()
    {
        mainPanel.SetActive(false);
        modePanel.SetActive(false);
        settingsPanel.SetActive(false);
        exitPanel.SetActive(false);
    }
}
