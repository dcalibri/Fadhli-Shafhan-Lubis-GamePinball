using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterToDefCamZoomin : MonoBehaviour
{
    public CameraController CameraController;
    public Collider bola;
    public float length = 6;
   

   
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
    void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            
           CameraController.FollowTarget(bola.transform, length);
            
        }
    }
}
