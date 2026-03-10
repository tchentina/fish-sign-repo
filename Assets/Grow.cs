using UnityEngine;

public class GrowToSize : MonoBehaviour
{
    public float growSpeed = 1.5f;

    public float startScale = 0.2f;
    public float targetScale = 0.65f;

    bool growing = false;

    void OnEnable()
    {
        // When the spawner activates the Done object
        transform.localScale = new Vector3(startScale, startScale, transform.localScale.z);
        growing = true;
    }

    void Update()
    {
        if (!growing) return;

        Vector3 current = transform.localScale;
        Vector3 target = new Vector3(targetScale, targetScale, current.z);

        transform.localScale = Vector3.MoveTowards(
            current,
            target,
            growSpeed * Time.deltaTime
        );

        if (Mathf.Abs(transform.localScale.x - targetScale) < 0.001f)
        {
            growing = false;
        }
    }
}