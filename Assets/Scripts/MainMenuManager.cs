using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject modePanel;
    public GameObject settingsPanel;
    public GameObject exitPanel;
    public GameObject freeModeEnvPanel;
    public GameObject missionModePanel;
    public GameObject instructionPanel;

    [Header("Free Mode Scenes")]
    public int desertSceneIndex = 1;
    public int iceSceneIndex = 2;

    private void Start()
    {
        mainPanel.SetActive(true);
        modePanel.SetActive(false);
        settingsPanel.SetActive(false);
        exitPanel.SetActive(false);
        freeModeEnvPanel.SetActive(false);
        instructionPanel.SetActive(false);
        missionModePanel.SetActive(false);
    }

    // PLAY
    public void PlayButton()
    {
        HideAllPanels();
        modePanel.SetActive(true);
    }

    // BACK
    public void BackButton()
    {
        HideAllPanels();
        mainPanel.SetActive(true);
    }

    // SETTINGS
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

    // EXIT
    public void OpenExitPanel()
    {
        HideAllPanels();
        exitPanel.SetActive(true);
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        HideAllPanels();
        mainPanel.SetActive(true);
    }

    // FREE MODE
    public void OpenFreeModeEnvironments()
    {
        HideAllPanels();
        freeModeEnvPanel.SetActive(true);
    }

    public void LoadDesertMode()
    {
        StartCoroutine(ShowInstructionAndLoad(desertSceneIndex));
    }

    public void LoadForestMode()
    {
        StartCoroutine(ShowInstructionAndLoad(iceSceneIndex));
    }

    public void OpenMissionModePanel()
    {
        HideAllPanels();
        missionModePanel.SetActive(true);
    }
    // MISSION MODE 
    public void PlayMissionMode()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(3);
    }

    // INSTRUCTION
    IEnumerator ShowInstructionAndLoad(int sceneIndex)
    {
        HideAllPanels();
        instructionPanel.SetActive(true);

        yield return new WaitForSeconds(5f);

        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneIndex);
    }

    
    void HideAllPanels()
    {
        mainPanel.SetActive(false);
        modePanel.SetActive(false);
        settingsPanel.SetActive(false);
        exitPanel.SetActive(false);
        freeModeEnvPanel.SetActive(false);
        instructionPanel.SetActive(false);
        missionModePanel.SetActive(false);
    }
}
