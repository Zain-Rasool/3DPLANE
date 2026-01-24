using HeneGames.Airplane;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject missionCompletePanel;

    private bool isPaused = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        missionCompletePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    private void Update()
    {
        // ESC Pause / Resume
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOverPanel.activeSelf || missionCompletePanel.activeSelf)
                return;

            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }*/
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // IMPORTANT: resume time
        SceneManager.LoadScene(0); // Main Menu scene
    }


    // ================= PAUSE =================
    public void PauseGame()
    {
        Debug.Log("GAME PAUSED");

        //isPaused = true;

        AudioListener.pause = true;

        pausePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    // ================= RESUME =================
    public void ResumeGame()
    {
        

        isPaused = false;
        Time.timeScale = 1f;

        AudioListener.pause = false;

        pausePanel.SetActive(false);

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // ================= GAME OVER =================
    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }

    // ================= MISSION COMPLETE =================
    public void ShowMissionComplete()
    {
        Time.timeScale = 0f;
        missionCompletePanel.SetActive(true);

        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }

    // ================= BUTTONS =================
    public void RestartGame()
    {

        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        missionCompletePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        MissionManager.Instance.NextLevel();
    }
}