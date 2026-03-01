using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private float minX = -5f;  // optional horizontal bounds
    [SerializeField] private float maxX = 5f;   // optional horizontal bounds
    [SerializeField] private float minY = 0f;   // the lowest point the bobber can go

    void Update()
    {
        // Get mouse position in screen space
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = UnityEngine.Camera.main.nearClipPlane;
        Vector3 worldPos = UnityEngine.Camera.main.ScreenToWorldPoint(mousePos);

        // Force Z=0 (2D game)
        worldPos.z = 0f;

        // Clamp X if you want horizontal limits
        float clampedX = Mathf.Clamp(worldPos.x, minX, maxX);

        // Clamp Y so it can't go below minY, but can go as high as the mouse
        float clampedY = Mathf.Max(worldPos.y, minY);

        // Apply the clamped position
        transform.position = new Vector3(clampedX, clampedY, 0f);
    }
}