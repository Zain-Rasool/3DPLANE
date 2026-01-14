using UnityEngine;

public class RunwayIdicator : MonoBehaviour
//{
//    public Transform airport;       // Airport world position
//    public RectTransform icon;      // Mini-map icon
//    public Camera miniMapCamera;    // Mini-map camera

//    void Update()
//    {
//        Vector3 viewportPos = miniMapCamera.WorldToViewportPoint(airport.position);
//        icon.anchorMin = icon.anchorMax = new Vector2(viewportPos.x, viewportPos.y);
//        icon.anchoredPosition = Vector2.zero;
//    }
//}
{
    public Transform airport;       // Real airport object
    public RectTransform icon;      // Airport UI Image
    public Camera miniMapCamera;    // Mini-map camera (plane follow)

    void Update()
    {
        // Convert world position to viewport relative to mini-map camera
        Vector3 viewportPos = miniMapCamera.WorldToViewportPoint(airport.position);

        // Clamp viewport between 0 and 1 (so icon stays in panel)
        viewportPos.x = Mathf.Clamp01(viewportPos.x);
        viewportPos.y = Mathf.Clamp01(viewportPos.y);

        // Set icon position relative to panel
        icon.anchorMin = icon.anchorMax = new Vector2(viewportPos.x, viewportPos.y);
        icon.anchoredPosition = Vector2.zero;
    }
}
