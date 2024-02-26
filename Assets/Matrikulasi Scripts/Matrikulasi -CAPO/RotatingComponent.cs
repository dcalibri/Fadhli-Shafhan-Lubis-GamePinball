using UnityEngine;

public class RotatingComponent : MonoBehaviour
{
    public Vector3 rotationSpeed;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
