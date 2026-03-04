using UnityEngine;

public class SwayWithProgress : MonoBehaviour
{
    public ReelProgress driver;

    [Header("Sway")]
    public float farAmplitude = 0.8f;   // sway when far
    public float nearAmplitude = 0.25f; // sway when close
    public float farFrequency = 2.5f;
    public float nearFrequency = 1.2f;

    float previousOffset;

    void Reset()
    {
        driver = GetComponent<ReelProgress>();
    }

    void Update()
    {
        if (!driver) return;

        // Often looks good if the tube settles as it gets closer:
        float amp = Mathf.Lerp(farAmplitude, nearAmplitude, driver.t);
        float freq = Mathf.Lerp(farFrequency, nearFrequency, driver.t);

        float offset = Mathf.Sin(Time.time * freq) * amp;

        // Apply only the delta so we don't stomp on other X movement
        float delta = offset - previousOffset;
        transform.position += new Vector3(delta, 0f, 0f);

        previousOffset = offset;
    }
}