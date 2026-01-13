using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform plane;

    void LateUpdate()
    {
        if (plane == null) return;

        transform.position = new Vector3(
            plane.position.x,
            transform.position.y,
            plane.position.z
        );
    }
}