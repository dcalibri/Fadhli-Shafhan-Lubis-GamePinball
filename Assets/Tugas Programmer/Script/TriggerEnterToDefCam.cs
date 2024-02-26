using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterToDefCam : MonoBehaviour
{
    public CameraController CameraController;
  

   

   
    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Called when another collider exits the trigger collider attached to this object
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TheBall"))
        {
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                CameraController.GoBackToDefault();
            }
        }
    }
}
