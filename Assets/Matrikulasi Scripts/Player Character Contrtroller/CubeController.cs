using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController controller;

    public GameObject floor;
    public Material publicMaterial;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

 
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        UnityEngine.Debug.Log(horizontalInput + " " + verticalInput);

        var direction = new Vector3(horizontalInput, 0, verticalInput);
        var velocity = direction * speed;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GetComponent<Rigidbody>().freezeRotation)
            {
                GetComponent<Rigidbody>().freezeRotation = false;
            }
            else
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            } 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Renderer>().materials[0].SetColor("_Color", new Color(Random.value, Random.value, Random.value));


        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.localScale = new Vector3(3, 3, 3);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            floor.GetComponent<Renderer>().material = publicMaterial;

        }
    }

}
