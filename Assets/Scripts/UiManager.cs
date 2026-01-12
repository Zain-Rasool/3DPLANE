using HeneGames.Airplane;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;

    [Header("Cameras")]
    public Camera mainMenuCamera;
    public Camera planeCamera;

    private GameObject plane;

    private void Start()
    {
        // Initial state
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        if (mainMenuCamera != null) mainMenuCamera.gameObject.SetActive(true);
        if (planeCamera != null) planeCamera.gameObject.SetActive(false);

        plane = GameObject.FindWithTag("Player");
        if (plane != null) plane.SetActive(false); // plane initially inactive
    }

    // Start button
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        // Switch cameras
        if (mainMenuCamera != null) mainMenuCamera.gameObject.SetActive(false);
        if (planeCamera != null) planeCamera.gameObject.SetActive(true);

        // Activate plane
        if (plane != null)
        {
            plane.SetActive(true);
            plane.transform.position = Vector3.zero;
            plane.transform.rotation = Quaternion.identity;

            SimpleAirPlaneController controller = plane.GetComponent<SimpleAirPlaneController>();
            if (controller != null)
            {
                controller.ResetPlane(); // reset plane state
            }
        }
    }

    // Restart button
    public void RestartGame()
    {
        Debug.Log("Restart clicked!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Home button
    public void BackToMainMenu()
    {
        Debug.Log("Home clicked!");

        // Reset panels
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        // Camera switch
        if (mainMenuCamera != null) mainMenuCamera.gameObject.SetActive(true);
        if (planeCamera != null) planeCamera.gameObject.SetActive(false);

        // Hide plane
        if (plane != null)
            plane.SetActive(false);
    }

    // Show Game Over panel
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
