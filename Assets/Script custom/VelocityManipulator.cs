using UnityEngine;

public class VelocityManipulator : MonoBehaviour
{
    public string targetTag = "THE TAG HERE"; // Tag of the object whose velocity will be manipulated

    public bool useX;
    public bool useY;
    public bool useZ;
    public float xVelocity = 0f; // Value to set for x-axis velocity
    public float yVelocity = 0f; // Value to set for y-axis velocity
    public float zVelocity = 0f; // Value to set for z-axis velocity


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 newVelocity = rb.velocity;

                // Conditionally set velocity values based on boolean flags
                if (useX)
                    newVelocity.x = xVelocity;
                if (useY)
                    newVelocity.y = yVelocity;
                if (useZ)
                    newVelocity.z = zVelocity;

                rb.velocity = newVelocity;
            }
            else
            {
                Debug.LogWarning("The object with tag " + targetTag + " does not have a Rigidbody component.");
            }
        }
    }
}
