using UnityEngine;

public class ScaleWithProgress : MonoBehaviour
{
    public ReelProgress driver;

    public Vector3 minScale = Vector3.zero;
    public Vector3 maxScale = new Vector3(3f, 3f, 3f);

    public AnimationCurve scaleEase = AnimationCurve.EaseInOut(0, 0, 1, 1);

    void Reset()
    {
        driver = GetComponent<ReelProgress>();
    }

    void Update()
    {
        if (!driver) return;

        float eased = scaleEase.Evaluate(driver.t);
        transform.localScale = Vector3.Lerp(minScale, maxScale, eased);
    }
}