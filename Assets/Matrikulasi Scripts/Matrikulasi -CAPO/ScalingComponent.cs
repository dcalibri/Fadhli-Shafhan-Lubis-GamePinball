using UnityEngine;


public class ScalingComponent : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public float pulseSpeed = 1.0f;

    private bool scalingUp = true;

    void Update()
    {
        // Calculate the target scale based on the current direction
        Vector3 targetScale = scalingUp ? maxScale : minScale;

        // Interpolate between the current scale and the target scale based on pulse speed
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, pulseSpeed * Time.deltaTime);

        // Check if the scale has reached the target scale
        if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
        {
            // If the scale reached the target, switch the direction
            scalingUp = !scalingUp;
        }
    }
}
