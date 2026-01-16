using HeneGames.Airplane;
using UnityEngine;

public class RunwayIdicator : MonoBehaviour
//{
//    public Transform airport;       // Real airport object
//    public RectTransform icon;      // Airport UI Image
//    public Camera miniMapCamera;    // Mini-map camera (plane follow)

//    void Update()
//    {
//        // Convert world position to viewport relative to mini-map camera
//        Vector3 viewportPos = miniMapCamera.WorldToViewportPoint(airport.position);

//        // Clamp viewport between 0 and 1 (so icon stays in panel)
//        viewportPos.x = Mathf.Clamp01(viewportPos.x);
//        viewportPos.y = Mathf.Clamp01(viewportPos.y);

//        // Set icon position relative to panel
//        icon.anchorMin = icon.anchorMax = new Vector2(viewportPos.x, viewportPos.y);
//        icon.anchoredPosition = Vector2.zero;
//    }
//}

{
    public RectTransform icon;
    public Camera miniMapCamera;

    private Transform currentRunway;

    public void SetRunway(Transform runway)
    {
        currentRunway = runway;
        icon.gameObject.SetActive(runway != null);
        
    }

    void Update()
    {
        if (currentRunway == null) return;

        Vector3 viewportPos =
            miniMapCamera.WorldToViewportPoint(currentRunway.position);

        viewportPos.x = Mathf.Clamp01(viewportPos.x);
        viewportPos.y = Mathf.Clamp01(viewportPos.y);

        icon.anchorMin = icon.anchorMax =
            new Vector2(viewportPos.x, viewportPos.y);

        icon.anchoredPosition = Vector2.zero;
    }
}
