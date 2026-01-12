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

            // Explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Crash plane
            SimpleAirPlaneController controller = transform.parent.GetComponent<SimpleAirPlaneController>();
            if (controller != null && !controller.PlaneIsDead())
            {
                controller.Crash();
            }

            // Show Game Over
            UiManager ui = FindObjectOfType<UiManager>();
            if (ui != null) ui.ShowGameOver();
        }
    }
}
