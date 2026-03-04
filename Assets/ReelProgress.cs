using UnityEngine;

public class ReelProgress : MonoBehaviour
{
    [Header("Tow path (world space)")]
    public float topY = 4f;        // far away
    public float bottomY = -3f;    // close to camera
    public float pullDuration = 3f; // seconds to reel in

    [Header("Easing")]
    public AnimationCurve yEase = AnimationCurve.EaseInOut(0, 0, 1, 1);

    [Range(0f, 1f)]
    public float t; // 0..1 progress (read by other scripts)

    float elapsed;

    void Start()
    {
        // Initialize at "far"
        Vector3 p = transform.position;
        transform.position = new Vector3(p.x, topY, p.z);
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        t = Mathf.Clamp01(elapsed / Mathf.Max(0.0001f, pullDuration));

        float eased = yEase.Evaluate(t);
        float y = Mathf.Lerp(topY, bottomY, eased);

        Vector3 p = transform.position;
        transform.position = new Vector3(p.x, y, p.z);
    }
}