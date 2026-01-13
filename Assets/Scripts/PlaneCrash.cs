using HeneGames.Airplane;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneCrash : MonoBehaviour
{
    public GameObject explosionPrefab;
    private bool crashed = false;

    void OnTriggerEnter(Collider other)
    {
        if (crashed) return;

        if (other.CompareTag("Ground"))
        {
            crashed = true;

            // Play explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Tell controller to crash
            SimpleAirPlaneController planeController = transform.parent.GetComponent<SimpleAirPlaneController>();
            if (planeController != null && !planeController.PlaneIsDead())
            {
                planeController.Crash(); // plane freeze and crash
            }

            // Reload scene after 2 seconds
            Invoke(nameof(ReloadScene), 2f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
