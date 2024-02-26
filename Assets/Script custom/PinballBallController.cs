using UnityEngine;
using UnityEngine.UI;

public class PinballBallController : MonoBehaviour
{
    private Rigidbody rb;
    public float climbForceMultiplier = 1f; // Multiplier to adjust climb force
    public bool climbing;

    void Start()
    {
        climbing = false;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PreventFlying();
    }

    void PreventFlying()
    {
        if (rb.velocity.y > 0 && !climbing)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Set the y component of velocity to 0
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ramp object
        if (collision.gameObject.CompareTag("Ramp"))
        {
            climbing = true;
            // Apply a force to climb the ramp based on the collision's normal and the pinball's velocity
            foreach (ContactPoint contact in collision.contacts)
            {
                // Calculate the climb force
                Vector3 climbForce = contact.normal * Vector3.Dot(rb.velocity, contact.normal) * climbForceMultiplier;
                rb.AddForce(climbForce, ForceMode.Impulse);
            }
        }


    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the collision is with the ramp object
        if (collision.gameObject.CompareTag("Ramp"))
        {
            climbing = false;
           
        }
    }
}
