using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public Rigidbody theRB;
    public int force = 1;


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            theRB.AddForce(transform.forward * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            theRB.AddForce(-transform.forward * force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            theRB.AddForce(transform.right * force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            theRB.AddForce(-transform.right * force);
        }
    }
}