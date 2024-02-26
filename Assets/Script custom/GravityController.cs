using UnityEngine;

public class GravityController : MonoBehaviour
{
    public Vector3 gravityDirection = new Vector3(0, -9.81f, 0); // Default gravity direction (downward)

    void Start()
    {
        Physics.gravity = gravityDirection; // Set the gravity direction
    }
}
