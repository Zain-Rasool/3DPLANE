using HeneGames.Airplane;
using UnityEngine;

public class RunwayIdicator : MonoBehaviour

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
