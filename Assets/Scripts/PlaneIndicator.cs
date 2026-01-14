using UnityEngine;

public class PlaneIndicator : MonoBehaviour
{
    public Transform plane;        // Real plane in scene
    public RectTransform icon;     // Plane icon UI Image
    public Camera miniMapCamera;   // Mini-map camera (even if far)

    void Update()
    {
        // Convert plane world position to mini-map camera viewport
        Vector3 viewportPos = miniMapCamera.WorldToViewportPoint(plane.position);

        // Clamp viewport between 0 and 1
        viewportPos.x = Mathf.Clamp01(viewportPos.x);
        viewportPos.y = Mathf.Clamp01(viewportPos.y);

        // Set icon position relative to mini-map panel
        icon.anchorMin = icon.anchorMax = new Vector2(viewportPos.x, viewportPos.y);
        icon.anchoredPosition = Vector2.zero;
    }
}
