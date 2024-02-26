using UnityEngine;
using UnityEngine.Events;

public class EnterAndActivateTheObject : MonoBehaviour
{
    public bool theBallEntered;
    public bool doEffect;

    public AudioManager audioManager;
    public VFXManager vfxManager; // Reference to the VFXManager

    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    // Called when another collider exits the trigger collider attached to this object
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TheBall"))
        {
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = false;
                theBallEntered = true;

                if (doEffect)
                { 
                    vfxManager.PlayVFX(transform.position);
                    audioManager.PlaySFX(transform.position);
                }
                
            }
        }
    }
}
