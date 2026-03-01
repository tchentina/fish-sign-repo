using UnityEngine;

public class BoatFollowMouse : MonoBehaviour
{
    [SerializeField] private float minX = -2.3f;
    [SerializeField] private float maxX = 2.3f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = UnityEngine.Camera.main.nearClipPlane;
        Vector3 worldPos = UnityEngine.Camera.main.ScreenToWorldPoint(mousePos);

        worldPos.z = 0f;

        float clampedX = Mathf.Clamp(worldPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(worldPos.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, 0f);
    }
}