using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Transform objectToControl; // The object you want to control
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component attached to the same GameObject
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found. Please attach it to the same GameObject.");
        }
    }

    void Update()
    {
        if (objectToControl != null && navMeshAgent != null)
        {
            // Set the destination of the NavMeshAgent to the current position of the object being controlled
            navMeshAgent.SetDestination(objectToControl.position);

            // Ensure the object stays within the bounds of the NavMesh area
            Vector3 clampedPosition = ClampPositionToNavMesh(objectToControl.position);
            objectToControl.position = clampedPosition;
        }
    }

    // Clamp the position to the NavMesh bounds
    private Vector3 ClampPositionToNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 10.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            Debug.LogWarning("Position is not within the NavMesh bounds. Returning original position.");
            return position;
        }
    }
}
