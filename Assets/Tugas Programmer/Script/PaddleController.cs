using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode inputPress; // Assuming you want to set this in the Unity Editor
  

    public string obstacleTag = "Wall";
    // Check if the collider should pass through the static obstacles
    private bool canPassThrough = true;

    private float targetPressed;
    private float targetRelease;

    private HingeJoint hinge; 

    // Use Start() instead of LJpdate() and fix the typo in Update()
    private void Start()
    {
        // Call ReadInput() in Start() to initialize
       hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    // Update method should be named Update(), not LJpdate()
    private void Update()
    {
        // Call ReadInput() in Update() to check input every frame
        ReadInput();
    }

    // Correct the method name to ReadInput() and add missing return type
    private void ReadInput()
    {
        
        JointSpring jointSpring = hinge.spring; // Initialize jointSpring variable

        // Use Input.GetKeyDown(input) instead of Input.Getxey(input)
        if (Input.GetKey(inputPress))
        {
            jointSpring.targetPosition = targetPressed; 
            UnityEngine.Debug.Log(inputPress);
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }

        // Apply the updated jointSpring to the component
        hinge.spring = jointSpring;
    }

    // OnCollisionEnter is called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag specified for static obstacles
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            // Check if the collider should pass through the static obstacles
            if (canPassThrough)
            {
                // Ignore collision with the static obstacle
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            }
        }
    }


    // OnTriggerEnter is called when a trigger collider enters another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag specified for static obstacles
        if (other.gameObject.CompareTag(obstacleTag))
        {
            // Check if the collider should pass through the static obstacles
            if (canPassThrough)
            {
                // Ignore trigger collisions with the static obstacle
                Physics.IgnoreCollision(other, GetComponent<Collider>(), true);
            }
        }
    }
}
