using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float returnTime = 1f;
    public float followSpeed = 1f;
    public float length = 5f;

    private Vector3 defaultPosition;
    public  Transform target;

    public bool HasTarget { get { return target != null; } }

    private void Start()
    {
        defaultPosition = transform.position;
 
    }

    private void Update()
    {
        if (HasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * length);

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTransform, float targetLength)
    {
        StopAllCoroutines();
        target = targetTransform;
        length = targetLength;
    }

    public void GoBackToDefault()
    {
        target = null;
        StartCoroutine(MovePosition(defaultPosition, returnTime));
    }

    private IEnumerator MovePosition(Vector3 targetPos, float time)
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;

        while (elapsedTime < time)
        {
            // Move the camera gradually
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / time);

            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.position = targetPos; // Ensure the camera reaches the target position exactly
    }
}
