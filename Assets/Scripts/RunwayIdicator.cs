using UnityEngine;

public class RunwayIdicator : MonoBehaviour
{
    public Transform plane;     // Player plane
    public Transform runway;    // Runway transform
    public RectTransform icon;  // UI image

    void Update()
    {
        if (plane == null || runway == null) return;

        Vector3 direction = runway.position - plane.position;

        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        icon.rotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
